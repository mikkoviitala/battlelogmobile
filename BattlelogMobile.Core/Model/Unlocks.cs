using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class Unlocks : IUnlocks
    {
        private readonly IList<IUnlock> _unlocks = new List<IUnlock>();

        public Unlocks()
        { }

        public Unlocks(IList<IUnlock> unlocks)
        {
            _unlocks = unlocks;
        }

        public IUnlock Get(string slug)
        {
            var unlock = _unlocks.SingleOrDefault(u => u.Slug.Equals(slug));
            if (unlock != null)
                return unlock;
            throw new ArgumentException("given name not found in collection!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IUnlock> GetEnumerator()
        {
            return _unlocks.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var unlock in _unlocks)
            {
                builder.Append("[");
                builder.Append(unlock);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}