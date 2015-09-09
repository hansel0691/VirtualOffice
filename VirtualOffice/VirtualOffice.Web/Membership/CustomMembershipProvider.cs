using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ApiRestClient.Infrastructure;
using ApiRestClient.Models;
using ClassLibrary2.Domain.Others;
using Domain.Models.Exceptions;
using RestSharp;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.App_Start;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using WebMatrix.WebData;

namespace VirtualOffice.Web.Membership
{
    public class CustomMembershipProvider: ExtendedMembershipProvider
    {
        private readonly IWebClient _webClient;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly VirtualOfficeService _virtualOfficeService;

        public CustomMembershipProvider()
        {
            _virtualOfficeService = new VirtualOfficeService();
            var resolver = DependencyResolver.Current;

            _webClient = (IWebClient)resolver.GetService(typeof(IWebClient));
            _apiKey = "abc";
            _apiSecret = "asdfasdfadfa";
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            
            if(String.Equals(password, Utils.ExternalLoginIdentifier))
              return true;
          
            //Standard Login
            var user = VirtualOfficeLoginUser(username, password);
            
            if (user != null)
               HttpContext.Current.Session.Add(Utils.UserKey, user);

            return !user.IsNull() && user.UserId > 0;
        }

        //Old way (Using Nicolas Perez's API (Doesn't work properly))
        private UserModel LoginUser(string userId, string password)
        {
            var requestInfo = new RequestInfo
            {
                AuthUrl = ApiUrls.AUHT_URL,
                Method = Method.POST,
                RequestUrl = ApiUrls.LOGIN_URL
            };
            var response = _webClient.Execute<UserModel>(new { UserName = userId, Password = password }, _apiKey, _apiSecret, requestInfo);

            return response;
        }

        private UserModel VirtualOfficeLoginUser(string userId, string password)
        {
            var user = _virtualOfficeService.GetUser(userId, password);

            var userResult = user.MapTo<VirtualOfficeUser, UserModel>();

            return userResult;
        }

        private UserModel LoginUserWithToken(string token)
        {
            var requestInfo = Utils.GetRequestInfo(Method.GET, "/api/User/GetUserWithToken");

            var getUserWithTokenResponse = _webClient.Execute<UserModel>(new { token = token }, ApiUrls.API_KEY, ApiUrls.API_SECRET, requestInfo);

            return getUserWithTokenResponse;
        }


        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException();
        }

        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException();
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public override bool IsConfirmed(string userName)
        {
            throw new NotImplementedException();
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}