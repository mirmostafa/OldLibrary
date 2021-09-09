using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace Mohammad.Helpers
{
    public static partial class ApplicationHelper
    {
        private static string _Company;
        public static string ApplicationTitle => CalculatePropertyValue<AssemblyTitleAttribute>("Title");
        public static string ProductTitle => CalculatePropertyValue<AssemblyProductAttribute>("Product");
        public static string Guid => CalculatePropertyValue<GuidAttribute>("Value");

        public static string Version
        {
            get
            {
                // first, try to get the version string from the assembly.
                var version = Assembly.GetEntryAssembly().GetName().Version;
                return version?.ToString() ?? string.Empty;
            }
        }

        public static string Description => CalculatePropertyValue<AssemblyDescriptionAttribute>("Description");
        public static string Copyright => CalculatePropertyValue<AssemblyCopyrightAttribute>("Copyright");
        public static string Company { get { return _Company ?? CalculatePropertyValue<AssemblyCompanyAttribute>("Company"); } set { _Company = value; } }

        private static string CalculatePropertyValue<T>(string propertyName)
        {
            var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(T), false);
            if (attributes.Length <= 0)
                return string.Empty;
            var attrib = (T) attributes[0];
            var property = attrib.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return property != null ? property.GetValue(attributes[0], null) as string : string.Empty;
        }

        public static void StartMeUpWithWindows(string appName, RegistryKey root = null)
        {
            using (var registryKey = (root ?? Registry.CurrentUser).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                registryKey?.SetValue(appName, Environment.CommandLine.Remove("/crashed"));
                registryKey?.Flush();
            }
        }

        public static string GetAboutAppString(string moreInfo = null)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Product:    \t{ProductTitle}");
            builder.AppendLine($"Application:\t{ApplicationTitle}");
            builder.AppendLine($"Version:    \t{Version}");
            builder.AppendLine(Description);
            builder.AppendLine();
            if (!moreInfo.IsNullOrEmpty())
            {
                builder.AppendLine(moreInfo);
                builder.AppendLine();
            }
            builder.AppendLine(Copyright);
            return builder.ToString();
        }
    }
}