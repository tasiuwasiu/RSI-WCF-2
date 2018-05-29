using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        StreamMessage downloadFile(RequestMessage req);

        [OperationContract]
        void uploadFile(StreamMessage stream);

        [OperationContract]
        AllFilesMessage getFiles();

    }

    [MessageContract]
    public class StreamMessage
    {
        [MessageHeader]
        public string nazwaPliku;

        [MessageHeader]
        public string opis;

        [MessageBodyMember]
        public Stream dane;
    }

    [MessageContract]
    public class RequestMessage
    {
        [MessageBodyMember]
        public string nazwa;
    }

    [MessageContract]
    public class AllFilesMessage
    {
        [MessageBodyMember]
        public List<string> nazwy;

        [MessageBodyMember]
        public List<string> opisy;
    }


}
