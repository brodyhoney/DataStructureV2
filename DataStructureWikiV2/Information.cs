using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiV2
{
    internal class Information : IComparable<Information>, IComparer<Information>
    {
        public string Name { get; set; }
        public string Category {get; set; }
        public string Structure {get; set; }
        public string Definition {get; set; }

        public Information() // default constructor
        {
            Name = "";
            Category = "";
            Structure = "";
            Definition = "";
        }

        public Information(string strName, string strCategory, string strType, string strDefinition) // constructor with four arguments
        {
            this.Name = strName;
            this.Category = strCategory;
            this.Structure = strType;
            this.Definition = strDefinition;
        }

        public int CompareTo(Information? info)
        {
            if (info == null) return 1;

            Information otherInfo = info as Information;
            if (otherInfo != null)
                return this.Name.CompareTo(otherInfo.Name);
            else
                throw new ArgumentException("Object is not an Information type object");
        }

        public int Compare(Information? x, Information? y)
        {
            return x!.Name.CompareTo(y!.Name);
        }
    }
}
