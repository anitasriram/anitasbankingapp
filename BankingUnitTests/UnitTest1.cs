using System;
using Xunit;

namespace BankingUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Setup the Universe
            // Given (Arrange)
            int a = 10, b = 20;
            // Do Something
            // When (Act)
            int answer = a + b; // SUT: C# addition operator.
            // Verify it worked as expected
            // Then (Assert)
            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(10,5, 15)]
        [InlineData(20,3, 23)]
        public void DoesAdditionWork(int a, int b, int expected)
        {
            // Setup the Universe
            // Given (Arrange)
           
            // Do Something
            // When (Act)
            int answer = a + b;
            // Verify it worked as expected
            // Then (Assert)
            Assert.Equal(expected, answer);
        }

    }
}
