using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RussellHealthSnapin
{
    public class AppInfo
    {
        public string Name { get; set; }
        public string PhysicalRoot { get; set; }
        public string VirtualRoot { get; set; }

        public Uri GetHealthUrl(ServerInfo server)
        {
            var baseUri = server.GetBaseUri();

            return new Uri(baseUri, VirtualRoot + "/Admin/Health");
        }

        public string GetPhysicalRoot(ServerInfo server)
        {
            return Path.Combine(server.GetIIsPhysicalRoot(), PhysicalRoot);
        }
    }
}