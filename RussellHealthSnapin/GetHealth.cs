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
        protected override void ProcessRecord()
        {
            var request = WebRequest.Create("http://localhost:12080/Admin/Health");
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