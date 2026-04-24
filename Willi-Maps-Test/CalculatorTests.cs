using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliMaps.Components;


[TestClass]
public class CalculatorTests
{
    private Calculator _calculator;

    [TestInitialize]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [TestMethod]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;
        int expected = 8;

        // Act
        int result = _calculator.add(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }


    [TestMethod]
    public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = -5;
        int b = -3;
        int expected = -8;

        // Act
        int result = _calculator.add(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Add_PositiveAndNegativeNumber_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = -3;
        int expected = 2;

        // Act
        int result = _calculator.add(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 5;
        int b = 3;
        int expected = 2;

        // Act
        int result = _calculator.subtract(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Subtract_NegativeNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = -5;
        int b = -3;
        int expected = -2;

        // Act
        int result = _calculator.subtract(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 5;
        int b = 3;
        int expected = 15;

        // Act
        int result = _calculator.multiply(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Multiply_WithZero_ReturnsZero()
    {
        // Arrange
        int a = 5;
        int b = 0;
        int expected = 0;

        // Act
        int result = _calculator.multiply(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 6;
        double b = 3;
        double expected = 2;

        // Act
        double result = _calculator.divide(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 5;
        double b = 0;

        // Act
        _calculator.divide(a, b);

        // Assert wird durch ExpectedException geprüft
    }

    [TestMethod]
    public void Divide_NegativeAndPositiveNumber_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = -6;
        double b = 3;
        double expected = -2;

        // Act
        double result = _calculator.divide(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

}