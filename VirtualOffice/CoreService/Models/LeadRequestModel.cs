using System;

namespace CoreService.Models
{
    public class AgentTimeFilter
    {
        public int AgentId { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}