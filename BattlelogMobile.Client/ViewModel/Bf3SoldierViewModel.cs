using System.Windows;
using BattlelogMobile.Core;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using BattlelogMobile.Core.Service;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Client.ViewModel
{
    public class Bf3SoldierViewModel : BaseViewModel
    {
        private Battlefield3Data _battlefield3Data;

        public Battlefield3Data Data
        {
            get { return _battlefield3Data; }
            set
            {
                Messenger.Default.Send(new SoldierLoadedMessage(Common.StatusInformationPreparingStatistics, SupportedGame.Battlefield3));
                _battlefield3Data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}