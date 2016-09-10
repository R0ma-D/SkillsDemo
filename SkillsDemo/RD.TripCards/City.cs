using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.TripCards
{
    /// <summary>
    /// Населённый пункт
    /// </summary>
    public sealed class City : IEquatable<City>
    {
        public City(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name");

            Name = name;
        }

        public string Name
        {
            get;
            private set;
        }

        public bool Equals(City other)
        {
            if (other == null)
                return false;

            return string.Equals(Name, other.Name);
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as City;
            if (other != null)
                return Equals(other);

            return false;
        }
    }
}
