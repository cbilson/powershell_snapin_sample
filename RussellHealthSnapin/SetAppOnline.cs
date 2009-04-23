using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace RussellHealthSnapin
{
    [Cmdlet(VerbsCommon.Set, "AppOnline")]
    public class SetAppOnline : PSCmdlet
    {
        public SetAppOnline()
        {
            AppName = "Foo";
            Server = "dev";
        }

        [Parameter]
        public string AppName { get; set; }

        [Parameter]
        public string Server { get; set; }

        protected override void ProcessRecord()
        {
            var server = SnapIn.LookupServer(Server);
            var app = SnapIn.LookupApp(AppName);
            var path = Path.Combine(app.GetPhysicalRoot(server), "App_Offline.htm");

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
