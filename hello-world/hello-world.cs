using System;
using System.Net;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, world!");

        using (var wc = new WebClient()) {
            // ip address is obtained via `dig +short httpvshttps.com`
            var content = wc.DownloadString("http://45.33.7.16/robots.txt");
            Console.WriteLine(content);
        }

        Console.WriteLine("Bye, world!");
    }
}
