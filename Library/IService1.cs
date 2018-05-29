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
        public string fileName;

        [MessageHeader]
        public string description;

        [MessageBodyMember]
        public Stream dataStream;
    }

    [MessageContract]
    public class RequestMessage
    {
        [MessageBodyMember]
        public string name;
    }

    [MessageContract]
    public class AllFilesMessage
    {
        [MessageBodyMember]
        public Dictionary<string, string> data;
    }


}
