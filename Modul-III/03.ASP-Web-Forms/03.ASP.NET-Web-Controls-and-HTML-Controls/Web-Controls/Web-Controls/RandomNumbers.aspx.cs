using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Controls
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        private readonly Random random;

        public RandomNumbers()
        {
            this.random = new Random();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GenerateRandomNumberBtn_Click(object sender, EventArgs e)
        {
            int lowerBound = int.Parse(this.LowerBoundTextBox.Text);
            int upperBound = int.Parse(this.UpperBoundTextBox.Text);

            if (upperBound < lowerBound)
            {
                this.Result.Text = "First number must be less than or equal to second number!";
            }
            else
            {
                int randomNumber = this.random.Next(lowerBound, upperBound);
                this.Result.Text = randomNumber.ToString();
            }

        }
    }
}