using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class Others : IOthers
    {
        private readonly IEnumerable<IOther> _others = new List<IOther>();

        public Others()
        {}

        public Others(IEnumerable<IOther> others)
        {
            _others = others;
        }

        public IOther Get(string type)
        {
            var other = _others.SingleOrDefault(o => o.Type.Equals(type));
            if (other != null)
                return other;
            throw new ArgumentException("given type not found in collection!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IOther> GetEnumerator()
        {
            return _others.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var other in _others)
            {
                builder.Append("[");
                builder.Append(other);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}