namespace ResxEditor
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.defaultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.menuStrip1.SuspendLayout();
         ( ( System.ComponentModel.ISupportInitialize )( this.dataGridView1 ) ).BeginInit();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem} );
         this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size( 518, 24 );
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem} );
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size( 35, 20 );
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size( 111, 22 );
         this.openToolStripMenuItem.Text = "&Open";
         this.openToolStripMenuItem.Click += new System.EventHandler( this.openToolStripMenuItem_Click );
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size( 111, 22 );
         this.saveToolStripMenuItem.Text = "&Save";
         this.saveToolStripMenuItem.Click += new System.EventHandler( this.saveToolStripMenuItem_Click );
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size( 111, 22 );
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem} );
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size( 40, 20 );
         this.helpToolStripMenuItem.Text = "Help";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
         this.aboutToolStripMenuItem.Text = "About";
         this.aboutToolStripMenuItem.Click += new System.EventHandler( this.aboutToolStripMenuItem_Click );
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToOrderColumns = true;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.defaultDataGridViewTextBoxColumn} );
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
         dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 0 ) ) );
         dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
         dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
         this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView1.Location = new System.Drawing.Point( 0, 24 );
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size( 518, 276 );
         this.dataGridView1.TabIndex = 1;
         // 
         // nameDataGridViewTextBoxColumn
         // 
         this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
         this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
         this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
         // 
         // defaultDataGridViewTextBoxColumn
         // 
         this.defaultDataGridViewTextBoxColumn.DataPropertyName = "Default";
         this.defaultDataGridViewTextBoxColumn.HeaderText = "Default";
         this.defaultDataGridViewTextBoxColumn.Name = "defaultDataGridViewTextBoxColumn";
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.DefaultExt = "resx";
         this.openFileDialog1.Filter = ".NET Resource Files|*.resx";
         this.openFileDialog1.Multiselect = true;
         this.openFileDialog1.Title = "Open file";
         this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler( this.openFileDialog1_FileOk );
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1} );
         this.statusStrip1.Location = new System.Drawing.Point( 0, 278 );
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size( 518, 22 );
         this.statusStrip1.TabIndex = 2;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size( 174, 17 );
         this.toolStripStatusLabel1.Text = "© 2006 AZ TotaalCommunicatie BV";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 518, 300 );
         this.Controls.Add( this.statusStrip1 );
         this.Controls.Add( this.dataGridView1 );
         this.Controls.Add( this.menuStrip1 );
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Form1";
         this.Text = ".NET 2.0 Resource Editor";
         this.Load += new System.EventHandler( this.Form1_Load );
         this.menuStrip1.ResumeLayout( false );
         this.menuStrip1.PerformLayout();
         ( ( System.ComponentModel.ISupportInitialize )( this.dataGridView1 ) ).EndInit();
         this.statusStrip1.ResumeLayout( false );
         this.statusStrip1.PerformLayout();
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
      private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn defaultDataGridViewTextBoxColumn;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
   }
}

