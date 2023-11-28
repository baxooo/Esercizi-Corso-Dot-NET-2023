using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonProxy
{
    public class Proxy
    {
        private static Proxy _instance;
        private static readonly object lockObject = new object();

        private static string _ip1;
        private static string _ip2;
        private static string _ip3;
        private static string _ip4;

        public string Ip1 { get { return _ip1; } }
        public string Ip2 { get { return _ip2; } }
        public string Ip3 {  get { return _ip3; } }
        public string Ip4 { get { return _ip4; } }

        public static Proxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Proxy();
                        }
                    }
                }

                return _instance;
            }
        }


        private Proxy()
        {
            Random rnd = new Random();
            _ip1 = $"{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}";
            _ip2 = $"{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}";
            _ip3 = $"{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}";
            _ip4 = $"{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}.{rnd.Next(1, 255)}";
        }

    }
}
