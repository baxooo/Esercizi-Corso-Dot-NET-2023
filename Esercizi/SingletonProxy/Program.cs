using System;

namespace SingletonProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy1 = Proxy.Instance;
            Proxy proxy2 = Proxy.Instance;

            if (proxy1.Ip1 == proxy2.Ip1)
                Console.WriteLine("proxy1 and proxy2 have the same ips 1 " + proxy1.Ip1);
            else
                Console.WriteLine($"proxy1 and proxy2 do not have the same ips 1 proxy1: {proxy1.Ip1}, proxy1: {proxy2.Ip1}");
            
            if (proxy1.Ip2 == proxy2.Ip2)
                Console.WriteLine("proxy1 and proxy2 have the same ips 2 " + proxy1.Ip2);
            else
                Console.WriteLine($"proxy1 and proxy2 do not have the same ips 2 proxy1: {proxy1.Ip2}, proxy1: {proxy2.Ip2}");

            if (proxy1.Ip3 == proxy2.Ip3)
                Console.WriteLine("proxy1 and proxy2 have the same ips 3 " + proxy1.Ip3);
            else
                Console.WriteLine($"proxy1 and proxy2 do not have the same ips 3 proxy1: {proxy1.Ip3}, proxy1: {proxy2.Ip3}");

            if (proxy1.Ip4 == proxy2.Ip4)
                Console.WriteLine("proxy1 and proxy2 have the same ips 4 " + proxy1.Ip4);
            else
                Console.WriteLine($"proxy1 and proxy2 do not have the same ips 4 proxy1: {proxy1.Ip4}, proxy1: {proxy2.Ip4}");

            if (proxy1.Equals(proxy2))
                Console.WriteLine("proxy1 and proxy2 are the same instance");
        }



    }
}
