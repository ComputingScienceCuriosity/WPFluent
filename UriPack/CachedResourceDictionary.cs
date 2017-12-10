using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml", "WPFluent.UriPack")]
namespace WPFluent.UriPack
{

    internal class CachedResourceDictionary : ResourceDictionary
    {
        private static Dictionary<Uri, WeakReference> _cache;

        static CachedResourceDictionary()
        {
            _cache = new Dictionary<Uri, WeakReference>();
        }

        private Uri _source;

        public new Uri Source
        {
            get { return _source; }
            set
            {
                _source = value;
                if (!_cache.ContainsKey(_source))
                {
                    AddToCache();
                }
                else
                {
                    WeakReference weakReference = _cache[_source];
                    if (weakReference != null && weakReference.IsAlive)
                    {
                        MergedDictionaries.Add((ResourceDictionary)weakReference.Target);
                    }
                    else
                    {
                        AddToCache();
                    }
                }

            }
        }

        private void AddToCache()
        {
            base.Source = _source;
            if (_cache.ContainsKey(_source))
            {
                _cache.Remove(_source);
            }
            _cache.Add(_source, new WeakReference(this, false));
        }
    }
}
