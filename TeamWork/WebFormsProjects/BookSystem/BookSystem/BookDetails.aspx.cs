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
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void Back_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Default.aspx");
        }

        public IEnumerable<BookSystem.BooksModel.Book> details_GetData([QueryString("id")]
                                                                       int? Id)
        {
           
            var dbContext = new ApplicationDbContext();
            var book = dbContext.Books.Include("Category").Where(b => b.Id == Id).ToList();
            return book;
        }
    }
}