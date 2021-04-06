﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Keytrap.Theme.Dark.Tools.Helper
{
    public class ResourceHelper
    {

        public static string GetString(string key) => Application.Current.TryFindResource(key) as string;

        public static string GetString(string separator = ";", params string[] keyArr) =>
            string.Join(separator, keyArr.Select(key => Application.Current.TryFindResource(key) as string).ToList());

        public static List<string> GetStringList(params string[] keyArr) => keyArr.Select(key => Application.Current.TryFindResource(key) as string).ToList();


        public static T GetResource<T>(string key)
        {
            if (Application.Current.TryFindResource(key) is T resource)
            {
                return resource;
            }

            return default;
        }
    }
}
