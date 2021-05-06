using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Workflow.Domain;

namespace Ticketing.Workflow.Base
{
    public class SubmittingManagement : ISubmittingManagement
    {
        IEFDataWriter dataWriter;
        IEFDataReader dataReader;
        IMailService mailService;

       public SubmittingManagement()
        {
            dataWriter = new EFDataWriter();
            dataReader = new EFDataReader();
            mailService = new MailService();
        }
        public UserInfo Login(LoginInfo login)
        {
            UserInfo userInfo = new UserInfo();
            var user = dataReader.Login(login.Username, login.Password);
           if(user != null)
            {
                userInfo.Username = user.Username;
                user.UserId = user.UserId;
            }
            return userInfo;
        }

        /// <summary>
        /// Gets a list all support engineers.
        /// </summary>
        /// <returns>List of UserInfo</returns>
        public List<UserInfo> GetAllSupportEngineers()
        {
            List<UserInfo> supportUsers = new List<UserInfo>();
            var dbUsers = dataReader.GetAllSupportEngineers();
            foreach(var u in dbUsers)
            {
                UserInfo item = new UserInfo
                {
                    UserId = u.UserId,
                    Username = u.Username
                };
                supportUsers.Add(item);
            }
            return supportUsers;
        }
    }
}
