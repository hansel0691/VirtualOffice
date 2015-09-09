using System.Linq;
using Domain.Blackstone;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;
using Domain.Models.Handlers;
using Newtonsoft.Json;

namespace Services.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRepository<ReportModel> _reportRepository;
        private IRepository<UserReport> _userReportRepository;
        private IEmployeeRepository _employeeRepository;
        private IRepository<HashKey> _keyRepository;
        private ITokenRepository _tokenRepository;

        

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<IUserRepository>();

            _userRepository.OnAdd += UserRepositoryOnOnAdd;


            _reportRepository = unitOfWork.Get<ReportModel>();
            _userReportRepository = unitOfWork.Get<UserReport>();
            _keyRepository = unitOfWork.Get<HashKey>();
            _employeeRepository = unitOfWork.GetRepository<IEmployeeRepository>();

            _unitOfWork = unitOfWork;
        }

        public User GetUser(string userName, string password)
        {
            User user = _userRepository.LogIn(userName, password);

            if (user == null)
            {
                return null;
            }

            AddOrUpdateUser(user);

            _unitOfWork.Commit();

            var newOrUpdatedUser = _userRepository.GetByID(user.RefId);

            if (newOrUpdatedUser != null)
                user.Id = newOrUpdatedUser.Id;    

            return user;
        }

        public User ChangeUserPassword(User user, string newPassword)
        {
            user = _userRepository.ChangePassword(user, newPassword);

            _unitOfWork.Commit();

            return user;
        }

        public int GetEmployeeId(User user)
        {
            Employee employee = _employeeRepository.GetEmployees().FirstOrDefault(x => x.Agent_ID == user.RefId);

            if (employee != null)
            {
                return employee.Employee_ID;
            }
            else
            {
                return -1;
            }
        }

        public void AddHashToUser(User user, string hash)
        {
            HashKey key = new HashKey(hash) {UserId = user.Id};

            _keyRepository.Add(key);

            _unitOfWork.Commit();
        }

        public void AddTokenForBlackstoneMerchantUser(string userId, string password, string token)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserWithKey(string key)
        {
            var hashKey = _keyRepository.Get(x => x.Hash == key).LastOrDefault();

            if (hashKey == null)
            {
                return null;
            }

            User user = GetUser(hashKey.User.RefId.ToString(), "EAA6DD0D-CE53-445E-976E-363814FCC77F");

            return user;
        }

        private void UserRepositoryOnOnAdd(object sender, EntityAddedEventHandlerArgs<User> args)
        {
            AddReportsToUser(args.Entity);
        }

        private void AddReportsToUser(User user)
        {
            var reports = _reportRepository.Get();

            foreach (var report in reports)
            {
                string output = string.IsNullOrEmpty(report.DefaultOutput) ? report.Output : report.DefaultOutput;

                UserReport userReport = new UserReport
                {
                    Output = output,
                    OutputConfiguration = GetOutputConfigurationFromOutput(output),
                    ReportId = report.Id,
                    User = user,
                };

                _userReportRepository.Add(userReport);
            }
        }

        private string GetOutputConfigurationFromOutput(string output)
        {
            var columns = output.Split(',')
                .Select((x, y) => new
                    {
                        Name = x,
                        Width = 120,
                        Index = y,
                        Level = 0
                    });

            string result = JsonConvert.SerializeObject(columns);

            return result;
        }

        private void AddOrUpdateUser(User user)
        {
            _userRepository.Add(user);

        }
    }
}