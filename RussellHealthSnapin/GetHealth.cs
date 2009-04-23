using System.IO;
using System.Management.Automation;
using System.Net;
using System.Web.Script.Serialization;
using System;

namespace RussellHealthSnapin
{
    [Cmdlet(VerbsCommon.Get, "Health")]
    public class GetHealth : Cmdlet
    {
        public GetHealth()
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

            var url = app.GetHealthUrl(server);

            WriteVerbose(String.Format("Trying {0}...", url));

            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            var serializer = new JavaScriptSerializer();
            using (var stm = response.GetResponseStream())
            using (var reader = new StreamReader(stm))
            {
                var msg = serializer.Deserialize<HealthInfo>(reader.ReadToEnd());
                WriteObject(msg);
            }
        }
    }
}