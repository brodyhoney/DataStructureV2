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
            info.gsName = textBox_Name.Text;
            info.gsCategory = comboBox_Category.Text;
            Wiki.Add(info);
            DisplayWiki();

        }

        private void DisplayWiki()
        {
            listView_Wiki.Items.Clear();
            foreach (Information info in Wiki)
            {
                listView_Wiki.Items.Add(info.gsName + "\t" + info.gsCategory);
            }
        }
    }
}