
using System;

namespace Utilities.Factories
{
    public class PageFactory
    {
        public static T GetPage<T>() where T : new()
        {

            return new T();
        }
        public static T GetPage<T>(object Page)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { Page });
        }
    }
}
