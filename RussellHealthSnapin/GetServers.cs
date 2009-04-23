using System.Management.Automation;

namespace RussellHealthSnapin
{
    [Cmdlet(VerbsCommon.Get, "Servers")]
    public class GetServers : Cmdlet
    {
        protected override void ProcessRecord()
        {
            foreach (var server in SnapIn.Servers)
                WriteObject(server);
        }
    }
}
