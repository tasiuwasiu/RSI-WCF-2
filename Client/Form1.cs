﻿using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// Klasa obslugujaca klienta
    ///  Autor: Rafal Wasik
    /// </summary>
    public partial class Form1 : Form
    {
        List<string> names = new List<string>();
        Dictionary<string, string> data = new Dictionary<string, string>();
        ToolTip toolTip = new ToolTip();

        Service1Client client = new Service1Client();

        /// <summary>
        /// Konstruktor okna klienta
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = names;

        }

        /// <summary>
        /// Metoda obslugujaca funkcje wysylania pliku
        /// </summary>
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

        /// <summary>
        /// Metoda wysylajaca plik na serwer
        /// </summary>
        /// <param name="filePath">sciezka do pliku</param>
        /// <param name="description">opis pliku</param>
        public void uploadFile(string filePath, string description)
        {
            string fileName = Path.GetFileName(filePath);

            using (FileStream myFile = File.OpenRead(filePath))
            {
                try
                {
                    client.uploadFile(description, fileName, myFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error uploading image {0}", filePath));
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Metoda obslugujaca zamykanie klienta
        /// </summary>
        private void but_exit_Click(object sender, EventArgs e)
        {
            client.Close();
            Application.Exit();
        }

        /// <summary>
        /// Metoda obslugujaca pobieranie informacji o plikach na serwerze
        /// </summary>
        private void but_refresh_Click(object sender, EventArgs e)
        {
            names.Clear();

            data = client.getFiles();
            names.AddRange(data.Keys);
            listBox1.DataSource = null;
            listBox1.DataSource = names;
        }

        /// <summary>
        /// Metoda obslugujaca pobieranie pliku z serwera
        /// </summary>
        private void but_download_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                string selected = (string)listBox1.SelectedItem;
                saveDialog.FileName = selected;
                saveDialog.Filter = "JPG Image | *.jpg;*.jpeg";
                string description;
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = null;
                    client.downloadFile(selected, out description, out stream);
                    string filePath = saveDialog.FileName;
                    downloadFile(stream, filePath);
                }

            }
        }

        /// <summary>
        /// Metoda obslugujaca pokazywanie sie opisu pliku
        /// </summary>
        private void listbox1_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);

            if (index != -1 && index < listBox1.Items.Count)
            {
                string desc;
                data.TryGetValue((string)listBox1.Items[index], out desc);
                if (toolTip.GetToolTip(listBox1) != desc)
                {
                    toolTip.SetToolTip(listBox1, desc);
                }
            }
            else
            {
                toolTip.SetToolTip(this.listBox1, string.Empty);
            }
        }

        /// <summary>
        /// Metoda pobiera plik z serwera
        /// </summary>
        /// <param name="instream">strumien zawierajacy plik</param>
        /// <param name="filePath">sciezka do zapisu pliku</param>
        private void downloadFile(System.IO.Stream instream, string filePath)
        {
            const int bufferLength = 8192;

            int counter = 0;
            byte[] buffer = new byte[bufferLength];

            using(instream)
            using (FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
                {
                    outstream.Write(buffer, 0, counter);
                }
            }
        }
    }
}
