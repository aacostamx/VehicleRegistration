using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class PrivateLogRUFPayment
    {
        public int ApplicationNumber { get; set; }
        public PaymentsInfo PaymentsInfo { get; set; }
        public string CUN { get; set; }
        public string CarNumber { get; set; }
        public string CarCode { get; set; }
        public string OwnerName { get; set; }
        public string MOFReceiptId { get; set; }
        public string SourceReceiptId { get; set; }
        public Agent Agent { get; set; }
    }

    public class Agent
    {
        public string BranchName { get; set; }
        public string Username { get; set; }
    }

    public class Tax
    {
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public double TaxValue { get; set; }
        public string Year { get; set; }
    }

    public class FeesBreakdown
    {
        public List<Tax> Taxes { get; set; }
    }

    public class PaymentsInfo
    {
        public FeesBreakdown FeesBreakdown { get; set; }
        public double TotalFees { get; set; }
        public int CurrentYearIncluded { get; set; }
        public string DiscountPercentage { get; set; }
        public double Discounts { get; set; }
    }
}
