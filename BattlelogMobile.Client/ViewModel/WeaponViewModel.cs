using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class WeaponViewModel : BaseViewModel
    {
        private IWeaponPanorama _weaponPanorama = new WeaponPanorama();

        public WeaponViewModel() : this(new BattlelogRepository())
        {}

        public WeaponViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _weaponPanorama = BattlelogRepository.LoadWeapon();
            //        RaisePropertyChanged("Weapons");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IItems Weapons { get { return _weaponPanorama.Weapons; } }
    }
}
