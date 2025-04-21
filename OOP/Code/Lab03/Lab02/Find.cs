using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab02
{
    public partial class Find : Form
    {

        private string request;
        public Find()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {

            request = SearchString.Text;
            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        public string GetRequest()
        {
            return request;
        }


    }
}
