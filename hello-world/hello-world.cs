using System;
using System.Net;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, world!");

        using (var wc = new WebClient()) {
            var content = wc.DownloadString("https://raw.githubusercontent.com/knocte/geewallet/master/LICENCE.txt");
            Console.WriteLine(content);
        }

        Console.WriteLine("Bye, world!");
    }
}
