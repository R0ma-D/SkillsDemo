using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD.TripCards
{
    public static class TripHelper
    {
        /// <summary>
        /// Упорядочивает коллекцию карточек путешествия, имеет сложность O(n^2)
        /// </summary>
        /// <param name="tripCards">Исходная коллекция карточек, которую необходимо упорядочить</param>
        /// <returns>Возвращает упорядоченную коллекцию карточек</returns>
        /// <exception cref="ArgumentNullException">Бросается, если входная коллекция Null</exception>
        /// <exception cref="ApplicationException">Бросается, если из входной коллекции не удалось получить
        /// упорядоченный список</exception>
        public static List<TripCard> Sort(IEnumerable<TripCard> tripCards)
        {
            if (tripCards == null)
                throw new ArgumentNullException("tripCards");

            var cards = tripCards.ToList();
            //Если карточек нет или она одна, то список уже упорядочен
            if (cards.Count <= 1)
                return cards;

            var trip = new TripChain(cards[0], cards.Count);
            cards.RemoveAt(0);

            bool hasChanges = true;
            while (hasChanges)
            {
                hasChanges = false;
                for (int i = 0; i < cards.Count; i++)
                {
                    var card = cards[i];
                    if (trip.Add(card))
                    {
                        hasChanges = true;
                        cards.RemoveAt(i);
                        break;
                    }
                }
            }

            if (cards.Count > 0)
                throw new ApplicationException("Can't find correct trip from input collection");

            return trip.Result;
        }

        private sealed class TripChain
        {
            private List<TripCard> _chain;
            private City _startCity;
            private City _endCity;

            public TripChain(TripCard initCard, int capacity)
            {
                _chain = new List<TripCard>(capacity);
                _chain.Add(initCard);
                _startCity = initCard.From;
                _endCity = initCard.To;
            }

            /// <summary>
            /// Добавляет карточку путешествия к цепочке, если её пункт назначения или отправления соответствует текущему состоянию
            /// </summary>
            /// <param name="card">Карточка путешествия</param>
            /// <returns>Возвращает <c>true</c>, если карточка добавлена, в противном случае - <c>false</c></returns>
            public bool Add(TripCard card)
            {
                if (_startCity.Equals(card.To))
                {
                    //Добавляем карточку в начало
                    _chain.Insert(0, card);
                    _startCity = card.From;
                }
                else if (_endCity.Equals(card.From))
                {
                    //добавляем карточку в конец
                    _chain.Add(card);
                    _endCity = card.To;
                }
                else
                    return false;

                return true;
            }

            /// <summary>
            /// Упорядоченный список добавленных карточек
            /// </summary>
            public List<TripCard> Result
            {
                get { return _chain; }
            }

            public override string ToString()
            {
                return string.Join(", ", _chain);
            }
        }
    }
}
