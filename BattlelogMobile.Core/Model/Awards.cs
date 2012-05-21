using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model
{
    public class Awards : IAwards
    {
        private readonly IList<IAward> _awards = new List<IAward>();

        public Awards()
        {}

        public Awards(IList<IAward> awards)
        {
            _awards = awards;
        }

        public IAward Get(string code)
        {
            var award = _awards.SingleOrDefault(k => k.Code.Equals(code));
            if (award != null)
                return award;
            throw new ArgumentException("given code not found in collection!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IAward> GetEnumerator()
        {
            return _awards.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var award in _awards)
            {
                builder.Append("[");
                builder.Append(award);
                builder.Append("]");
            }
            return string.Format("{0}", builder);
        }
    }
}