using System;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// Klasa obslugujaca formularz wprowadzania opisu pliku 
    /// Autor: Rafal Wasik
    /// </summary>
    public partial class DescriptionInputForm : Form
    {
        string fileName;
        string filePath;
        Form1 mainForm;

        /// <summary>
        /// Konstruktor formularza
        /// </summary>
        /// <param name="fName">nazwa pliku</param>
        /// <param name="fPath">sciezka do pliku</param>
        /// <param name="mainForm">referencja do glownego formularza</param>
        public DescriptionInputForm(string fName, string fPath, Form1 mainForm)
        {
            fileName = fName;
            filePath = fPath;
            this.mainForm = mainForm;
            
            InitializeComponent();
            lab_imageName.Text = fileName;
        }

        /// <summary>
        /// Metoda przekazuje informacje potrzebne do wyslania pliku
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string description = tb_description.Text;
            mainForm.uploadFile(filePath, description);
            this.Close();
        }
    }
}
