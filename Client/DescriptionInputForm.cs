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

        public DescriptionInputForm(string fileName, string filePath, Form1 mainForm)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.mainForm = mainForm;
            lab_imageName.Text = fileName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string description = tb_description.Text;
            mainForm.uploadFile(filePath, description);
            this.Close();
        }
    }
}
