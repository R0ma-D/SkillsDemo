using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RD.TripCards.Tests
{
    [TestClass]
    public class TripSortTests
    {
        [TestMethod]
        public void Test_CorrectInputSort()
        {
            //arrange
            var card1 = new TripCard(new City("Мельбурн"), new City("Кельн"));
            var card2 = new TripCard(new City("Кельн"), new City("Москва"));
            var card3 = new TripCard(new City("Москва"), new City("Париж"));

            var sortedCards = new List<TripCard>() { card1, card2, card3 };
            var unsordedCards = new List<TripCard>() { card1, card3, card2, };

            //act
            var result = TripHelper.Sort(unsordedCards);

            //assert
            CollectionAssert.AreEqual(sortedCards, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_NullInputSort()
        {
            TripHelper.Sort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Test_DuplicateInputSort()
        {
            //arrange
            var card1 = new TripCard(new City("Мельбурн"), new City("Кельн"));
            var card2 = new TripCard(new City("Кельн"), new City("Москва"));
            var card3 = new TripCard(new City("Москва"), new City("Париж"));
            var card4 = new TripCard(new City("Москва"), new City("Берлин"));

            TripHelper.Sort(new List<TripCard>() { card1, card3, card2, card4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Test_MissInputSort()
        {
            //arrange
            var card1 = new TripCard(new City("Мельбурн"), new City("Кельн"));
            var card2 = new TripCard(new City("Кельн"), new City("Прага"));
            var card3 = new TripCard(new City("Прага"), new City("Париж"));
            var card4 = new TripCard(new City("Москва"), new City("Берлин"));

            TripHelper.Sort(new List<TripCard>() { card1, card3, card2, card4 });
        }
    }
}
