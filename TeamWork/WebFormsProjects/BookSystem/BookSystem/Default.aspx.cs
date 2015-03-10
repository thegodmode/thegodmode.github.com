using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookSystem.BooksData;

namespace BookSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<BookSystem.BooksModel.Category> books_GetData()
        {
            var dbContext = new ApplicationDbContext();
            var categories = dbContext.Categories;
            return categories;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (this.searchText.Text.Length > 50)
            {
                this.searchValidator.IsValid = false;
            }
            if (IsValid)
            {
                var searchString = this.searchText.Text;
                this.Response.Redirect("Search?q=" + searchString);
            }
        }
    }
}