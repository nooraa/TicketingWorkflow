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
        /// <summary>
        /// Assigns ticket to user
        /// </summary>
        /// <param name="assignedUserId"></param>
        /// <param name="ticketId"></param>
        public async Task AssignTicketToUserAsync(int assignedUserId, int ticketId)
        {
            var assignedTicket = dataWriter.UptadeTicket(assignedUserId, ticketId);
            if(assignedTicket != null)
            {
                await SendMailToSuportEngAsync(assignedTicket.Title, assignedTicket.Description);
            }
        }

        private async Task SendMailToSuportEngAsync(string title, string description)
        {
            MailRequest request = new MailRequest();
            request.Subject = "New ticket information!";
            request.Body = @$"<h1>New ticket has been assigned to you!</h1>
                            Hello,
                            <br />
                            <p>The below is information about the ticket that has been assigned to you!</p>
                            <br />
                            <p>Ticket title: {title}</p>
                            <br />
                            <p>Ticket description: {description}</p>";
            request.ToEmail = "noora-70@live.se";
            await mailService.SendEmailAsync(request);
        }
    }
}
