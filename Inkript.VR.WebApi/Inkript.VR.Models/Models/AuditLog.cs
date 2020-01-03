using System;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{
    public class AuditLog
    {
        public virtual int LogId { get; set; }
        public virtual int ActivityId { get; set; }
        public virtual int UserId { get; set; }
        public virtual DateTime AuditDate { get; set; }
        public virtual string JsonObject { get; set; }
        public virtual string ActivityStatus { get; set; }
    }
}
