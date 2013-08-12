using BattlelogMobile.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Repository
{
    public interface ISettingsRepository
    {
        void Save(ISettings settings);
        ISettings Load();
    }
}
