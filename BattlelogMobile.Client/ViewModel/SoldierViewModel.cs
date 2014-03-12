using System.Threading.Tasks;
using System.Windows.Input;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Command;
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
            Game = SupportedGame.Unknown;
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

        public SupportedGame Game { get; set; }

        public async Task Update(bool forceUpdate = false)
        {
            // TODO: Untangle this logic right here

            await BattlelogRepository.UpdateStorage(forceUpdate);
            var battlefieldData = await BattlelogRepository.LoadBattlefield3Data();
            if (battlefieldData == null)
                return;

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    ViewModelLocator.Bf3Soldier.Data = battlefieldData;
                    ViewModelLocator.Navigation.NavigateTo(ViewModelLocator.SoldierPageUri);
                });
            //if (Game == SupportedGame.Battlefield3)
            //    await BattlelogRepository.UpdateStorage(true);
        }
    }
}
