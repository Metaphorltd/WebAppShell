using CommunityToolkit.Mvvm.Input;
using WebAppShell.Core;

namespace MauiTubePlayer.ViewModels.Base;

public partial class AppViewModelBase : ViewModelBase
{
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }

    [RelayCommand]
    private async Task NavigateBack() =>
        await NavigationService.PopAsync();

    [RelayCommand]
    private async Task CloseModal() =>
        await NavigationService.PopModalAsync();

}

