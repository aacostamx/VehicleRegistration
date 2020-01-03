namespace Inkript.VR.API.Models
{
    public class VehicleRegistrationFeeCustom
    {
        public virtual double VehicleValue { get; set; }
        public virtual double CustomsTax { get; set; }
        public virtual double StampFee { get; set; }
        public virtual double OperationFee { get; set; }
        public virtual double Total { get; set; }
    }
}
