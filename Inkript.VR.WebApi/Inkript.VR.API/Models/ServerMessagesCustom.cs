using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class ServerMessagesCustom {
        [JsonIgnore]
        public int ServerMessagesId { get; set; }
        [Required]
        public string Code { get; set; }
        public string Type { get; set; }
        public string Arabic { get; set; }
        public string English { get; set; }
    }
}
