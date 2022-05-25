using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiV2
{
    internal class Information
    {
        private string Name;
        private string Category;
        private string Structure;
        private string Definition;

        public Information() // default constructor
        { }

        public Information(string nameOfStructure) // constructor with one argument
        {
            this.Name = nameOfStructure;
        }

        public Information(string nameOfStructure, string structureCategory) // constructor with two arguments
        {
            this.Name = nameOfStructure;
            this.Structure = structureCategory;
        }

        public Information(string nameOfStructure, string structureCategory, string structureType) // constructor with three arguments
        {
            this.Name=nameOfStructure;
            this.Category = structureCategory;
            this.Structure = structureType;
        }

        public Information(string nameOfStructure, string structureCategory, string structureType, string structureDefinition) // constructor with four arguments
        {
            this.Name = nameOfStructure;
            this.Category = structureCategory;
            this.Structure = structureType;
            this.Definition = structureDefinition;
        }

        // Getters and setters
        public string gsName
        {
            get { return Name; }
            set { Name = value; }
        }

        public string gsCategory
        {
            get { return Category; }
            set { Category = value; }
        }

        public string gsStructure
        {
            get { return Structure; }
            set { Structure = value; }
        }

        public string gsDefinition
        {
            get { return Definition; }
            set { Definition = value; }
        }

    }
}
