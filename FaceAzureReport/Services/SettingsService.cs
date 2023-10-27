using Cogwheel;
using System;
using System.ComponentModel;
using System.IO;
using PropertyChanged;
using Microsoft.Win32;
using System.Collections.Generic;

namespace FaceAzureReport.Services;

[AddINotifyPropertyChangedInterface]
public partial class SettingsService : SettingsBase, INotifyPropertyChanged
{
    public SettingsService() : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.dat"))
    {
        
    }
    
    public bool IsDarkModeEnabled { get; set; } = IsDarkModeEnabledByDefault();
    public string FontFamily { get; set; }
    public int FontSize { get; set; }
}

public partial class SettingsService
{
    private static bool IsDarkModeEnabledByDefault()
    {
        try
        {
            return Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize",
                false
            )?.GetValue("AppsUseLightTheme") is 0;
        }
        catch
        {
            return false;
        }
    }
}
