using System.IO;
using System.Management.Automation;

namespace RussellHealthSnapin
{
    [Cmdlet(VerbsCommon.Set, "AppOffline")]
    public class SetAppOffline : PSCmdlet
    {
        public SetAppOffline()
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
                return;

            using (var file = File.CreateText(path))
                file.Write("<html><title>off the air</title><body>come back later</body></html>");
        }
    }
}