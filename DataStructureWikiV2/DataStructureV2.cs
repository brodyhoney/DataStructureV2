using System.IO;
using System.Text;
using System.Diagnostics;
namespace DataStructureWikiV2
{
    public partial class DataStructureWikiV2 : Form
    {
        public DataStructureWikiV2()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>(); // 6.2 List of Information class objects
        string[] comboCategories = { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" }; // 6.4 Global string array to populate combo box
        #region: Buttons
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (!AnyAttributesEmpty())
            {
                if (!ValidName(textBox_Name.Text)) // Checks for duplicates
                {
                    Information info = new Information(textBox_Name.Text, comboBox_Category.Text, GetRadioButtonOutput(), textBox_Definition.Text);
                    Wiki.Add(info);
                    DisplayWiki();
                    ClearAttributes();
                    toolStripStatus.Text = "Structure added";
                }
                else
                {
                    toolStripStatus.Text = "That structure is already in the list";
                    ClearAttributes();
                }
            }
            else
            {
                toolStripStatus.Text = "One or more attributes are empty";
                ClearAttributes();
            }
        } // 6.3 Add new record to list
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            openFile.Filter = "Data files|*.dat; *.bin";
            openFile.DefaultExt = ".dat";
            DialogResult dr = openFile.ShowDialog();
            string fileName = openFile.FileName;
            if (dr == DialogResult.OK)
            {
                OpenList(fileName);
                toolStripStatus.Visible = true;
                toolStripStatus.Text = "File '" + fileName + "' successfully opened";
            }
            
        }// 6.14 Open binary file
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveList();
        }// 6.14 Save binary file
        private void Btn_Del_Click(object sender, EventArgs e)
        { 
            TextWriterTraceListener tr = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(tr);
            Trace.WriteLine("START: Debugging Delete button");
            if (listView_Wiki.SelectedItems.Count > 0)
            {
                Trace.Indent();
                Trace.WriteLine("Delete clicked and item is selected");
                DialogResult dr = MessageBox.Show("Are you sure you want to remove this item?", "Removal Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Trace.WriteLine("User prompted by message box");
                    Trace.WriteLine("ANSWER: " + dr);
                    Trace.WriteLineIf(dr == DialogResult.No, "ANSWER: " + dr + ", operation cancelled");
                    Trace.WriteLineIf(dr == DialogResult.Yes, "Item to delete: " + Wiki[listView_Wiki.SelectedIndices[0]].Name);
                    Wiki.Remove(Wiki[listView_Wiki.SelectedIndices[0]]); // Removes selected item
                    Trace.WriteLineIf(dr == DialogResult.Yes, "Selected item removed, method working correctly");
                    Trace.Unindent();
                    Trace.WriteLine("END: Debugging Delete button complete");
                    Trace.Flush();
                    DisplayWiki(); // Updates list view
                    ClearAttributes();
                    toolStripStatus.Text = "Item removed";
                }
            }
            else
            {
                Trace.WriteLineIf(!(listView_Wiki.SelectedItems.Count > 0), "No item selected, nothing to delete");
                Trace.WriteLine("END: Debugging Delete button complete");
                Trace.Flush();
                toolStripStatus.Text = "Nothing selected";
            }
            

        }// 6.7 Deleted selected record from the list
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            TextWriterTraceListener tr = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(tr);
            Trace.WriteLine("START: Debugging Edit button");
            Trace.Indent();
            if (listView_Wiki.SelectedItems.Count > 0)
            {
                if (!AnyAttributesEmpty()) // Check if any of the attributes are empty
                {
                    if (!ValidName(textBox_Name.Text)) // Check that a duplicate is not being added
                    {
                        Trace.WriteLine("Item to edit: " + Wiki[listView_Wiki.SelectedIndices[0]].Name);
                        Wiki[listView_Wiki.SelectedIndices[0]].Name = textBox_Name.Text;
                        Wiki[listView_Wiki.SelectedIndices[0]].Category = comboBox_Category.Text;
                        Wiki[listView_Wiki.SelectedIndices[0]].Structure = GetRadioButtonOutput();
                        Wiki[listView_Wiki.SelectedIndices[0]].Definition = textBox_Definition.Text;
                        Trace.WriteLine("Item "+textBox_Name.Text+" successfully edited, method working correctly");
                        Trace.Unindent();
                        Trace.WriteLine("END: Debugging Edit button complete");
                        Trace.Flush();
                        DisplayWiki();
                        ClearAttributes();
                        toolStripStatus.Text = "Item edited";
                    }
                    else
                    {
                        Trace.WriteLineIf(!ValidName(textBox_Name.Text), "Can't edit, duplicate detected");
                        Trace.Unindent();
                        Trace.WriteLine("END: Debugging Edit button complete");
                        Trace.Flush();
                        toolStripStatus.Text = "That structure is already in the list";
                        ClearAttributes();
                    }
                }
                else
                {
                    Trace.WriteLineIf(!AnyAttributesEmpty(), "Can't edit, one or more attributes are empty");
                    Trace.Unindent();
                    Trace.WriteLine("END: Debugging Edit button complete");
                    Trace.Flush();
                    toolStripStatus.Text = "One or more attributes are empty";
                    ClearAttributes();
                }
                
            }
            else
            {
                Trace.WriteLineIf(!(listView_Wiki.SelectedItems.Count > 0), "No item selected, nothing to edit");
                Trace.Unindent();
                Trace.WriteLine("END: Debugging Edit button complete");
                Trace.Flush();
                toolStripStatus.Text = "Nothing selected";
            }
        }// 6.8 Edit selected record 
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string target = searchBox.Text;
            if (!string.IsNullOrEmpty(target))
            {
                int index = Wiki.BinarySearch(new Information { Name = target });
                if (index < 0)
                {
                    toolStripStatus.Text = "Item not found";
                    searchBox.Clear();
                }
                else
                {
                    SelectListViewItem(index);
                    toolStripStatus.Text = "Item found";
                    searchBox.Clear();
                }
            }
            else
            {
                toolStripStatus.Text = "Search box is empty";
            }
        }// 6.10 Binary search using built-in method
        #endregion
        #region: UtilityMethods
        private void DisplayWiki()
        {
            listView_Wiki.Items.Clear();
            Wiki.Sort();
            foreach (Information info in Wiki)
            {
                string[] Category = { info.Category };
                listView_Wiki.Items.Add(info.Name).SubItems.AddRange(Category);
            }


        }// 6.9 Method that will sort and display Name and Category
        public string GetRadioButtonOutput()
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
        }// 6.6 Method that returns radio button as a string
        public void HighlightRadioBtn(int index)
        {
            if (index == 0)
            {
                radioButton_Linear.Checked = true;
            }
            else if (index == 1)
            {
                radioButton_NonLinear.Checked = true;
            }
        }// 6.6 Method that takes an index to highlight appropriate radio button
        public void SelectListViewItem(int index)
        {
            if (index >= 0)
            {
                listView_Wiki.Items[index].Selected = true;

                textBox_Name.Text = Wiki[index].Name; // Sets name textbox to selected item's name
                comboBox_Category.Text = Wiki[index].Category; // Sets combobox current item to selected item's category
                textBox_Definition.Text = Wiki[index].Definition; // Sets definition textbox to selected item's definition
                toolStripStatus.Text = "Item '" + Wiki[index].Name + "' selected";
                // If statement that determines whether selected item's structure
                // is linear or non-linear, then sends an integer value to highlight radio button method
                if (Wiki[index].Structure.Equals("Linear"))
                {
                    HighlightRadioBtn(0);
                }
                else if (Wiki[index].Structure.Equals("Non-Linear"))
                {
                    HighlightRadioBtn(1);
                }
            }
        }
        private void ListView_Wiki_Click(object sender, EventArgs e)
        {
            SelectListViewItem(listView_Wiki.SelectedIndices[0]);
        }// 6.11 Event to select record from list and display it's attributes
        private bool ValidName(string n)
        {
            /*TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(tr1);
            Trace.WriteLine("START: Debugging ValidName() Method");
            Trace.Indent();
            Trace.WriteLine("Testing for duplicates of '" + n + "'.");*/
            
            if (Wiki.Exists(info => info.Name == n))
            {
                /*Trace.WriteLineIf(Wiki.Exists(info => info.Name == n), n+" has a duplicate");
                Trace.WriteLine("Duplicates prevented, method functioning correctly");
                Trace.Unindent();
                Trace.WriteLine("END: Debugging of ValidName() Method complete");
                Trace.Flush();
                Console.ReadLine();*/
                return true;
            }
            else
            {
                /*Trace.WriteLineIf(!(Wiki.Exists(info => info.Name == n)), n+" has no duplicate");
                Trace.WriteLine("No duplicates detected, method functioning correctly");
                Trace.Unindent();
                Trace.WriteLine("END: Debugging of ValidName() Method complete");
                Trace.Flush();
                Console.ReadLine();*/
                return false;
            }
            
        }// 6.5 Method that uses List.Exists to determine if a duplicate exists
        private void ClearAttributes()
        {
            textBox_Name.Clear();
            textBox_Definition.Clear();
            radioButton_Linear.Checked = false;
            radioButton_NonLinear.Checked = false;
            comboBox_Category.SelectedItem = null;
        }// 6.12 Method that clears all attribute boxes
        private bool AnyAttributesEmpty()
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
            else if (radioButton_Linear.Checked == false && radioButton_NonLinear.Checked == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }// Method that checks for empty attributes
        private void TextBox_Name_DoubleClick(object sender, EventArgs e)
        {
            ClearAttributes();
        }// 6.13 Double click event that clears all attribute boxes
        
        #endregion
        #region: FileIO
        private void DataStructureWikiV2_Load(object sender, EventArgs e)
        {
            foreach (var category in comboCategories)
            {
                comboBox_Category.Items.Add(category);
            }
            OpenList("dataStrWiki_defaultList.dat");

        }// A default list is loaded upon program start
        private void DataStructureWikiV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* Gives user option to save a new file or overwrite an existing one
            DialogResult dr = MessageBox.Show("Do you wish to save the current list?", "Save Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                SaveList();
            }
            */
            // Save current list to a default list
            try
            {
                using (var stream = File.Open("dataStrWiki_defaultList.dat", FileMode.Create)) // Overwrite default list with current list
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }


        }// 6.15 Data is saved on program exit (if the user chooses to)
        private void OpenList(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (var stream = File.Open(fileName, FileMode.Open))
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                        {
                            Wiki.Clear();
                            while (stream.Position < stream.Length)
                            {
                                Information readInfo = new Information(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString());
                                Wiki.Add(readInfo);
                            }
                            toolStripStatus.Text = "File '" + fileName + "' successfully opened";
                        }
                    }
                    Wiki.Sort();
                    DisplayWiki();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }// Method to read a binary file to the List
        private void SaveList()
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = Application.StartupPath;
                saveFile.Filter = "Data Files |*.dat; *.bin";
                saveFile.DefaultExt = ".dat";
                saveFile.AddExtension = true;
                saveFile.ShowDialog();
                string fileName = saveFile.FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    using (var stream = File.Open(fileName, FileMode.Create))
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
                            toolStripStatus.Visible = true;
                            toolStripStatus.Text = "File '" + fileName + "' saved successfully";
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

                
            
        }// Method to write current list to a new or existing binary file

        #endregion
    }




}
