using System.Text;

namespace DataStructureWikiV2
{
    public partial class DataStructureWikiV2 : Form
    {
        public DataStructureWikiV2()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>(); // 
        string[] comboCategories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" }; // Global string array to populate combo box
        string fileName = "dataStrWiki.dat";
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.setName(textBox_Name.Text);
            info.setCategory(comboBox_Category.Text);
            info.setDefinition(textBox_Definition.Text);
            info.setStructure(getRadioButtonOutput());
            Wiki.Add(info);
            DisplayWiki();
            textBox_Name.Clear();
        }

        private void DisplayWiki()
        {
            listView_Wiki.Items.Clear();
            foreach (Information info in Wiki)
            {
                string[] Category = { info.getCategory() };
                listView_Wiki.Items.Add(info.getName()).SubItems.AddRange(Category);
            }
            listView_Wiki.Sort();
        }

        public string getRadioButtonOutput()
        {
            string selected;
            if (radioButton_Linear.Checked == true)
            {
                return selected = radioButton_Linear.Text;
            }
            else if (radioButton_NonLinear.Checked == true)
            {
                return selected = radioButton_NonLinear.Text;
            }
            else
            {
                return selected = "Nothing selected";
            }
        }

        public void highlightRadioBtn(int index)
        {
            if (index == 0)
            {
                radioButton_Linear.Checked = true;
            }
            else if (index == 1)
            {
                radioButton_NonLinear.Checked = true;
            }
        }

        private void listView_Wiki_Click(object sender, EventArgs e)
        {
            int index = listView_Wiki.SelectedIndices[0];
            textBox_Name.Text = Wiki[index].getName(); // Sets name textbox to selected item's name
            comboBox_Category.Text = Wiki[index].getCategory(); // Sets combobox current item to selected item's category
            textBox_Definition.Text = Wiki[index].getDefinition(); // Sets definition textbox to selected item's definition

            // If statement that determines whether selected item's structure
            // is linear or non-linear, then sends an integer value to highlight radio button method
            if (Wiki[index].getStructure().Equals("Linear"))
            {
                highlightRadioBtn(0);
            }
            else if (Wiki[index].getStructure().Equals("Non-Linear"))
            {
                highlightRadioBtn(1);
            }
        }

        private void DataStructureWikiV2_Load(object sender, EventArgs e)
        {
            foreach (var category in comboCategories)
            {
                comboBox_Category.Items.Add(category);
            }

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            DialogResult dr = openFile.ShowDialog();
            
            if(dr == DialogResult.OK)
            {
                if (File.Exists("dataStrWiki.dat"))
                {
                    using (var stream = File.Open("dataStrWiki.dat", FileMode.Open))
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                        {
                            Wiki.Clear();
                            while (stream.Position < stream.Length)
                            {
                                Information readInfo = new Information();
                                readInfo.setName(reader.ReadString());
                                readInfo.setCategory(reader.ReadString());
                                readInfo.setStructure(reader.ReadString());
                                readInfo.setDefinition(reader.ReadString());
                                Wiki.Add(readInfo);
                            }
                        }
                    }
                    DisplayWiki();
                }
            
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Application.StartupPath;
            DialogResult dr = saveFile.ShowDialog();
            using(var stream = File.Open("dataStrWiki.dat", FileMode.Create))
            {
                 using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                 {
                    foreach (var info in Wiki)
                    {
                        writer.Write(info.getName());
                        writer.Write(info.getCategory());
                        writer.Write(info.getStructure());
                        writer.Write(info.getDefinition());
                    }
                 }
            }
            
        }
    }
}