﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace BattlelogMobile.Client.ViewModel
{
    public class SoldierViewModel : BaseViewModel
    {
        private bool _appBarEnabled = true;

        public SoldierViewModel()
            :this(new BattlelogRepository(new DownloadService(ViewModelLocator.CookieJar)))
        {}

        public SoldierViewModel(BattlelogRepository battlelogRepository)
        {
            BattlelogRepository = battlelogRepository;

            UpdateCommand = new RelayCommand(async () =>
                {
                    AppBarEnabled = false;
                    await Update(true);
                    AppBarEnabled = true;
                });
        }

        public bool AppBarEnabled
        {
            get { return _appBarEnabled; }
            set { _appBarEnabled = value; RaisePropertyChanged("AppBarEnabled"); }
        }

        public ICommand UpdateCommand { get; set; }

        public BattlelogRepository BattlelogRepository { get; set; }

        private SupportedGame _game = SupportedGame.Unknown;
        public SupportedGame Game
        {
            get { return _game; }
            set
            {
                _game = value;
                UpdateData();
                RaisePropertyChanged("Game");
            }
        }

        private async void UpdateData()
        {
            AppBarEnabled = false;
            await Update();
            AppBarEnabled = true;
        }

        public async Task Update(bool forceUpdate = false)
        {
            // TODO: Untangle this logic right here

            //bool success = await BattlelogRepository.UpdateStorage(forceUpdate);
            bool success = await BattlelogRepository.UpdateStorage(_game, forceUpdate);
            if (!success)
                return;

            if (_game == SupportedGame.Battlefield3)
            {
                var battlefieldData = await BattlelogRepository.LoadBattlefieldData(new Bf3Parser());
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Messenger.Default.Send(new NotificationMessage(this, string.Empty));
                    ViewModelLocator.Bf3UserControl.Data = battlefieldData;
                    ViewModelLocator.Bf4UserControl.Data = null;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            }
            else
            {
                var battlefieldData = await BattlelogRepository.LoadBattlefieldData(new Bf4Parser());
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Messenger.Default.Send(new NotificationMessage(this, string.Empty));
                    ViewModelLocator.Bf4UserControl.Data = battlefieldData;
                    ViewModelLocator.Bf3UserControl.Data = null;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            }
        }
    }
}
