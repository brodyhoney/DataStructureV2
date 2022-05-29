namespace DataStructureWikiV2
{
    partial class DataStructureWikiV2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataStructureWikiV2));
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.comboBox_Category = new System.Windows.Forms.ComboBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_Definition = new System.Windows.Forms.Label();
            this.textBox_Definition = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.listView_Wiki = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnCategory = new System.Windows.Forms.ColumnHeader();
            this.groupBox_Structure = new System.Windows.Forms.GroupBox();
            this.radioButton_NonLinear = new System.Windows.Forms.RadioButton();
            this.radioButton_Linear = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Structure.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(12, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "ADD";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(93, 12);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 23);
            this.btn_Del.TabIndex = 1;
            this.btn_Del.Text = "DELETE";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(174, 12);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 2;
            this.btn_Edit.Text = "EDIT";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(12, 41);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(121, 23);
            this.textBox_Name.TabIndex = 3;
            this.textBox_Name.DoubleClick += new System.EventHandler(this.textBox_Name_DoubleClick);
            // 
            // comboBox_Category
            // 
            this.comboBox_Category.FormattingEnabled = true;
            this.comboBox_Category.Location = new System.Drawing.Point(12, 73);
            this.comboBox_Category.MaxDropDownItems = 6;
            this.comboBox_Category.Name = "comboBox_Category";
            this.comboBox_Category.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Category.TabIndex = 4;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(139, 44);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(39, 15);
            this.label_Name.TabIndex = 5;
            this.label_Name.Text = "Name";
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.Location = new System.Drawing.Point(139, 73);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(55, 15);
            this.label_Category.TabIndex = 6;
            this.label_Category.Text = "Category";
            // 
            // label_Definition
            // 
            this.label_Definition.AutoSize = true;
            this.label_Definition.Location = new System.Drawing.Point(12, 175);
            this.label_Definition.Name = "label_Definition";
            this.label_Definition.Size = new System.Drawing.Size(59, 15);
            this.label_Definition.TabIndex = 10;
            this.label_Definition.Text = "Definition";
            // 
            // textBox_Definition
            // 
            this.textBox_Definition.Location = new System.Drawing.Point(12, 193);
            this.textBox_Definition.Multiline = true;
            this.textBox_Definition.Name = "textBox_Definition";
            this.textBox_Definition.Size = new System.Drawing.Size(237, 243);
            this.textBox_Definition.TabIndex = 11;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(12, 442);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(121, 23);
            this.btn_Open.TabIndex = 12;
            this.btn_Open.Text = "OPEN";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(139, 442);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 23);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(270, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(225, 23);
            this.searchBox.TabIndex = 14;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(501, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 15;
            this.btn_Search.Text = "SEARCH";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // listView_Wiki
            // 
            this.listView_Wiki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory});
            this.listView_Wiki.FullRowSelect = true;
            this.listView_Wiki.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Wiki.Location = new System.Drawing.Point(270, 49);
            this.listView_Wiki.MultiSelect = false;
            this.listView_Wiki.Name = "listView_Wiki";
            this.listView_Wiki.Size = new System.Drawing.Size(306, 416);
            this.listView_Wiki.TabIndex = 16;
            this.listView_Wiki.UseCompatibleStateImageBehavior = false;
            this.listView_Wiki.View = System.Windows.Forms.View.Details;
            this.listView_Wiki.Click += new System.EventHandler(this.listView_Wiki_Click);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 149;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 149;
            // 
            // groupBox_Structure
            // 
            this.groupBox_Structure.Controls.Add(this.radioButton_NonLinear);
            this.groupBox_Structure.Controls.Add(this.radioButton_Linear);
            this.groupBox_Structure.Location = new System.Drawing.Point(12, 102);
            this.groupBox_Structure.Name = "groupBox_Structure";
            this.groupBox_Structure.Size = new System.Drawing.Size(237, 73);
            this.groupBox_Structure.TabIndex = 17;
            this.groupBox_Structure.TabStop = false;
            this.groupBox_Structure.Text = "Structure";
            // 
            // radioButton_NonLinear
            // 
            this.radioButton_NonLinear.AutoSize = true;
            this.radioButton_NonLinear.Location = new System.Drawing.Point(127, 32);
            this.radioButton_NonLinear.Name = "radioButton_NonLinear";
            this.radioButton_NonLinear.Size = new System.Drawing.Size(85, 19);
            this.radioButton_NonLinear.TabIndex = 1;
            this.radioButton_NonLinear.TabStop = true;
            this.radioButton_NonLinear.Text = "Non-Linear";
            this.radioButton_NonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButton_Linear
            // 
            this.radioButton_Linear.AutoSize = true;
            this.radioButton_Linear.Location = new System.Drawing.Point(34, 32);
            this.radioButton_Linear.Name = "radioButton_Linear";
            this.radioButton_Linear.Size = new System.Drawing.Size(57, 19);
            this.radioButton_Linear.TabIndex = 0;
            this.radioButton_Linear.TabStop = true;
            this.radioButton_Linear.Text = "Linear";
            this.radioButton_Linear.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 488);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(590, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "Status";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatus.Text = "Status";
            // 
            // DataStructureWikiV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 510);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox_Structure);
            this.Controls.Add(this.listView_Wiki);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.textBox_Definition);
            this.Controls.Add(this.label_Definition);
            this.Controls.Add(this.label_Category);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.comboBox_Category);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataStructureWikiV2";
            this.Text = "DataStructureWikiV2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataStructureWikiV2_FormClosed);
            this.Load += new System.EventHandler(this.DataStructureWikiV2_Load);
            this.groupBox_Structure.ResumeLayout(false);
            this.groupBox_Structure.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Add;
        private Button btn_Del;
        private Button btn_Edit;
        private TextBox textBox_Name;
        private ComboBox comboBox_Category;
        private Label label_Name;
        private Label label_Category;
        private Label label_Definition;
        private TextBox textBox_Definition;
        private Button btn_Open;
        private Button btn_Save;
        private TextBox searchBox;
        private Button btn_Search;
        private ListView listView_Wiki;
        private GroupBox groupBox_Structure;
        private RadioButton radioButton_NonLinear;
        private RadioButton radioButton_Linear;
        private ColumnHeader columnName;
        private ColumnHeader columnCategory;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatus;
    }
}