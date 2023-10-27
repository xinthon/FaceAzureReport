
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FaceAzureReport.ViewModels.Framework
{
    public class DialogManager : IDisposable
    {
        private readonly IViewManager _viewManager;
        private readonly SemaphoreSlim _dialogLock = new(1, 1);

        public DialogManager(IViewManager viewManager) { _viewManager = viewManager; }

        public async ValueTask<T?> ShowDialogAsync<T>(DialogScreen<T> dialogScreen)
        {
            var view = _viewManager.CreateAndBindViewForModelIfNecessary(dialogScreen);

            await _dialogLock.WaitAsync();
            try
            {
                return dialogScreen.DialogResult;
            } finally
            {
                _dialogLock.Release();
            }
        }


        public void Dispose() { _dialogLock.Dispose(); }
    }
}
