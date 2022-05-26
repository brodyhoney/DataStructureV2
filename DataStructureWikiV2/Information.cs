using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiV2
{
    internal class Information : IComparable
    {
        private string Name;
        private string Category;
        private string Structure;
        private string Definition;

        public Information() // default constructor
        { }

        /*public Information(string nameOfStructure, string structureCategory, string structureType, string structureDefinition) // constructor with four arguments
        {
            this.Name = nameOfStructure;
            this.Category = structureCategory;
            this.Structure = structureType;
            this.Definition = structureDefinition;
        }*/

        // Getters and setters
        
        public string getName()
        {
            return this.Name;
        }

        public string setName(string name)
        {
            this.Name = name;
            return this.Name;
        }

        public string getCategory()
        {
            return this.Category;
        }

        public string setCategory(string category)
        {
            this.Category = category;
            return this.Category;
        }

        public string getStructure()
        {
            return this.Structure;
        }

        public string setStructure(string structure)
        {
            this.Structure = structure;
            return this.Structure;
        }

        public string getDefinition()
        {
            return this.Definition;
        }

        public string setDefinition(string definition)
        {
            this.Definition = definition;
            return this.Definition;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Information otherInfo = obj as Information;
            if (otherInfo != null)
                return this.Name.CompareTo(otherInfo.getName());
            else
                throw new ArgumentException("Object is not an Information type object");
        }
    }
}
