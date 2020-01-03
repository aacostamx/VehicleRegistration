using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagStatus
    {
        Active = 0x01,
        Inactive = 0x02,
        Pending = 0x03,
        PendingPayment = 0x04,
        Draft = 0x05,
        Closed = 0x06,
        Deleted = 0x07,
        Booked = 0x08,
        Executed = 0x09,
        Released = 0X10,
        Unavailable = 0X11,
        Free = 0x12,
        SubmissionFailed = 0x13
    }
}