using BookSystem.BooksData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public System.Collections.IEnumerable resultRepeater_GetData([QueryString("q")]
                                                                     string searchText)
        {
            this.label.Text = "Search Results for Query “" + searchText + "”:";
            var dbContext = new ApplicationDbContext();
            if (String.IsNullOrWhiteSpace(searchText))
            {
                return dbContext.Books.Include("Category").OrderBy(b=>b.Title).ThenBy(b=>b.Author).ToList();
            }
            var result = dbContext.Books.Include("Category").Where(b => b.Title.Contains(searchText) ||
                                                    b.Author.Contains(searchText)).OrderBy(b=>b.Title).ThenBy(b=>b.Author).ToList();

            return result;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Default.aspx");
        }
    }
}