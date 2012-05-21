using System.Windows;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class GadgetViewModel : BaseViewModel
    {
        private IGadgetPanorama _gadgetPanorama = new GadgetPanorama();

        public GadgetViewModel() : this(new BattlelogRepository())
        {}

        public GadgetViewModel(IBattlelogRepository battlelogRepository)
        {

            BattlelogRepository = battlelogRepository;
            //Messenger.Default.Register<BattlelogUpdateCompleteMessage>(this, message =>
            //    ((App)Application.Current).RootFrame.Dispatcher.BeginInvoke(() =>
            //    {
            //        _gadgetPanorama = BattlelogRepository.LoadGadget();
            //        RaisePropertyChanged("Gadgets");
            //    }));
        }

        public IBattlelogRepository BattlelogRepository { get; set; }

        public IItems Gadgets { get { return _gadgetPanorama.Gadgets; } }
    }
}
