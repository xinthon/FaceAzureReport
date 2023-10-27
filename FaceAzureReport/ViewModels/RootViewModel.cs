using FaceAzureReport.Services;
using FaceAzureReport.ViewModels.Framework;
using Stylet;

namespace FaceAzureReport.ViewModels;

public class RootViewModel : Conductor<Screen>.Collection.OneActive
{
    private readonly DialogManager _dialogManager;
    private readonly IViewModelFactory _viewModelFactory;
    private readonly SettingsService _settingsService;
    public RootViewModel(DialogManager dialogManager, IViewModelFactory viewModelFactory, SettingsService settingsService)
    {
        _dialogManager = dialogManager;
        _viewModelFactory = viewModelFactory;
        _settingsService = settingsService;

        ShowBalanceSheetStandard();

        DisplayName = "FaceAzure Report";
        ScreenState = ScreenState.Active;
    }

    public void ShowBalanceSheetStandard() => this.ActiveItem = _viewModelFactory.CreateBalanceSheetStandardViewModel();

    public async void ShowSetting() => await _dialogManager.ShowDialogAsync(
        _viewModelFactory.CreateSettingViewModel()
    );

    protected override void OnViewLoaded()
    {
        base.OnViewLoaded();
        _settingsService.Load();

        if (_settingsService.IsDarkModeEnabled)
            DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName = DevExpress.Xpf.Core.Theme.Win11DarkName;
        else
            DevExpress.Xpf.Core.ApplicationThemeHelper.ApplicationThemeName = DevExpress.Xpf.Core.Theme.Win11LightName;
    }

    protected override void OnClose()
    {
        base.OnClose();
        _settingsService.Save();
    }
}
