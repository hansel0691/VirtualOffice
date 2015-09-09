namespace CoreService.Models
{
    public class LoginDataModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangeCredentialsDataModel : LoginDataModel
    {
        public string NewPassword { get; set; }
    }
}