using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string [] args)
    {
        string dataSource = "../trashmail_domains.md";
        string outputFile = "../TrashmailDetector.cs";

        var lines = File.ReadAllLines(dataSource);

        string output = @"// Author: Dalk
// Github Username: Dalk-Github
// You can use this in your service without any credits.
using System.Linq;

namespace TrashMailDomainDetector
{
    public static class TrashMailDomainDetector
    {
        public static string[] TRASH_DOMAINS = new string[]
        {
            ";


        foreach (string domain in GetDomains(lines))
        {
            output += $@"""{domain}"", ";
        }

        output = output.Remove(output.Length - 2);

        output += @"
        };
        public static bool IsTrashEmail(string mail)
        {
            return TRASH_DOMAINS.Contains(mail.Split('@')[1]);
        }
    }
}
";

        File.WriteAllText(outputFile, output);
    }

    private static IEnumerable<string> GetDomains(string[] lines)
    {
        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                if (line.Contains("."))
                {
                    var domain = line.Remove(0,line.IndexOf(".") + 1).Trim();
                    if (domain.Contains("."))
                    {
                        yield return domain;
                    }
                }
            }
        }
    }
}