using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Controls
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnterTextBtn_Click(object sender, EventArgs e)
        {
            this.ResultLiteral.Text = this.TextBox.Text.ToString();
        }
    }
}