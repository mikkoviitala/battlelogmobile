using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class VehicleViewModel : BaseViewModel
    {
        private IVehiclePanorama _vehiclePanorama = new VehiclePanorama();

        public VehicleViewModel() : this(new BattlelogRepository())
        {}

        public VehicleViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _vehiclePanorama = BattlelogRepository.LoadVehicle();
            //        RaisePropertyChanged("Vehicles");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IItems Vehicles { get { return _vehiclePanorama.Vehicles; } }
    }
}
