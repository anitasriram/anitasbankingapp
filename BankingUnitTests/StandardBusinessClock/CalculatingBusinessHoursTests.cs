using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests.StandardBusinessClock
{
    public class CalculatingBusinessHoursTests
    {

        [Fact]
        public void OutsideBusinessHoursReturnsTrue()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 8, 59, 59));
            IProvideTheBusinessClock standardClock = new StandardClock(stubbedClock.Object);
            Assert.True(standardClock.OutsideBusinessHours());
        }



        [Fact]
        public void OutsideBusinessHoursReturnsFalse()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 9, 00, 00));
            IProvideTheBusinessClock standardClock = new StandardClock(stubbedClock.Object);
            Assert.False(standardClock.OutsideBusinessHours());
        }

    }
}
