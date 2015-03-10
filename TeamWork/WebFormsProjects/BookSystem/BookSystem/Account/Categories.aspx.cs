using BookSystem.BooksData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookSystem.BooksModel;

namespace BookSystem.Account
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.categoryTemplate.Style.Add("Display", "None");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<BookSystem.BooksModel.Category> Categories_GetData()
        {
            var dbContext = new ApplicationDbContext();
            var categories = dbContext.Categories.OrderBy(c => c.Id);
            return categories;
        }

        protected void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            this.NewCategoryBtn.Style.Add("Display", "None");
            SetTemplate("Create Category", null, "Create", null);
        }

        protected void EditBtn_Click(object sender, CommandEventArgs e)
        {
            this.NewCategoryBtn.Style.Add("Display", "None");
            var catID = Convert.ToInt32(e.CommandArgument);
            var dbContext = new ApplicationDbContext();
            var category = dbContext.Categories.Find(catID);
            SetTemplate("Edit Category", category.Name, "Edit", catID.ToString());
        }

        protected void ActionBtn_Command(object sender, CommandEventArgs e)
        { 
            var dbContext = new ApplicationDbContext();
            if (this.Name.Text == "" || this.Name.Text.Length > 50)
            {
                this.customValidator.IsValid = false;
            }
            try
            {
                if (IsValid)
                {
                    if (e.CommandName == "Edit")
                    {
                        var Id = Convert.ToInt32(e.CommandArgument);
                        var category = dbContext.Categories.Find(Id);
                        category.Name = this.Name.Text;
                        dbContext.SaveChanges();
                        this.DataBind();
                    }
                    else if (e.CommandName == "Delete")
                    {
                        var Id = Convert.ToInt32(e.CommandArgument);
                        var category = dbContext.Categories.Find(Id);
                        var books = category.Books;
                        dbContext.Books.RemoveRange(books);
                        dbContext.Categories.Remove(category);
                        dbContext.SaveChanges();
                        this.DataBind();
                    }
                    else if (e.CommandName == "Create")
                    {
                        var category = new Category()
                        {
                            Name = this.Name.Text
                        };

                        dbContext.Categories.Add(category);
                        dbContext.SaveChanges();
                        this.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                this.DbError.Text = "Unexpecd Error. Connection Lost to DB";
            }

            this.NewCategoryBtn.Style.Add("Display", "Block");
        }

        protected void DeleteBtn_Command(object sender, CommandEventArgs e)
        {
            this.NewCategoryBtn.Style.Add("Display", "None");
            var catID = Convert.ToInt32(e.CommandArgument);
            var dbContext = new ApplicationDbContext();
            var category = dbContext.Categories.Find(catID);
            this.Name.Enabled = false;
            SetTemplate("Delete Category", category.Name, "Delete", catID.ToString());
        }

        private void SetTemplate(string title,
            string textBoxData,
            string action,
            string argument)
        {
            this.categoryTemplate.Style.Add("Display", "Block");
            this.title.InnerText = title;
            this.Name.Text = textBoxData;
            this.ActionBtn.Text = action;
            this.ActionBtn.CommandName = action;
            this.ActionBtn.CommandArgument = argument;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            this.NewCategoryBtn.Style.Add("Display", "Block");
            this.Name.Enabled = true;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }
    }
}