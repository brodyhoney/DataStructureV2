namespace DataStructureWikiV2
{
    public partial class DataStructureWikiV2 : Form
    {
        public DataStructureWikiV2()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>();
        string[] comboCategories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" };

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.setName(textBox_Name.Text);
            info.setCategory(comboBox_Category.Text);
            info.setDefinition(textBox_Definition.Text);
            info.setStructure(radioBtnClick());
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
        }

        public string radioBtnClick()
        {
            string selected;
            if (radioButton_Linear.Checked == true)
            {
                return selected = radioButton_Linear.Text;
            }
            else if(radioButton_NonLinear.Checked == true)
            {
                return selected = radioButton_NonLinear.Text;
            }
            else
            {
                return selected = "Nothing selected";
            }
        }

        private void listView_Wiki_Click(object sender, EventArgs e)
        {
            textBox_Name.Text = listView_Wiki.SelectedItems[0].Text;
            comboBox_Category.SelectedValue = listView_Wiki.SelectedItems[0].Text;
        }

        private void DataStructureWikiV2_Load(object sender, EventArgs e)
        {
            foreach(var category in comboCategories)
            {
                comboBox_Category.Items.Add(category);
            }
            
        }
    }
}