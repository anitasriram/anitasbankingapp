using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class BonusesAndBusinessHoursTests
    {

        [Fact]
        public void DeposistsDuringBusinessHoursGetBonus()
        {
            var stubbedClock = new Mock<IProvideTheBusinessClock>();
            stubbedClock.Setup(c => c.OutsideBusinessHours()).Returns(false);
            var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);
            var bonus = bonusCalculator.GetBonusFor(10000, 100);

            Assert.Equal(10, bonus);
        }

        [Fact]
        public void DepositsOutsideBusinessHoursGetNoBonus()
        {
            var stubbedClock = new Mock<IProvideTheBusinessClock>();
            stubbedClock.Setup(c => c.OutsideBusinessHours()).Returns(true);
            var bonusCalculator = new StandardBonusCalculator(stubbedClock.Object);

            var bonus = bonusCalculator.GetBonusFor(10000, 100);

            Assert.Equal(0, bonus);
        }

    }
}
