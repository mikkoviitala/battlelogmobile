using System.Collections.Generic;

namespace BattlelogMobile.Core.Model
{
    public class ItemComparer : IEqualityComparer<ItemContainer>
    {
        public bool Equals(ItemContainer item1, ItemContainer item2)
        {
            if (ReferenceEquals(item1, item2)) 
                return true;
            return item1.Name == item2.Name && item1.Kills == item2.Kills;
        }

        public int GetHashCode(ItemContainer item)
        {
            int name = item.Name == null ? 0 : item.Name.GetHashCode();
            int kills = item.Kills == 0 ? 0 : item.Kills.GetHashCode();
            return name ^ kills;
        }

    }
}