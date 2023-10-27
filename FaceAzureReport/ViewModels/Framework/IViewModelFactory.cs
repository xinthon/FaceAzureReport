using FaceAzureReport.ViewModels.Components;
using FaceAzureReport.ViewModels.Dialogs;

namespace FaceAzureReport.ViewModels.Framework
{
    public interface IViewModelFactory
    {
        BalanceSheetStandardViewModel CreateBalanceSheetStandardViewModel();
        SettingViewModel CreateSettingViewModel();
    }
}
