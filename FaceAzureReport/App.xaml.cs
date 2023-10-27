using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FaceAzureReport
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
    }

    public partial class App
    {
        public static void SetFontFamily(string fontName) => Current.Resources["FontFamily"] = fontName;
        public static void SetFontSize(int size) => Current.Resources["FontSize"] = size; 
    }
}
