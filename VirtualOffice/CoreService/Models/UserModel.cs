namespace CoreService.Models
{
    public class UserModel : BaseResponse
    {
        public int UserId { get; set; }

        public string UserCategory { get; set; }
        
        public int EmployeeId { get; set; }

        public string BusinessName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal? Comission { get; set; }
        
        public string Name { get; set; }
        
        public string City { get; set; }
    }
}