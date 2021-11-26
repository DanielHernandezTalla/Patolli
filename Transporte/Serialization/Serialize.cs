using Entidades.Connection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transporte.Serialization
{
    public static class Serialize
    {
        public static Entidades.Events.Event ByteToObject(byte[] buffer, bool pruebaQUITAR)
        {
            string mensaje;
            int endIndex;

            mensaje = Encoding.ASCII.GetString(buffer);
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);

            Entidades.Events.Event obj = JsonConvert.DeserializeObject<Entidades.Events.Event>(mensaje);

            return obj;
        }

        public static T JobjToObject<T>(object jobj)
        {
            string mensaje;
            int endIndex;

            mensaje = jobj.ToString();
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);

            T obj = JsonConvert.DeserializeObject<T>(mensaje);

            return obj;
        }

        public static byte[] ObjectToByte(Entidades.Events.Event obj)
        {
            string output = JsonConvert.SerializeObject(obj);

            byte[] response = Encoding.ASCII.GetBytes(output);

            return response;
        }

        

        // --------------------------------------

        /*public static SocketMessage ByteToObject(byte[] buffer)
        {
            string mensaje;
            int endIndex;

            mensaje = Encoding.ASCII.GetString(buffer);
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);


            SocketMessage obj = JsonConvert.DeserializeObject<SocketMessage>(mensaje);

            return obj;
        }*/

        public static byte[] ObjectToByte(User _user, string _url, int _status, Object _body)
        {
            SocketMessage socketRequest = new SocketMessage()
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
            SocketMessage socketRequest = new SocketMessage()
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
            SocketMessage socketRequest = new SocketMessage()
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
            SocketMessage socketRequest = new SocketMessage()
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
            SocketMessage socketRequest = new SocketMessage()
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
    }
}
