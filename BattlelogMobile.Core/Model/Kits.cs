using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class Kits : IKits 
    {
        private readonly IList<IKit> _kits = new List<IKit>();

        public Kits()
        {}

        public Kits(IList<IKit> kits)
        {
            _kits = kits;
        }

        public void Add(IKit kit)
        {
            if (_kits.Contains(kit))
                _kits.Remove(kit);
            _kits.Add(kit);
        }

        public IKit Get(KitType type)
        {
            var kit = _kits.SingleOrDefault(k => k.Type.Equals(type));
            if (kit != null)
                return kit;
            throw new ArgumentException("given KitType not found in collection!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IKit> GetEnumerator()
        {
            return _kits.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var kit in _kits)
            {
                builder.Append("[");
                builder.Append(kit);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}