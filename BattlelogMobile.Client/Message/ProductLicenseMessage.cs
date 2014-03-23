using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattlelogMobile.Client.ViewModel;
using BattlelogMobile.Core;
using GalaSoft.MvvmLight.Messaging;
using StoreLauncher;

namespace BattlelogMobile.Client.Message
{
    public class ProductLicenseMessage : MessageBase
    {
        readonly ProductLicenseBase _license;

        public ProductLicenseMessage()
        {
            try
            {
                _license = ViewModelLocator.Store.LicenseInformation.ProductLicenses[Common.ProductKey];
            }
            catch { }            
        }
        
        public bool HasLicense
        {
            get { return _license != null && _license.IsActive; }
        }
    }
}
