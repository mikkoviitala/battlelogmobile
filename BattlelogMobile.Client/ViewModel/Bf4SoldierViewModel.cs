using System.Collections.ObjectModel;
using System.Linq;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Model.Battlefield4;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight;

namespace BattlelogMobile.Client.ViewModel
{
    //TODO: Everything...
    public class Bf4SoldierViewModel : ViewModelBase
    {
        private Battlefield4Data _data;

        public Battlefield4Data Data
        {
            get { return _data; }
            set
            {
                _data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}
