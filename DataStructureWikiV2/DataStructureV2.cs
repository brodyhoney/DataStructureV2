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
            resetStatusStrip();
            if (anyAttributesEmpty() == false)  
            {
                if (duplicateExists(textBox_Name.Text) == false) // Checks for duplicates
                {
                    Information info = new Information(textBox_Name.Text, comboBox_Category.Text, getRadioButtonOutput(), textBox_Definition.Text);
                    Wiki.Add(info);
                    displayWiki();
                    clearAttributes();
                }
                else
                {
                    statusStrip.Text = "That structure is already in the list";
                }
            }
            else
            {
                statusStrip.Text = "One or more attributes are empty";
            }
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            DialogResult dr = openFile.ShowDialog();
            resetStatusStrip();
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
            resetStatusStrip();
            using (var stream = File.Open("dataStrWiki.dat", FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (var info in Wiki)
                    {
                        writer.Write(info.Name);
                        writer.Write(info.Category);
                        writer.Write(info.Structure);
                        writer.Write(info.Definition);
                    }
                }

            }

        }
        private void btn_Del_Click(object sender, EventArgs e)
        {
            resetStatusStrip();
            if (listView_Wiki.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to remove this item?", "Removal Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Wiki.Remove(Wiki[listView_Wiki.SelectedIndices[0]]); // Removes selected item
                    displayWiki(); // Updates list view
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
            resetStatusStrip();
            if (listView_Wiki.SelectedItems.Count > 0)
            {
                Wiki[listView_Wiki.SelectedIndices[0]].Name = textBox_Name.Text;
                Wiki[listView_Wiki.SelectedIndices[0]].Category = comboBox_Category.Text;
                Wiki[listView_Wiki.SelectedIndices[0]].Structure = getRadioButtonOutput();
                Wiki[listView_Wiki.SelectedIndices[0]].Definition = textBox_Definition.Text;
                displayWiki();
                clearAttributes();
                statusStrip.Text = "Item edited";
            }
            else
            {
                statusStrip.Text = "Nothing selected";
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region: UtilityMethods
        private void displayWiki()
        {
            listView_Wiki.Items.Clear();
            Wiki.Sort();
            foreach (Information info in Wiki)
            {
                string[] Category = { info.Category };
                listView_Wiki.Items.Add(info.Name).SubItems.AddRange(Category);
            }
            

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
            textBox_Name.Text = Wiki[index].Name; // Sets name textbox to selected item's name
            comboBox_Category.Text = Wiki[index].Category; // Sets combobox current item to selected item's category
            textBox_Definition.Text = Wiki[index].Definition; // Sets definition textbox to selected item's definition
            statusStrip.Text = "Item " + Wiki[index].Name + " selected";
            // If statement that determines whether selected item's structure
            // is linear or non-linear, then sends an integer value to highlight radio button method
            if (Wiki[index].Structure.Equals("Linear"))
            {
                highlightRadioBtn(0);
            }
            else if (Wiki[index].Structure.Equals("Non-Linear"))
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
                            Wiki.Add(readInfo);
                        }
                    }
                }
                Wiki.Sort();
                displayWiki();
            }
        }
        private bool duplicateExists(string n)
        {
            if (Wiki.Exists(info => info.Name == n))
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
        private bool anyAttributesEmpty()
        {
            if (string.IsNullOrEmpty(textBox_Name.Text))
            {
                return true;
            }
            else if (string.IsNullOrEmpty(textBox_Definition.Text))
            {
                return true;
            }
            else if (string.IsNullOrEmpty(comboBox_Category.Text))
            {
                return true;
            }
            else if(radioButton_Linear.Checked == false && radioButton_NonLinear.Checked == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void resetStatusStrip()
        {
            statusStrip.Text = "Status";
        }

        
    }
    #endregion





}
