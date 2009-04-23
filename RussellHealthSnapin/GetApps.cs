using System.Management.Automation;

namespace RussellHealthSnapin
{
    [Cmdlet(VerbsCommon.Get, "Apps")]
    public class GetApps : Cmdlet
    {
        protected override void ProcessRecord()
        {
            foreach (var app in SnapIn.Apps)
                WriteObject(app);
        }
    }
}
