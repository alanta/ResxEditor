using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Resources;

namespace ResxEditor
{
   [Serializable()]
   class TextResourceCollection : SortedList< string, TextResource>, ITypedList, IBindingList, ICustomTypeDescriptor
   {
      public TextResourceCollection( string[] files ) : base(StringComparer.OrdinalIgnoreCase)
        {
         LoadFromFiles( files );
         // Prepare custom type info
         List<PropertyDescriptor> pdc = new List<PropertyDescriptor>();

         PropertyDescriptorCollection realpdc = TypeDescriptor.GetProperties( typeof( TextResource ) );
         pdc.Add( realpdc[ "Name" ] );

         foreach ( string cultureId in cultures.Keys )
         {
            string displayName = cultureId;
            if ( cultureId == "Default" )
            {
               pdc.Insert( 1, new NamedIndexerPropertyDescriptor( cultureId, displayName ) );
            }
            else
            {
               displayName = CultureInfo.GetCultureInfo( cultureId ).DisplayName;
               pdc.Add( new NamedIndexerPropertyDescriptor( cultureId, displayName ) );
            }
            
         }

         // Sort the properties.
         properties = new PropertyDescriptorCollection( pdc.ToArray() );

         isDirty = false; // clear dirty flag
      }

      private void LoadFromFiles( string[] fileNames )
      {
         cultures = new SortedList<string, string>();

         foreach ( string file in fileNames )
         {
            ResXResourceSet doc = new ResXResourceSet( file );
            string key = getCultureFromFileName( file );
            cultures.Add( key, file );

            foreach( DictionaryEntry item in doc )
            {
               if ( item.Value is string )
               {
                  this[ (string)item.Key ][ key ] = (string)item.Value;
               }
            }
         }
      }

      private static string getCultureFromFileName( string fileName )
      {
         string locale = Path.GetFileNameWithoutExtension( fileName ); // strip off .resx
         locale = Path.GetExtension( locale ); // what remains is the locale; nothing is default
         if ( locale.Length == 0 )
         {
            locale = "Default";
         }
         else
         {
            locale = locale.TrimStart( '.' );
         }
         return locale;
      }

      public void Save()
      {
         if ( isDirty )
         {
            foreach ( string key in cultures.Keys )
            {
               
               
               try
               {
                  string backupFile = Path.GetFileNameWithoutExtension( cultures[ key ] ) + ".bak.xml";
                  if ( File.Exists( backupFile ) )
                     File.Delete( backupFile );

                  File.Move( cultures[ key ], backupFile );

                  using ( ResXResourceWriter writer = new ResXResourceWriter( cultures[ key ] ) )
                  {
                     foreach ( TextResource resource in Values )
                     {
                        resource.Write( key, writer, key=="Default" );
                     }
                  }
                  
               }
               catch ( Exception ex )
               {
                  throw new ApplicationException( "Unable to save " + cultures[ "key" ], ex );
               }
            }
         }
      }

      public string[] Cultures
      {
         get { return (string[])cultures.Keys; }
      }

      SortedList<string, string> cultures;

      public new TextResource this[ string name ]
      {
         get 
         {
            TextResource resource = null;
            if ( !TryGetValue( name, out resource ) )
            {
               resource = new TextResource( name );
               resource.PropertyChanged += new PropertyChangedEventHandler( resource_PropertyChanged );
               Add( name, resource );
            }
            return resource;
         }
      }

      void resource_PropertyChanged( object sender, PropertyChangedEventArgs e )
      {
         isDirty = true;
      }

      private bool isDirty;

      public bool IsDirty
      {
         get { return isDirty; }
      }
	
      #region ITypedList Implementation
      
      public virtual PropertyDescriptorCollection GetItemProperties( PropertyDescriptor[] listAccessors )
      {
         PropertyDescriptorCollection pdc = null;

         if ( null == listAccessors )
         {
            // Return properties in sort order.
            pdc = properties;
         }
         else
         {
            // Return child list shape.
            pdc = ListBindingHelper.GetListItemProperties( listAccessors[ 0 ].PropertyType );
         }

         return pdc;
      }

      // This method is only used in the design-time framework 
      // and by the obsolete DataGrid control.
      public virtual string GetListName( PropertyDescriptor[] listAccessors )
      {
         return typeof( TextResourceCollection ).Name;
      }

      [NonSerialized()]
      private PropertyDescriptorCollection properties;

      #region IBindingList Members

      void IBindingList.AddIndex( PropertyDescriptor property )
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      object IBindingList.AddNew()
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      bool IBindingList.AllowEdit
      {
         get { return true; }
      }

      bool IBindingList.AllowNew
      {
         get { return false; }
      }

      bool IBindingList.AllowRemove
      {
         get { return false; }
      }

      void IBindingList.ApplySort( PropertyDescriptor property, ListSortDirection direction )
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      int IBindingList.Find( PropertyDescriptor property, object key )
      {
         int index = 0;
         foreach ( TextResource resource in Values )
         {
            if ( property.GetValue( resource ).Equals( key ) )
            {
               return index;
            }
            index++;
         }
         return -1;
      }

      bool IBindingList.IsSorted
      {
         get { return false; }
      }

      event ListChangedEventHandler IBindingList.ListChanged
      {
         add { throw new Exception( "The method or operation is not implemented." ); }
         remove { throw new Exception( "The method or operation is not implemented." ); }
      }

      void IBindingList.RemoveIndex( PropertyDescriptor property )
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      void IBindingList.RemoveSort()
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      ListSortDirection IBindingList.SortDirection
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      PropertyDescriptor IBindingList.SortProperty
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      bool IBindingList.SupportsChangeNotification
      {
         get { return false; }
      }

      bool IBindingList.SupportsSearching
      {
         get { return true; }
      }

      bool IBindingList.SupportsSorting
      {
         get { return false; }
      }

      #endregion

      #region IList Members

      int System.Collections.IList.Add( object value )
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      void System.Collections.IList.Clear()
      {
         Clear();
      }

      bool System.Collections.IList.Contains( object value )
      {
         TextResource resource = value as TextResource;
         if ( resource != null )
         {
            return ContainsKey( resource.Name );
         }
         return false;
      }

      int System.Collections.IList.IndexOf( object value )
      {
         return IndexOfKey( value as string );
      }

      void System.Collections.IList.Insert( int index, object value )
      {
         throw new NotImplementedException();
      }

      bool System.Collections.IList.IsFixedSize
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      bool System.Collections.IList.IsReadOnly
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      void System.Collections.IList.Remove( object value )
      {
         TextResource resource = value as TextResource;
         if ( resource != null )
         {
            Remove( resource.Name );
         }
      }

      void System.Collections.IList.RemoveAt( int index )
      {
         RemoveAt( index );
      }

      object System.Collections.IList.this[ int index ]
      {
         get
         {
            return this.Values[ index ];
         }
         set
         {
            this.Values[ index ] = value as TextResource;
         }
      }

      #endregion

      #region ICollection Members

      void System.Collections.ICollection.CopyTo( Array array, int index )
      {
         throw new Exception( "The method or operation is not implemented." );
      }

      int System.Collections.ICollection.Count
      {
         get { return Count; }
      }

      bool System.Collections.ICollection.IsSynchronized
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      object System.Collections.ICollection.SyncRoot
      {
         get { throw new Exception( "The method or operation is not implemented." ); }
      }

      #endregion

      #region IEnumerable Members

      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      #endregion

      #region ICustomTypeDescriptor Members

      AttributeCollection ICustomTypeDescriptor.GetAttributes()
      {
         return TypeDescriptor.GetAttributes( typeof( TextResource ) );
      }

      string ICustomTypeDescriptor.GetClassName()
      {
         return typeof( TextResource ).FullName;
      }

      string ICustomTypeDescriptor.GetComponentName()
      {
         return typeof( TextResource ).FullName;
      }

      TypeConverter ICustomTypeDescriptor.GetConverter()
      {
         return TypeDescriptor.GetConverter( typeof( TextResource ) );
      }

      EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
      {
         return TypeDescriptor.GetDefaultEvent( typeof( TextResource ) );
      }

      PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
      {
         return properties[ "Name" ];
      }

      object ICustomTypeDescriptor.GetEditor( Type editorBaseType )
      {
         return TypeDescriptor.GetEditor( typeof( TextResource ), editorBaseType );
      }

      EventDescriptorCollection ICustomTypeDescriptor.GetEvents( Attribute[] attributes )
      {
         return TypeDescriptor.GetEvents( typeof( TextResource ), attributes );
      }

      EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
      {
         return TypeDescriptor.GetEvents( typeof( TextResource ) );
      }

      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties( Attribute[] attributes )
      {
         return properties;
      }

      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
      {
         return properties;
      }

      object ICustomTypeDescriptor.GetPropertyOwner( PropertyDescriptor pd )
      {
         throw new NotImplementedException();
      }

      #endregion
   }
      #endregion
}
