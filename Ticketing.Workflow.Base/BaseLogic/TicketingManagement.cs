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
        public TicketingManagement()
        {
            dataWriter = new EFDataWriter();
            dataReader = new EFDataReader();
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

        public bool SaveNewTicket(TicketRequest ticketData)
        {
            return false;
        }
    }
}
