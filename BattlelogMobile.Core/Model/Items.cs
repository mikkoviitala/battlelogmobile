using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class Items : IItems
    {
        private readonly IEnumerable<IItem> _items = new List<IItem>();

        public Items()
        {}

        public Items(IEnumerable <IItem> items)
        {
            _items = items;
        }

        //public IItem Get(string itemName)
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var item in _items)
            {
                builder.Append("[");
                builder.Append(item);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}