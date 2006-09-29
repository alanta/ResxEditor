using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Resources;

namespace ResxEditor
{
   [Serializable()]
   public class TextResource 
   {
      public TextResource( string name )
      {
         values = new Dictionary<string, string>();
         this.name = name;
      }

      public string this[ string culture ]
      {
         get
         {
            string result = null; 
            values.TryGetValue( culture, out result );
            return result;
         }
         set
         {
            if ( values.ContainsKey( culture ) )
            {
               if ( values[ culture ] != value )
               {
                  values[ culture ] = value;
                  OnPropertyChanged( culture );
               }
            }
            else
            {
               values.Add( culture, value );
               OnPropertyChanged( culture );
            }
         }
      }

      public string Name
      {
         get { return name; }
         set { name = value; }
      }

      public  void Write( string key, ResXResourceWriter writer, bool neverDiscard )
      {
         if ( this[ key ] != null && this[ key ].Length > 0 || neverDiscard )
         {
            writer.AddResource( name, this[ key ] );
         }
      }

      Dictionary<string, string> values;
      private string name;

		#region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged( string name )
      {
         if ( null != PropertyChanged )
         {
            PropertyChanged( this, new PropertyChangedEventArgs( name ) );
         }
      }

      #endregion
   }
}
