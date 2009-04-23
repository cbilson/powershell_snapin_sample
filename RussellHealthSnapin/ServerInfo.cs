using System;
using System.IO;

namespace RussellHealthSnapin
{
    public class ServerInfo
    {
        public string Name { get; set; }
        public string HostName { get; set; }
        public short Port { get; set; }
        public string AdminShare { get; set; }
        public string IIsPhysicalRoot { get; set; }

        public string GetIIsPhysicalRoot()
        {
            return Path.Combine(AdminShare, IIsPhysicalRoot);
        }
        public Uri GetBaseUri()
        {
            return new Uri(String.Format("http://{0}:{1}/", HostName, Port));
        }
    }
}
