using System;
using Xunit;
using Xunit.Abstractions;
using RPS_Game_Refactored;

namespace Rps_Game_Refactored.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            //not needed

            // Act
            Choice result = RpsGameMethods.GetRandomChoice();

            //Assert
            // Assert.Equals(Choice.Paper || Choice.Rock || Choice.Scissors, )
            Assert.IsType<Choice>(result);
        }

        public void GetUsersIntentReturnsOneOrTwo(){
            
            //Arrange
            // not needed

            //Act
            int result = RpsGameMethods.GetUsersIntent();

            //Assert
            Assert.IsTrue();
        }
    }
}
