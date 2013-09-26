using BookSystem.BooksData;
using BookSystem.BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookSystem.Account
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BookTemplate.Style.Add("Display", "None");
            this.DeleteTemplate.Style.Add("Display", "None");
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void NewBookBtn_Click(object sender, EventArgs e)
        {
            this.NewBookBtn.Style.Add("Display", "None");
            this.BookTemplate.Style.Add("Display", "Block");

            this.Isbn.Text = "";
            this.BookTitle.Text = "";
            this.WebSite.Text = "";
            this.Author.Text = "";
            this.Description.Text = "";

            this.ActionBtn.Text = "Create";
            this.title.InnerHtml = "Create Book";
            this.ActionBtn.CommandName = "Create";

            var dbContext = new ApplicationDbContext();
            var categories = dbContext.Categories.ToList();

            this.Categories.DataSource = categories;
            this.Categories.DataValueField = "Id";
            this.Categories.DataTextField = "Name";
            this.Categories.DataBind();
        }

        protected void EditBtn_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new ApplicationDbContext();
            var id = Convert.ToInt32(e.CommandArgument);
            var book = dbContext.Books.Find(id);
            this.SetTemplate("Edit Book", book, "Edit", id.ToString());
        }

        private void SetTemplate(string title,
            Book book,
            string action,
            string argument)
        {
            this.NewBookBtn.Style.Add("Display", "None");
            this.BookTemplate.Style.Add("Display", "Block");
            this.title.InnerText = title;
            this.BookTitle.Text = book.Title;
            this.Author.Text = book.Author;
            this.Isbn.Text = book.Isbn;
            this.WebSite.Text = book.WebSite;
            this.Description.Text = book.Description;
            this.ActionBtn.Text = action;
            this.ActionBtn.CommandName = action;
            this.ActionBtn.CommandArgument = argument;

            var dbContext = new ApplicationDbContext();
            var categories = dbContext.Categories.ToList();

            this.Categories.DataSource = categories;
            this.Categories.DataValueField = "Id";
            this.Categories.DataTextField = "Name";
            this.Categories.DataBind();
        }

        protected void DeleteBtn_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new ApplicationDbContext();
            var id = Convert.ToInt32(e.CommandArgument);
            var book = dbContext.Books.Find(id);

            this.DeleteTemplate.Style.Add("Display", "Block");
            this.DeleteTextHeader.Text = "Confirm Book Deletion?";
            this.DeleteBookTitle.Text = book.Title;
            this.DeleteBookTitle.Enabled = false;
            this.DeleteActionBtn.Text = "Delete";
            this.DeleteActionBtn.CommandName = "Delete";
            this.DeleteActionBtn.CommandArgument = book.Id.ToString();          
        }

        protected void ActionBtn_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new ApplicationDbContext();

            try
            {
              
                if (e.CommandName == "Edit")
                {
                    var Id = Convert.ToInt32(e.CommandArgument);
                    var book = dbContext.Books.Find(Id);
                
                    book.Title = this.BookTitle.Text;
                    book.Author = this.Author.Text;
                    book.Isbn = this.Isbn.Text;
                    book.WebSite = this.WebSite.Text;
                    book.Description = this.Description.Text;
                    var categoryId = Int32.Parse(this.Categories.SelectedValue);
                    book.Category = dbContext.Categories.Find(categoryId);
                    dbContext.SaveChanges();
                    this.DataBind();
                }
                else if (e.CommandName == "Delete")
                {
                    var Id = Convert.ToInt32(e.CommandArgument);
                    var book = dbContext.Books.Find(Id);
                    dbContext.Books.Remove(book);
                    dbContext.SaveChanges();
                    this.DeleteBookTitle.Enabled = true;
                    this.DataBind();
                }
                else if (e.CommandName == "Create")
                {
                    var book = new Book()
                    {
                        Title = this.BookTitle.Text,
                        Author = this.Author.Text,
                        Isbn = this.Isbn.Text,
                        WebSite = this.WebSite.Text,
                        Description = this.Description.Text
                    };

                    var categoryId = Int32.Parse(this.Categories.SelectedValue);
                    book.Category = dbContext.Categories.Find(categoryId);
                    dbContext.Books.Add(book);
                    dbContext.SaveChanges();
               
                    this.Isbn.Text = "";
                    this.BookTitle.Text = "";
                    this.WebSite.Text = "";
                    this.Author.Text = "";
                    this.Description.Text = "";
                    this.DataBind();
                }
            }

            catch (Exception)
            {
                this.errorSaveToDB.Text = "Unexpected Error (DB Problems)";
            }

            this.NewBookBtn.Style.Add("Display", "Block");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            this.NewBookBtn.Style.Add("Display", "Block");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<BookSystem.BooksModel.Book> EditBooks_GetData()
        {
            var DbContext = new ApplicationDbContext();
            var books = DbContext.Books.Include("Category").OrderBy(b => b.Id);
            return books;
        }
    }
}