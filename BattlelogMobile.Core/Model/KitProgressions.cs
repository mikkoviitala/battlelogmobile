using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class KitProgressions : IKitProgressions
    {
       private readonly IEnumerable<IKitProgression> _kitProgressions = new List<IKitProgression>();

        public KitProgressions()
        {}

        public KitProgressions(IEnumerable<IKitProgression> kitProgressions)
        {
            _kitProgressions = kitProgressions;
        }

        public IKitProgression Get(KitType type)
        {
            var kitProgression = _kitProgressions.SingleOrDefault(k => k.Type.Equals(type));
            if (kitProgression != null)
                return kitProgression;
            throw new ArgumentException("given KitType not found in collection!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IKitProgression> GetEnumerator()
        {
            return _kitProgressions.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var kitProgression in _kitProgressions)
            {
                builder.Append("[");
                builder.Append(kitProgression);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}
