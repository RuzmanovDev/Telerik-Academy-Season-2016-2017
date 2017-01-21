using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web_Controls
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string firstName = this.FirstNameTextBox.Text;
            string lastName = this.LastNameTextBox.Text;
            string facultyNumber = this.FacultyNumberTextBox.Text;
            string university = this.UniversityDropDownList.Text;
            string specialty = this.SpecialtyDropDownList.Text;

            var courses = this.CoursesCheckBox.Items.
                Cast<ListItem>().
                Where(i => i.Selected);

            var studentDiv = new HtmlGenericControl("div");

            var title = new HtmlGenericControl("h1");
            title.InnerText = "Student info";
            studentDiv.Controls.Add(title);

            var studentNameParagraph = new HtmlGenericControl("p");
            studentNameParagraph.InnerText = $"{firstName} {lastName}";
            studentDiv.Controls.Add(studentNameParagraph);

            var studentFacultyNumberParagraph = new HtmlGenericControl("p");
            studentFacultyNumberParagraph.InnerText = facultyNumber;
            studentDiv.Controls.Add(studentFacultyNumberParagraph);

            var studentUniversityParagraph = new HtmlGenericControl("p");
            studentUniversityParagraph.InnerText = university;
            studentDiv.Controls.Add(studentUniversityParagraph);

            var studentSpecialtyParagraph = new HtmlGenericControl("p");
            studentSpecialtyParagraph.InnerText = specialty;
            studentDiv.Controls.Add(studentSpecialtyParagraph);

            var listOfCourses = new HtmlGenericControl("ul");
            foreach (var course in courses)
            {
                var c = new HtmlGenericControl("li");
                c.InnerText = course.Text;
                listOfCourses.Controls.Add(c);
            }
            studentDiv.Controls.Add(listOfCourses);

            this.StudentInfoPlaceHolder.Controls.Add(studentDiv);
        }
    }
}