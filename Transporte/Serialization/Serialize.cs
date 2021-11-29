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
        /*public static Entidades.Events.Event ByteToObject(byte[] buffer, bool pruebaQUITAR)
        {
            string mensaje;
            int endIndex;

            mensaje = Encoding.ASCII.GetString(buffer);
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);

            Console.WriteLine(mensaje);
            List<string> messages = SplitMessages(mensaje);
            for (int i = 0; i < messages.Count; i++)
            {
                Console.WriteLine(messages[i]);
            }

            Entidades.Events.Event obj = JsonConvert.DeserializeObject<Entidades.Events.Event>(mensaje);

            return obj;
        }*/

        public static Queue<string> ByteToString(byte[] buffer)
        {
            string mensaje;
            int endIndex;

            mensaje = Encoding.ASCII.GetString(buffer);
            endIndex = mensaje.IndexOf("\0");
            if (endIndex > 0)
                mensaje = mensaje.Substring(0, endIndex);

            Console.WriteLine(mensaje);
            Queue<string> messages = SplitMessages(mensaje);

            return messages;
        }

        public static Entidades.Events.Event StringToObject(string message)
        {
            Entidades.Events.Event obj = JsonConvert.DeserializeObject<Entidades.Events.Event>(message);

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

        // Metodos para verificar que no se junten mensajes...

        public static Queue<string> SplitMessages(string message)
        {
            int c = 0;
            string current = "";

            Queue<string> messages = new Queue<string>();

            for (int i = 0; i < message.Length; i++)
            {

                current += message[i];

                if (message[i].Equals('{'))
                {
                    c++;
                }

                if(message[i].Equals('}'))
                {
                    c--;

                    if(c == 0)
                    {
                        messages.Enqueue(current);
                        current = "";   
                    }
                }
            }

            return messages;
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
