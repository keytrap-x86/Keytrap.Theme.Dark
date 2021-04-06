﻿using Keytrap.Theme.Dark.Tools;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Keytrap.Theme.Dark.Themes
{
    public class SharedResourceDictionary : ResourceDictionary
    {
        public static Dictionary<Uri, ResourceDictionary> SharedDictionaries = new Dictionary<Uri, ResourceDictionary>();

        private Uri _sourceUri;

        public new Uri Source
        {
            get => DesignerHelper.IsInDesignMode ? base.Source : _sourceUri;
            set
            {
                if (value == null) return;
                if (DesignerHelper.IsInDesignMode)
                {
                    base.Source = value;
                    return;
                }
                _sourceUri = value;

                if (!SharedDictionaries.ContainsKey(value))
                {
                    base.Source = value;
                    SharedDictionaries.Add(value, this);
                }
                else
                {
                    MergedDictionaries.Add(SharedDictionaries[value]);
                }
            }
        }
    }
}
