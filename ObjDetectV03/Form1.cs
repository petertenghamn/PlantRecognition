using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjDetectV03
{
    public partial class Form1 : Form
    {
        // Global vars

        // Enum? test choice
        // bool automated

        // End global vars

        public Form1()
        {
            InitializeComponent();
        }

        private void cb_method_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure a selection is choosen, so when the program is ran, it is according to selected method

        }

        private void cb_automated_CheckedChanged(object sender, EventArgs e)
        {
            // Selection wether the user wants to run a test manually or have it scan the applications folders and return the full results

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            // Start the program according to the selections made



            // Temp just launch the only option... manual testing.
            bool inputGreyScaled = false;

            ManualDetectFrom newForm = new ManualDetectFrom(inputGreyScaled);
            newForm.ShowDialog();
        }
    }
}
