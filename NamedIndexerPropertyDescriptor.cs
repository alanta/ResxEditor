using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace ResxEditor
{
   class NamedIndexerPropertyDescriptor : PropertyDescriptor
   {
      private string indexer;
      private string displayName;

      public NamedIndexerPropertyDescriptor( string indexer, string displayName )
         : base( displayName, null )
      {
         this.displayName = displayName;
         this.indexer = indexer;
      }

      public string Indexer
      {
         get { return indexer; }
      }

      public override bool CanResetValue( object component )
      {
         return false;
      }

      public override Type ComponentType
      {
         get { return typeof(TextResource); }
      }

      public override object GetValue( object component )
      {
         TextResource item = component as TextResource;
         if ( item != null )
         {
            return item[ indexer ];
         }
         throw new InvalidOperationException( "Expected object of type TextResource" );
      }

      public override bool IsReadOnly
      {
         get { return false; }
      }

      public override Type PropertyType
      {
         get { return typeof( string ); }
      }

      public override void ResetValue( object component )
      {
         
      }

      public override void SetValue( object component, object value )
      {
         TextResource item = component as TextResource;
         if ( item != null )
         {
            item[ indexer ] = value as String;
         }
      }

      public override bool ShouldSerializeValue( object component )
      {
         return true;
      }
   }
}
