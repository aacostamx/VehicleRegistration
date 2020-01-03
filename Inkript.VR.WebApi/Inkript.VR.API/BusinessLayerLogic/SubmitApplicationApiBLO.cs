using Inkript.Logging;
using Inkript.VR.API.Helpers;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Inkript.VR.API
{
    public class SubmitApplicationApiBLO
    {
        public ObjectResult<bool> SubmitApplication(int applicationId)
        {
            ApplicationBLO applicationBiz = new ApplicationBLO();
            InvoiceNumberBLO invoiceNumberBiz = new InvoiceNumberBLO();
            PaymentSubmitApiBLO paymentSubmitApiBiz = new PaymentSubmitApiBLO();
            ApplicationApiBLO applicationApiBLO = new ApplicationApiBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();
            ObjectResult<bool> paymentResult = new ObjectResult<bool>();
            ObjectResult<int> commitResult = new ObjectResult<int>();
            ObjectResult<SubmitOrder> submitResult = new ObjectResult<SubmitOrder>();

            try
            {
                if (!applicationBiz.ApplicationExist(applicationId))
                {
                    output.Result = false;
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                Application application = applicationBiz.GetApplication(applicationId);

                if (application.Status.StatusId == (int)FlagStatus.Executed)
                {
                    output.Result = false;
                    output.Message = string.Format("Application Id {0} Status Is 'Executed'", applicationId);
                    return output;
                }

                submitResult = paymentSubmitApiBiz.CreateGeneralSubmit(application);

                if (!string.IsNullOrEmpty(submitResult.Message))
                {
                    output.Result = false;
                    output.Message = submitResult.Message;
                    return output;
                }

                List<SubmitOrder> paymentOrder = new List<SubmitOrder>();

                if (JsonHelper.JsonIsNull(application.Fees))
                {
                    if (JsonHelper.JsonIsNull(application.BusinessProcess))
                    {
                        output.Message = string.Format("Business Process for Application Id {0} Not Found", application.ApplicationId);
                        return output;
                    }
                    JsonBP businessProcess = JsonConvert.DeserializeObject<JsonBP>(application.BusinessProcess);
                    BusinessProcessJSON primaryBP = businessProcess.PrimaryBusinessProcess;
                    int carModificationBPId = Int32.Parse(ConfigurationManager.AppSettings["CarModificationBPId"]);
                    if ((int)primaryBP.BPId == carModificationBPId && JsonHelper.JsonIsNull(application.AutomaticallyCalculatedFees))
                    {
                        commitResult = applicationApiBLO.CommitApplication(application.ApplicationId);
                        if (commitResult.Result == (int)FlagStatusCode.Success)
                        {
                            application.Status.StatusId = (int)FlagStatus.Executed;
                            applicationBiz.UpdateApplication(application);
                            output.Result = true;
                            return output;
                        }
                        else
                        {
                            output.Result = false;
                            output.Message = "Commit Application failed";
                            return output;
                        }
                    }
                    output.Result = false;
                    output.Message =
                        string.Format("Fees for Application Id {0} Not Found and Bussiness Process is not valid", applicationId);
                    return output;
                }

                List<FeeByCategory> FeesByCategory =
                    JsonConvert.DeserializeObject<List<FeeByCategory>>(application.Fees);

                List<InvoiceNumberApplication> invoiceNumbers = new List<InvoiceNumberApplication>();

                foreach (FeeByCategory feeCategory in FeesByCategory)
                {
                    float totalAmount = 0;
                    foreach (Fees fee in feeCategory.Fees)
                    {
                        if (fee.FeeTotal.HasValue)
                        {
                            totalAmount += fee.FeeTotal.Value;
                        }

                    }
                    InvoiceNumberApplication invoiceNumber = new InvoiceNumberApplication();
                    invoiceNumber.InvoiceNumber = invoiceNumberBiz.GenerateInvoiceNumber(application.BranchId, feeCategory.FeeCategoryId);
                    invoiceNumber.CategoryId = feeCategory.FeeCategoryId;
                    invoiceNumber.InvoiceAmount = totalAmount;
                    if (totalAmount > 0)
                    {
                        invoiceNumber.InvoiceStatusId = (int)FlagStatus.PendingPayment;
                    }
                    else
                    {
                        invoiceNumber.InvoiceStatusId = (int)FlagStatus.Free;
                    }
                    invoiceNumbers.Add(invoiceNumber);

                    submitResult =
                        paymentSubmitApiBiz.CompleteSubmitOrder(submitResult.Result, feeCategory.Fees, invoiceNumber);

                    if (!string.IsNullOrEmpty(submitResult.Message))
                    {
                        output.Result = false;
                        output.Message = submitResult.Message;
                        return output;
                    }

                    paymentOrder.Add(submitResult.Result);
                }

                application.InvoicesNumbers = JsonConvert.SerializeObject(invoiceNumbers);

                paymentResult = paymentSubmitApiBiz.PaymentSubmit(paymentOrder);

                if (paymentResult.Result)
                {
                    float totalAmount = 0;
                    foreach (InvoiceNumberApplication invoiceNumberObject in invoiceNumbers)
                    {
                        totalAmount += invoiceNumberObject.InvoiceAmount;
                        if (invoiceNumberObject.InvoiceAmount > 0)
                        {
                            invoiceNumberObject.InvoiceStatusId = (int)FlagStatus.PendingPayment;
                        }
                    }
                    if (totalAmount > 0)
                    {
                        application.Status.StatusId = (int)FlagStatus.PendingPayment;
                        applicationBiz.UpdateApplication(application);
                    }
                    else if (totalAmount == 0)
                    {
                        commitResult = applicationApiBLO.CommitApplication(application.ApplicationId);
                        if (commitResult.Result == (int)FlagStatusCode.Success)
                        {
                            application.Status.StatusId = (int)FlagStatus.Executed;
                            applicationBiz.UpdateApplication(application);
                            output.Result = true;
                            return output;
                        }
                        else
                        {
                            output.Result = false;
                            output.Message = "Commit Application failed";
                            return output;
                        }
                    }
                }
                else
                {
                    output.Result = false;
                    output.Message = paymentResult.Message;
                    return output;
                }

                output.Result = true;
                return output;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Message = "Failed to Submit Application";
                return output;
            }
        }
    }
}