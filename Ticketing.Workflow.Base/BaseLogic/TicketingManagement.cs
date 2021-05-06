using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Workflow.Domain;

namespace Ticketing.Workflow.Base
{
    public class TicketingManagement : ITicketingManagement
    {
        IEFDataWriter dataWriter;
        IEFDataReader dataReader;
        IMailService mailService;
        public TicketingManagement()
        {
            dataWriter = new EFDataWriter();
            dataReader = new EFDataReader();
            mailService = new MailService();
        }
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            var categories = dataReader.GetCategories();
            foreach(var category in categories)
            {
                CategoryModel cModel = new CategoryModel {
                    Id = category.CategoryId,
                    Name = category.CategoryName
                };
                categoryModels.Add(cModel);
            }
            return categoryModels;
        }

        public List<SubCategoryModel> GetSubCategories()
        {
            List<SubCategoryModel> subcategoryModels = new List<SubCategoryModel>();
            var subcategories = dataReader.GetSubCategories();
            foreach (var subcategory in subcategories)
            {
                SubCategoryModel scModel = new SubCategoryModel
                {
                    Id = subcategory.SubCategoryId,
                    Name = subcategory.SubCategoryName,
                    CategoryId = subcategory.FK_Category
                };
                subcategoryModels.Add(scModel);
            }
            return subcategoryModels;
        }
        /// <summary>
        /// Gets all unassigned tickets
        /// </summary>
        /// <returns>A list of UnassignedTicket</returns>
        public List<UnassignedTicket> GetUnassignedTickets() {
            List<UnassignedTicket> tickets = new List<UnassignedTicket>();
                var dbTickets = dataReader.GetUnassignedTickets();
            foreach(var ticket in dbTickets)
            {
                UnassignedTicket item = new UnassignedTicket
                {
                    TicketId = ticket.TicketId,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Status = ticket.Status,
                    SubmitterEmail = ticket.Email
                };
                tickets.Add(item);
            }
            return tickets;
        }

        public async Task<bool> SaveNewTicketAsync(TicketRequest ticketData)
        {
            Ticket ticket = new Ticket
            {
                Title = ticketData.Title,
                Description = ticketData.Description,
                Email = ticketData.Email,
                Status = "Unassigned",
                FK_Category = ticketData.CategoryId,
                SubcategoryId = ticketData.SubcategoryId
            };
            int id = dataWriter.InsertTicket(ticket);
            if (id == -1) return false;
           await SendMailToAdminAsync(ticket.Title, ticket.Description);
            return true;
        }

        private async Task SendMailToAdminAsync(string title, string description)
        {
            MailRequest request = new MailRequest();
            request.Subject = "New ticket information!";
            request.Body = @$"<h1>New ticket has been registered in the system</h1>
                            Hello,
                            <br />
                            <p>A new ticket has been registered in the system:</p>
                            <br />
                            <p>Ticket title: {title}</p>
                            <br />
                            <p>Ticket description: {description}</p>";
            request.ToEmail = "noora-70@live.se";
           await mailService.SendEmailAsync(request);
        }
    }
}
