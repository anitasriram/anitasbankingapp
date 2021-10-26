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
        public void OutsideBusinessHoursReturnsTrueAnotherEdgeCase()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 17, 00, 00));
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

        [Fact]
        public void OutsideBusinessHoursReturnsFalseAnotherEdgeCase()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 16, 59, 59));
            IProvideTheBusinessClock standardClock = new StandardClock(stubbedClock.Object);
            Assert.False(standardClock.OutsideBusinessHours());
        }

        

        [Theory]        
        [InlineData(2000, 1, 1, 8, 59, 59, true)]
        [InlineData(2000, 1, 1, 9, 0, 0, false)]
        [InlineData(2000, 1, 1, 16, 59, 59, false)]
        [InlineData(2000, 1, 1, 17, 00, 00, true)]
        public void OutsideBusinessHoursCalculationsWork(int year, int month, int day, int hour, int min, int sec, bool expectedIsOutsideBusinessHours)
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(year, month, day, hour, min, sec));
            IProvideTheBusinessClock standardClock = new StandardClock(stubbedClock.Object);
            Assert.Equal(standardClock.OutsideBusinessHours(), expectedIsOutsideBusinessHours);
        }

    }
}
