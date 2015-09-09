namespace Domain.Models
{
    public class ConsignmentType : BaseModel
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public int? Order { get; set; }
    }
}
