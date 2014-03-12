using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BattlelogMobile.Client.Service;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Phone.Shell;

namespace BattlelogMobile.Client.ViewModel
{
    public class SoldierViewModel : BaseViewModel
    {
        private SupportedGame _supportedGame = SupportedGame.Unknown;

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

            // Download complete, parse data
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, async message =>
            //{
            //    var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
            //    if (battlefieldData == null)
            //        return;

            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() => ViewModelLocator.Bf3Soldier.Data = battlefieldData);
            //});
        }

        private bool _appBarEnabled = true;
        public bool AppBarEnabled
        {
            get { return _appBarEnabled; }
            set { _appBarEnabled = value; RaisePropertyChanged("AppBarEnabled"); }
        }

        public ICommand UpdateCommand { get; set; }

        public BattlelogRepository BattlelogRepository { get; set; }

        public SupportedGame Game
        {
            get { return _supportedGame; }
            set { _supportedGame = value; }
        }

        public async Task Update(bool forceUpdate = false)
        {
            await BattlelogRepository.UpdateStorage(forceUpdate);
            var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
            if (battlefieldData == null)
                return;

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    ViewModelLocator.Bf3Soldier.Data = battlefieldData;
                    INavigationService _navigationService = new NavigationService();
                    _navigationService.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            //if (Game == SupportedGame.Battlefield3)
            //    await BattlelogRepository.UpdateStorage(true);
        }


    }
}
