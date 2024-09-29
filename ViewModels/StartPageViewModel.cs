using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTubePlayer.ViewModels.Base;
using MauiTubePlayer.Views;
using Microsoft.VisualBasic;
using WebAppShell.Core.Exceptions;
using Constants = WebAppShell.Core.Constants;
namespace MauiTubePlayer.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
{
    private string nextToken = string.Empty;
    private string searchTerm = "iPhone 14";

    [ObservableProperty]
    private bool isLoadingMore;


    public StartPageViewModel()
    {
		Title = "TUBE PLAYER";
	}

    public override async void OnNavigatedTo(object parameters)
    {
        await Search();
    }

    private async Task Search()
    {
        SetDataLodingIndicators(true);

        //LoadingText = "Hold on while we search for Youtube videos...";


        try
        {
            //Search for videos
            await GetYouTubeVideos();

            //this.DataLoaded = true;
        }
        //catch (InternetConnectionException iex)
        //{
        //    this.IsErrorState = true;
        //    this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
        //    ErrorImage = "nointernet.png";
        //}
        //catch (Exception ex)
        //{
        //    this.IsErrorState = true;
        //    this.ErrorMessage = $"Something went wrong. If the problem persists, plz contact support at {Constants.EmailAddress} with the error message:" + Environment.NewLine + Environment.NewLine + ex.Message;
        //    ErrorImage = "error.png";
        //}
        finally
        {
            SetDataLodingIndicators(false);
        }
    }

    private Task GetYouTubeVideos()
    {
       return Task.Delay(2000);
    }

    [RelayCommand]
    private async void OpenSettingPage()
    {
        await PageService.DisplayAlert("Setting", "This implemention is outside the scope of this course.", "Got it!");
    }
    [RelayCommand]
    private async void StartLoading()
    {
        IsBusy = true;
    }
    [RelayCommand]
    private async void StopLoading()
    {
        IsBusy = false;
    }

    [RelayCommand]
    private async Task LoadMoreVideos()
    {
        if (IsLoadingMore || string.IsNullOrEmpty(nextToken))
            return;

        IsLoadingMore = true;
        await Task.Delay(2000);
        await GetYouTubeVideos();
        IsLoadingMore = false;
    }

    [RelayCommand]
    private async Task SearchVideos(string searchQuery)
    {
        nextToken = string.Empty;
        searchTerm = searchQuery.Trim();

        await Search();
    }

    [RelayCommand]
    private async Task NavigateToVideoDetailsPage(string videoID)
    {
        await Task.Delay(1000);
    }

}

