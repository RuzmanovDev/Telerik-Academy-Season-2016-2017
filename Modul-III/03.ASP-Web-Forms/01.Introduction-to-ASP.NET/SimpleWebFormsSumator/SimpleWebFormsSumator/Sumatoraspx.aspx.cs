using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebFormsSumator
{
    public partial class Sumatoraspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        protected void SumBtn_Click(object sender, EventArgs e)
        {
            double firstNum;
            double secondNum;

            if (double.TryParse(this.FirstNumber.Text, out firstNum) && double.TryParse(this.SecondNumber.Text, out secondNum))
            {
                double result = firstNum + secondNum;
                this.Result.Text = result.ToString();
            }
            else
            {
                this.Result.Text = "Please enter valid numbers!";
            }

        }
    }
}