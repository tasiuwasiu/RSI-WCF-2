﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library
{
    /// <summary>
    /// Klasa implementujaca interfejs kontraktu serwisu 
    /// Autor: Rafal Wasik
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        List<string> names = new List<string>();

        /// <summary>
        /// Metoda obslusujaca zapytanie klienta o pobranie pliku
        /// </summary>
        /// <param name="req">Obiekt RequestMessage zawierajacy nazwe pliku</param>
        /// <returns>Obiekt StreamMessage z informacjami do pobrania pliku</returns>
        public StreamMessage downloadFile(RequestMessage req)
        {
            StreamMessage response = new StreamMessage();
            string fileName = req.name;
            FileStream myFile;
            Console.WriteLine("Downloading file: " + fileName);
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files",  fileName);
            
            try
            {
                myFile = File.OpenRead(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine(String.Format("Error downloading file: {0}", filePath));
                Console.WriteLine(e.ToString());
                throw e;
            }
            OperationContext clientContext = OperationContext.Current;
            clientContext.OperationCompleted += new EventHandler(delegate (object sender, EventArgs args)
            {
                if (myFile != null)
                    myFile.Dispose();
            });
            response.fileName = fileName;
            data.TryGetValue(fileName, out response.description);
            response.dataStream = myFile;
            Console.WriteLine();
            return response;
        }

        /// <summary>
        /// Metoda obslugujaca zapytanie klienta o wszystkie dostepne pliki
        /// </summary>
        /// <returns>Obiekt AllFilesMessage zawierajacy wszystkie nazwy i opisy plikow</returns>
        public AllFilesMessage getFiles()
        {
            AllFilesMessage response = new AllFilesMessage();
            Dictionary<string,string> allData = new Dictionary<string, string>();
            response.data = data;
            return response;
        }

        /// <summary>
        /// Metoda obslugujaca wyslanie pliku z klienta na serwer
        /// </summary>
        /// <param name="req">Obiekt StreamMessage z informacjami do wyslania pliku</param>
        public void uploadFile(StreamMessage req)
        {
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", req.fileName);
            string fileName = req.fileName;
            string description = req.description;
            Stream instream = req.dataStream;
            const int bufferLength = 8192;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];
            Console.WriteLine("Uploading file: {0}", fileName);
            try
            {
                
                using (FileStream outstream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {

                    while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
                    {
                        outstream.Write(buffer, 0, counter);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            
            instream.Close();
            Console.WriteLine("Uploaded file: {0}", fileName);
            Console.WriteLine();
            if (data.ContainsKey(fileName))
                data.Remove(fileName);

            data.Add(fileName, description);

        }
    }
}
