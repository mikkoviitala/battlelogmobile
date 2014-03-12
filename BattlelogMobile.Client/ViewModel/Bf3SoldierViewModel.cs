using BattlelogMobile.Core.Model;

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
                _battlefield3Data = value;
                RaisePropertyChanged("Data");
            }
        }
    }
}