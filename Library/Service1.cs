using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        List<string> nazwy = new List<string>();
        List<string> opisy = new List<string>();

        public StreamMessage downloadFile(RequestMessage req)
        {
            StreamMessage response = new StreamMessage();
            string nazwa = req.nazwa;
            FileStream myFile;
            Console.WriteLine("Wywolano pobieranie pliku: " + nazwa);
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files",  nazwa);
            try
            {
                myFile = File.OpenRead(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine(String.Format("wyjatek otwarcia pliku {0}", filePath));
                Console.WriteLine(e.ToString());
                throw e;
            }
            response.nazwaPliku = nazwa;
            response.opis = "  ";
            response.dane = myFile;
            return response;
        }

        public AllFilesMessage getFiles()
        {
            AllFilesMessage response = new AllFilesMessage();
            response.nazwy = new List<string>();
            foreach (string e in nazwy)
            {
                Console.WriteLine("x");
                response.nazwy.Add(e);
            }
            response.opisy = opisy;
            try
            {

                Console.WriteLine(response.nazwy[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return response;
        }

        public void uploadFile(StreamMessage stream)
        {
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", stream.nazwaPliku);
            string opis = stream.nazwaPliku;
            Stream instream = stream.dane;
            const int bufferLength = 8192;
            int bytecount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];
            Console.WriteLine("Zapisje plik {0}", filePath);
            try
            {
                FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write);

                while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
                {
                    outstream.Write(buffer, 0, counter);
                    Console.Write(".{0}", counter);
                    bytecount += counter;
                }
                Console.WriteLine();
                Console.WriteLine("Zapisano {0} bajtow", bytecount);
                outstream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            
            instream.Close();
            Console.WriteLine();
            Console.WriteLine("Plik {0} zapisany", filePath);
            nazwy.Add(stream.nazwaPliku);
            opisy.Add(opis);
        }
    }
}
