using System;

using SyncfusionWpfApp.Models;

namespace SyncfusionWpfApp.Contracts.Services
{
    public interface IThemeSelectorService
    {
        bool SetTheme(AppTheme? theme = null);

        AppTheme GetCurrentTheme();
    }
}
