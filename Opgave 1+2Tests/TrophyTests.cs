using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ValidateToString()
        {
            Trophy trophyToString = new Trophy()
            {
                Id = 1,
                Competition = "EM i Fodbold",
                Year = 1992
            };

            trophyToString.ToString();
            Assert.AreEqual(1, trophyToString.Id, "EM i Fodbold", trophyToString.Competition, 1992, trophyToString.Year);
        }

        [TestMethod()]
        public void ValidateCompetitionNullTest()
        {
            Trophy trophyCompetitionNull = new Trophy()
            {
                Id = 1,
                Competition = null,
                Year = 1992
            };

            Assert.ThrowsException<ArgumentNullException>(
                   () => trophyCompetitionNull.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateCompetitionTestAbove()
        {
            Trophy trophyCompetitionAbove = new Trophy()
            {
                Id = 1,
                Competition = "EM",
                Year = 1992
            };

            Assert.ThrowsException<ArgumentException>(
                   () => trophyCompetitionAbove.ValidateCompetition());
        }

        [TestMethod()]
        public void ValidateYearTestAbove()
        {
            Trophy trophyYear = new Trophy()
            {
                Id = 1,
                Competition = "EM i Fodbold",
                Year = 2025
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                   () => trophyYear.ValidateYear());
        }

        [TestMethod()]
        public void ValidateYearTestBelow()
        {
            Trophy trophyYear = new Trophy()
            {
                Id = 1,
                Competition = "EM i Fodbold",
                Year = 1969
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                   () => trophyYear.ValidateYear());
        }
    }
