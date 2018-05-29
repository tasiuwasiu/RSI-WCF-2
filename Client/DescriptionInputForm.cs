using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class DescriptionInputForm : Form
    {
        string fileName;
        string filePath;
        Form1 mainForm;

        public DescriptionInputForm(string fName, string fPath, Form1 mainForm)
        {
            fileName = fName;
            filePath = fPath;
            this.mainForm = mainForm;
            
            InitializeComponent();
            lab_imageName.Text = fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string description = tb_description.Text;
            mainForm.uploadFile(filePath, description);
            this.Close();
        }
    }
}
