using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

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

            // Download complete, parse data
            Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, async message =>
            {
                var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
                if (battlefieldData == null)
                    return;

                ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() => ViewModelLocator.Bf3Soldier.Data = battlefieldData);
            });
        }

        public BattlelogRepository BattlelogRepository { get; set; }

        public SupportedGame Game
        {
            get { return _supportedGame; }
            set { _supportedGame = value; }
        }

        public async void Update()
        {
            //if (Game == SupportedGame.Battlefield3)
                await BattlelogRepository.UpdateStorage(true);
        }
    }
}
