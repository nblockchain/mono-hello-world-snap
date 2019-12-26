using System;
using System.Net;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 1) {
            Console.Error.WriteLine ("At least one argument required");
            Environment.Exit(1);
        }
        if (args.Length > 1) {
            Console.Error.WriteLine ("Only one argument can be supplied");
            Environment.Exit(1);
        }
        using (var wc = new WebClient()) {
            var content = wc.DownloadString(args[0]);
            Console.WriteLine(content);
        }
    }
}
