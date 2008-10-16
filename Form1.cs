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
         dataGridView1.Visible = false;
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
         if ( !WarnUnsavedChanges() )
         {
            LoadFiles( openFileDialog1.FileNames );
         }
      }

      private void LoadFiles( string[] files )
      {
         dataGridView1.Visible = true;
         dataGridView1.Columns.Clear();
         dataGridView1.AutoGenerateColumns = true;
         dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
         dataGridView1.RowTemplate = new DataGridViewRow();
         dataGridView1.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.AllCells | DataGridViewAutoSizeColumnsMode.Fill );
         resources = new TextResourceCollection( files );
         dataGridView1.DataSource = resources;

         float fillWeight = ( 1F / (dataGridView1.Columns.Count + 1) );

         foreach ( DataGridViewColumn col in dataGridView1.Columns )
         {
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if ( col.Name == "Name" )
            {
               col.FillWeight = fillWeight;
               col.ReadOnly = true;
            }
            else
            {
               col.FillWeight = fillWeight;
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
         bool cancel = WarnUnsavedChanges();
         if ( !cancel )
            Close();
      }

      private bool WarnUnsavedChanges()
      {
         bool cancel = false;
         if ( null != resources && resources.IsDirty )
         {
            DialogResult result = MessageBox.Show( Help.Warning_Unsaved_Changes, Help.Warning_Unsaved_Changes_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning );
            if ( result == DialogResult.Yes )
            {
               resources.Save();
            }

            if ( result == DialogResult.Cancel )
            {
               cancel = true;
            }
         }
         return cancel;
      }

      private void saveToolStripMenuItem_Click( object sender, EventArgs e )
      {
         try
         {
            resources.Save();
         }
         catch ( Exception ex )
         {
            MessageBox.Show( ex.Message, Help.Error_Save_Failed, MessageBoxButtons.OK, MessageBoxIcon.Error );
         }
      }

      private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
      {
         AboutBox1 about = new AboutBox1();
         about.ShowDialog();
      }

      private void Form_Closing( object sender, FormClosingEventArgs e )
      {
         e.Cancel = WarnUnsavedChanges();
      }
   }
}