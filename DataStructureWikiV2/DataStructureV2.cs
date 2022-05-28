using System.Text;

namespace DataStructureWikiV2
{
    public partial class DataStructureWikiV2 : Form
    {
        public DataStructureWikiV2()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>(); // List of Information class objects
        string[] comboCategories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" }; // Global string array to populate combo box
        #region: Buttons
        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            
            if (duplicateExists(textBox_Name.Text) == false) // Checks for duplicates
            {
                /*info.setName(textBox_Name.Text);
                info.setCategory(comboBox_Category.Text);
                info.setDefinition(textBox_Definition.Text);
                info.setStructure(getRadioButtonOutput());*/
                Information info = new Information(textBox_Name.Text, comboBox_Category.Text, getRadioButtonOutput(), textBox_Definition.Text);
                Wiki.Add(info);
                DisplayWiki();
                clearAttributes();
                
            }
            else
            {
                statusStrip.Text = "That structure is already in the list";
            }
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            DialogResult dr = openFile.ShowDialog();

            if (dr == DialogResult.OK)
            {
                openList();
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Application.StartupPath;
            DialogResult dr = saveFile.ShowDialog();
            using (var stream = File.Open("dataStrWiki.dat", FileMode.Create))
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
        private void btn_Del_Click(object sender, EventArgs e)
        {

            if (listView_Wiki.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to remove this item?", "Removal Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Wiki.Remove(Wiki[listView_Wiki.SelectedIndices[0]]); // Removes selected item
                    DisplayWiki(); // Updates list view
                    clearAttributes();
                    statusStrip.Text = "Item removed";
                }
            }
            else
            {
                statusStrip.Text = "Nothing selected";
            }

        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (listView_Wiki.SelectedItems.Count > 0)
            {
                Wiki[listView_Wiki.SelectedIndices[0]].setName(textBox_Name.Text);
                Wiki[listView_Wiki.SelectedIndices[0]].setCategory(comboBox_Category.Text);
                Wiki[listView_Wiki.SelectedIndices[0]].setStructure(getRadioButtonOutput());
                Wiki[listView_Wiki.SelectedIndices[0]].setDefinition(textBox_Definition.Text);
                DisplayWiki();
                clearAttributes();
            }
            else
            {
                statusStrip.Text = "Nothing selected";
            }
        }
        #endregion
        #region: UtilityMethods
        private void DisplayWiki()
        {
            listView_Wiki.Items.Clear();
            foreach (Information info in Wiki)
            {
                string[] Category = { info.getCategory() };
                listView_Wiki.Items.Add(info.getName()).SubItems.AddRange(Category);
            }
            Wiki.Sort();

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
            openList();

        }
        private void openList()
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
                            Information readInfo = new Information(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString());
                            /*readInfo.setName(reader.ReadString());
                            readInfo.setCategory(reader.ReadString());
                            readInfo.setStructure(reader.ReadString());
                            readInfo.setDefinition(reader.ReadString());*/

                            Wiki.Add(readInfo);

                        }

                    }

                }
                DisplayWiki();
                Wiki.Sort();
            }
        }
        private bool duplicateExists(string n)
        {
            if (Wiki.Exists(x => x.getName() == n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void clearAttributes()
        {
            textBox_Name.Clear();
            textBox_Definition.Clear();
            radioButton_Linear.Checked = false;
            radioButton_NonLinear.Checked = false;
            comboBox_Category.SelectedItem = null;
        }

    }
    #endregion





}
