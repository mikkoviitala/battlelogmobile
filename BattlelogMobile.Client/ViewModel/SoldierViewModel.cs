using System.Threading.Tasks;
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
                Daa();
                RaisePropertyChanged("Game");
            }
        }

        private async void Daa()
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

            var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
            if (battlefieldData == null)
                return;

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Messenger.Default.Send(new NotificationMessage(this, string.Empty));
                    ViewModelLocator.Bf3Soldier.Data = battlefieldData;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            //if (Game == SupportedGame.Battlefield3)
            //    await BattlelogRepository.UpdateStorage(true);
        }
    }
}
