using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace ResxEditor
{
   public partial class Form1 : Form
   {
      TextResourceCollection resources;

      public Form1( string[] args)
      {
         resources = null;
         InitializeComponent();
         if ( args.Length > 0 )
         {
            List<string> files = new List<string>();

            foreach ( string file in args )
            {
               if ( File.Exists( file ) )
               {
                  files.Add( file );
               }
            }

            if ( files.Count > 0 )
            {
               LoadFiles( files.ToArray() );
            }
            else
            {
               dataGridView1.Columns.Clear();
            }
         }
      }

      private void openFileDialog1_FileOk( object sender, CancelEventArgs e )
      {
         LoadFiles( openFileDialog1.FileNames );

      }
      private void LoadFiles( string[] files )
      {
         dataGridView1.Columns.Clear();
         dataGridView1.AutoGenerateColumns = true;
         dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
         dataGridView1.RowTemplate = new DataGridViewRow();
         dataGridView1.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.AllCells | DataGridViewAutoSizeColumnsMode.Fill );
         resources = new TextResourceCollection( files );
         dataGridView1.DataSource = resources;
         foreach ( DataGridViewColumn col in dataGridView1.Columns )
         {
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if ( col.Name == "Name" )
            {
               col.FillWeight = 0.1F;
            }
            else
            {
               col.FillWeight = 0.5F;
            }
         }
      }
      

      private void openToolStripMenuItem_Click( object sender, EventArgs e )
      {
         openFileDialog1.ShowDialog();
      }

      private void textResourceCollectionBindingSource_CurrentChanged( object sender, EventArgs e )
      {

      }

      private void exitToolStripMenuItem_Click( object sender, EventArgs e )
      {
         Close();
      }

      private void Form1_Load( object sender, EventArgs e )
      {

      }

      private void saveToolStripMenuItem_Click( object sender, EventArgs e )
      {
         try
         {
            resources.Save();
         }
         catch ( Exception ex )
         {
            MessageBox.Show( ex.Message, "Unable to save changes", MessageBoxButtons.OK, MessageBoxIcon.Error );
         }
      }

      private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
      {
         AboutBox1 about = new AboutBox1();
         about.ShowDialog();
      }




   }
}