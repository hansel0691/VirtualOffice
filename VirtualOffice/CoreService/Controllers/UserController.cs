 using System;
 using System.Web.Http;
using CoreService.Filters;
using CoreService.Models;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace CoreService.Controllers
{
#if !DEBUG
  //  [AuthorizationFilter]
#endif

    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IHashProvider _hashProvider;

        public UserController(IUserService userService, IHashProvider hashProvider)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            _userService = userService;
            _hashProvider = hashProvider;
        }

        [HttpPost]
        public IHttpActionResult GetUser([FromBody] LoginDataModel loginData)
        {
            User user = _userService.GetUser(loginData.UserName, loginData.Password);

            if (user == null)
            {
                return NotFound();
            }

            var response = GetUserModelReponse(user);

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetUserWithToken(string token)
        {
            User user = _userService.GetUserWithKey(token);

            if (user == null)
            {
                return NotFound();
            }

            var response = GetUserModelReponse(user);

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult GetUserExternalToken([FromBody] LoginDataModel loginData)
        {
            User user = _userService.GetUser(loginData.UserName, loginData.Password);

            if (user == null)
            {
                return NotFound();
            }

            string hash = _hashProvider.GetHash(loginData.UserName.ToString(), loginData.Password + DateTime.Now.ToBinary().ToString());

            _userService.AddHashToUser(user, hash);

            return Ok(new {Token = hash, UserCategory = user.Category.ToString()});
        }

        [HttpPost]
        public IHttpActionResult ChangePassword([FromBody] ChangeCredentialsDataModel model)
        {
            User user = _userService.GetUser(model.UserName, model.Password);

            if (user == null)
            {
                return NotFound();
            }

            user = _userService.ChangeUserPassword(user, model.NewPassword);
            var response = GetUserModel(user);

            int employeeId = GetEmployeeId(user);
            response.EmployeeId = employeeId;

            return Ok(response);
        }

        private UserModel GetUserModelReponse(User user)
        {
            var response = GetUserModel(user);

            int employeeId = GetEmployeeId(user);
            response.EmployeeId = employeeId;
            return response;
        }

        private int GetEmployeeId(User user)
        {
            int employeeId = -1;

            if (user.Category == Category.Agent)
            {
                employeeId = _userService.GetEmployeeId(user);
            }
            return employeeId;
        }

        private UserModel GetUserModel(User user)
        {
            if (user == null)
            {
                return new UserModel { UserId = -1 };
            }

            return new UserModel
            {
                UserId = user.RefId,
                UserCategory = user.Category.ToString(),
                Address1 = user.Address1,
                Address2 = user.Address2,
                BusinessName = user.BusinessName,
                Comission = user.Comission,
                Email = user.Email,
                Phone = user.Phone,
                State = user.State,
                ZipCode = user.ZipCode,
                Name = user.Name,
                City = user.City
            };
        }

        [HttpGet]
        public IHttpActionResult TestGetUser()
        {
            return GetUser(new LoginDataModel {UserName = "3272a", Password = "1010"});
        }

        [HttpGet]
        public IHttpActionResult TestGetUserToken(string userId, string password)
        {
            return GetUserExternalToken(new LoginDataModel {UserName = userId, Password = password});
        }

        [HttpGet]
        public IHttpActionResult TestChangeUserPass(string password, string newPassword)
        {
            return ChangePassword(new ChangeCredentialsDataModel {UserName = "2272", Password = password, NewPassword = newPassword});
        }
    }
}
