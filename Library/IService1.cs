using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace Library
{
    /// <summary>
    /// Interfejs kontraktu serwisu
    /// Autor: Rafal Wasik
    /// </summary>
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Metoda zwraca informacje potrzebne do pobrania obrazka
        /// </summary>
        /// <param name="req">Obiekt RequestMessage zawierajacy nazwe pliku</param>
        /// <returns>Obiekt StreamMessage z nazwa, opisem oraz strumieniem do pliku</returns>
        [OperationContract]
        StreamMessage downloadFile(RequestMessage req);

        /// <summary>
        /// Metoda pobiera nowy obrazek na serwer
        /// </summary>
        /// <param name="stream">Obiekt StreamMessage z nazwa, opisem oraz strumieniem do pliku</param>
        [OperationContract]
        void uploadFile(StreamMessage stream);

        /// <summary>
        /// Metoda zwraca informacje o plikach przechowywanych na serwerze
        /// </summary>
        /// <returns>Obiekt AllFilesMessage z nazwami i opisami plikow</returns>
        [OperationContract]
        AllFilesMessage getFiles();
    }

    /// <summary>
    /// Klasa przechowuje nazwe, opis oraz strumien do pliku 
    /// Autor: Rafal Wasik
    /// </summary>
    [MessageContract]
    public class StreamMessage
    {
        /// <summary>
        /// Nazwa pliku
        /// </summary>
        [MessageHeader]
        public string fileName;

        /// <summary>
        /// Opis pliku
        /// </summary>
        [MessageHeader]
        public string description;

        /// <summary>
        /// Strumien zawierajacy plik
        /// </summary>
        [MessageBodyMember]
        public Stream dataStream;
    }

    /// <summary>
    /// Klasa przechowuje nazwe pliku do pobrania 
    /// Autor: Rafal Wasik
    /// </summary>
    [MessageContract]
    public class RequestMessage
    {
        /// <summary>
        /// Nazwa pliku
        /// </summary>
        [MessageBodyMember]
        public string name;
    }

    /// <summary>
    /// Klasa przechowuje nazwy i opisy plikow 
    /// Autor: Rafal Wasik
    /// </summary>
    [MessageContract]
    public class AllFilesMessage
    {
        /// <summary>
        /// Slownik zawierajacy nazwe jako klucz i opis jako wartosc
        /// </summary>
        [MessageBodyMember]
        public Dictionary<string, string> data;
    }

}
