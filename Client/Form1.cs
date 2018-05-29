using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string>();

        Service1Client client = new Service1Client();

        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = names;
        }

        //upload
        private void but_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "JPG Image | *.jpg;*.jpeg";
            fileDialog.FilterIndex = 0;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = fileDialog.FileName;
                string fileName = Path.GetFileName(selectedFilePath);

                DescriptionInputForm descDialog = new DescriptionInputForm(fileName, selectedFilePath, this);
                descDialog.Show();
            }

        }

        public void uploadFile (string filePath, string description)
        {
            FileStream myFile;
            string fileName = Path.GetFileName(filePath);

            try
            {
                myFile = File.OpenRead(filePath);
                client.uploadFile(fileName, description, myFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error uploading image {0}", filePath));
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
        
        //exit
        private void but_exit_Click(object sender, EventArgs e)
        {
            client.Close();
            Application.Exit();
        }

        //refresh
        private void but_refresh_Click(object sender, EventArgs e)
        {
            names.Clear();

            string[] temp = client.getFiles(out temp);
            names.AddRange(temp);
            
            listBox1.DataSource = null;
            listBox1.DataSource = names;
        }

        //download
        private void but_download_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selected = (string)listBox1.SelectedItem;

                string description;
                Stream stream = null;
                client.downloadFile(selected, out description, out stream);
                string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", selected);
                downloadFile(stream, filePath);

            }
        }

        private void listbox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void downloadFile(System.IO.Stream instream, string filePath)
        {
            const int bufferLength = 8192;
            int bytecount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];

            FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write);

            while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
            {
                outstream.Write(buffer, 0, counter);
            }

            outstream.Close();
            instream.Close();
        }
    }
}
