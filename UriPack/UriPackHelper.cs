using System;
using System.Windows;
using System.Reflection;

namespace WPFluent.UriPack 
{ 
    internal static class UriPackHelper
    {
        #region Methods

        public static Uri ExtractResourceFileUri(this string relativeResourceFile) 
        {
            return new Uri("pack://application:,,,/" + typeof(UriPackHelper).Assembly.GetName().Name.ToString() + ";component/" + relativeResourceFile);
        }

        #endregion 
    }
}
