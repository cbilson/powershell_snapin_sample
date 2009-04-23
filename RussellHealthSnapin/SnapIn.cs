using System.ComponentModel;
using System.Management.Automation;

namespace RussellHealthSnapin
{
    [RunInstaller(true)]
    public class SnapIn : PSSnapIn
    {
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
