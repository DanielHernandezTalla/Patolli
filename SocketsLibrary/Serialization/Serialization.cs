using Newtonsoft.Json;
using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Serialization
{
    public static class Serialize
    {
        #region Metodos de serializacion y deserializacion
        // Metodos para serializar y deserializar clases 
        public static SocketRequest ByteToObject(byte[] buffer)
        {
            string mensaje;
            int endIndex;

            mensaje = Encoding.ASCII.GetString(buffer);
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);


            SocketRequest obj = JsonConvert.DeserializeObject<SocketRequest>(mensaje);

            return obj;
        }

        public static byte[] ObjectToByte(User _user, string _url, int _status, Object _body)
        {
            SocketRequest socketRequest = new SocketRequest()
            {
                User = _user,
                Url = _url,
                Status = _status,
                Body = _body
            };

            string output = JsonConvert.SerializeObject(socketRequest);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }

        public static byte[] ObjectToByte(User _user, string _url)
        {
            SocketRequest socketRequest = new SocketRequest()
            {
                User = _user,
                Url = _url,
                Status = 200,
                Body = null
            };

            string output = JsonConvert.SerializeObject(socketRequest);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }

        public static byte[] ObjectToByte(User _user, string _url, Object _body)
        {
            SocketRequest socketRequest = new SocketRequest()
            {
                User = _user,
                Url = _url,
                Status = 200,
                Body = _body
            };

            string output = JsonConvert.SerializeObject(socketRequest);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }

        public static byte[] ObjectToByte(string _url, int _status, Object _body)
        {
            SocketRequest socketRequest = new SocketRequest()
            {
                User = null,
                Url = _url,
                Status = _status,
                Body = _body
            };

            string output = JsonConvert.SerializeObject(socketRequest);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }

        public static byte[] ObjectToByte(string _url, Object _body)
        {
            SocketRequest socketRequest = new SocketRequest()
            {
                User = null,
                Url = _url,
                Status = 200,
                Body = _body
            };

            string output = JsonConvert.SerializeObject(socketRequest);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }
        #endregion
    }
}
