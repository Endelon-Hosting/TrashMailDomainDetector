// Author: Dalk
// Github Username: Dalk-Github
// You can use this in your service without any credits.
using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace TrashMailDomainDetector
{
    public static class TrashMailDomainDetector
    {
        private static bool _downloaded = false;

        public static string[] TRASH_DOMAINS = new string[]
        {};
        public static bool IsTrashEmail(string mail)
        {
            if (!_downloaded)
            {
                DownloadData();
            }

            return TRASH_DOMAINS.Contains(mail.Split('@')[1]);
        }

        private static void DownloadData()
        {
            WebClient wc = new WebClient();
            var lines = wc.DownloadString("https://raw.githubusercontent.com/Endelon-Hosting/TrashMailDomainDetector/main/trashmail_domains.md").Replace("\r\n", "\n").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            TRASH_DOMAINS = GetDomains(lines).ToArray();

            _downloaded = true;
        }



        private static IEnumerable<string> GetDomains(string[] lines)
        {
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Contains("."))
                    {
                        var domain = line.Remove(0, line.IndexOf(".") + 1).Trim();
                        if (domain.Contains("."))
                        {
                            yield return domain;
                        }
                    }
                }
            }
        }
    }
}
