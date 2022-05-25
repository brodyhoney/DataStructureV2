namespace DataStructureWikiV2
{
    public partial class DataStructureWikiV2 : Form
    {
        public DataStructureWikiV2()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.setName(textBox_Name.Text);
            info.setCategory(comboBox_Category.Text);
            info.
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
    }
}