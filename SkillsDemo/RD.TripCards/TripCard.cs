using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.TripCards
{
    /// <summary>
    /// Карточка путешествия
    /// </summary>
    public sealed class TripCard
    {
        public TripCard(City from, City to)
        {
            Validate(from, to);

            From = from;
            To = to;
        }

        private void Validate(City from, City to)
        {
            if (from == null)
                throw new ArgumentNullException("from");
            if (to == null)
                throw new ArgumentNullException("to");
            if (object.Equals(from, to))
                throw new ArgumentException("Cities must be not equals");
        }

        /// <summary>
        /// Пункт отправления
        /// </summary>
        public City From
        {
            get;
            private set;
        }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public City To
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("{0}->{1}", From, To);
        }
    }
}
