using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System;

namespace RussellHealthSnapin
{
    [RunInstaller(true)]
    public class SnapIn : PSSnapIn
    {
        public static IList<ServerInfo> Servers { get; set; }
        public static IList<AppInfo> Apps { get; set; }

        static SnapIn()
        {
            Servers = new List<ServerInfo> { 
                new ServerInfo { 
                    Name = "dev",
                    HostName = "localhost",
                    Port = 12080,
                    AdminShare = @"C:\Users\cbilson\Documents\Projects",
                    IIsPhysicalRoot = @"RussellHealthSnapin",
                }
            };

            Apps = new List<AppInfo> { 
                new AppInfo {
                    Name = "HealthyWebApp",
                    PhysicalRoot = "HealthyWebApp",
                    VirtualRoot = "",
                }
            };
        }

        public static ServerInfo LookupServer(string name)
        {
            var server = Servers
                .Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if (server == null)
                throw new ArgumentException(string.Format("I don't know any server named {0}", name), 
                    "Server");

            return server;
        }

        public static AppInfo LookupApp(string name)
        {
            AppInfo app = Apps
                .Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if (app == null)
                throw new ArgumentException(string.Format("I don't know any app named {0}", name), 
                    "AppName");

            return app;
        }

        public override string Name
        {
            get { return "Russell"; }
        }

        public override string Vendor
        {
            get { return "Russell Investments"; }
        }

        public override string Description
        {
            get { return "Gets the health and vitals of a bunch of Russell apps"; }
        }
    }
}
