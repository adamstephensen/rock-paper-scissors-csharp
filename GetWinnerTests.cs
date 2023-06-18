//dotnet add package Xunit

using RockPaperScissors;
using Xunit;

[Collection("Calculator Tests")]
public class RPSCalculatorTests
{
    [Fact]
    public void GetWinner_RockBeatsScissors_ReturnsPlayer1()
    {
        // Arrange
        var choice1 = RPSChoice.Rock;
        var choice2 = RPSChoice.Scissors;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Rock, result);
    }

    [Fact]
    public void GetWinner_ScissorsBeatsPaper_ReturnsPlayer1()
    {
        // Arrange
        var choice1 = RPSChoice.Scissors;
        var choice2 = RPSChoice.Paper;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Scissors, result);
    }

    [Fact]
    public void GetWinner_PaperBeatsRock_ReturnsPlayer1()
    {
        // Arrange
        var choice1 = RPSChoice.Paper;
        var choice2 = RPSChoice.Rock;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Paper, result);
    }

    [Fact]
    public void GetWinner_ScissorsLosesToRock_ReturnsPlayer2()
    {
        // Arrange
        var choice1 = RPSChoice.Scissors;
        var choice2 = RPSChoice.Rock;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Rock, result);
    }

    [Fact]
    public void GetWinner_PaperLosesToScissors_ReturnsPlayer2()
    {
        // Arrange
        var choice1 = RPSChoice.Paper;
        var choice2 = RPSChoice.Scissors;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Scissors, result);
    }

    [Fact]
    public void GetWinner_RockLosesToPaper_ReturnsPlayer2()
    {
        // Arrange
        var choice1 = RPSChoice.Rock;
        var choice2 = RPSChoice.Paper;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Paper, result);
    }

    [Fact]
    public void GetWinner_SameChoice_ReturnsTie()
    {
        // Arrange
        var choice1 = RPSChoice.Rock;
        var choice2 = RPSChoice.Rock;

        // Act
        var result = RPSCalculator.GetWinner(choice1, choice2);

        // Assert
        Assert.Equal(RPSChoice.Rock, result);
    }
}