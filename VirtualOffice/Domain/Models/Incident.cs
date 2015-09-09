using System;

namespace Domain.Models
{
    public class Incident : BaseModel
    {
        public int AgentId { get; set; }

        public int CustomerId { get; set; }

        public string MerchantName { get; set; }

        public string Type { get; set; }

        public string Statuts { get; set; }

        public string TerminalId { get; set; }

        public DateTime? DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }
    }
}