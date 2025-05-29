using Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class InputTests
{
    [TestMethod]
    public void TypeInputTest()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckType("3"));
        Assert.AreEqual("Invalid selection. Choose 1 or 2.", ex.Message);
    }

    [TestMethod]
    public void nameInputTest()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckName("ab"));
        Assert.AreEqual("Name must start with an uppercase letter and be at least 3 characters long.", ex.Message);
    }

    [TestMethod]
    public void nameInputTest2()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckName("ivan"));
        Assert.AreEqual("Name must start with an uppercase letter and be at least 3 characters long.", ex.Message);
    }

    [TestMethod]
    public void HireDateInputTest()
    {
        var ex = Assert.ThrowsException<FormatException>(() => InputChecker.CheckHireDate("date"));
        Assert.AreEqual("Invalid date format. Please use yyyy-mm-dd.", ex.Message);
    }

    [TestMethod]
    public void HireDateInputTest2()
    {
        var ex = Assert.ThrowsException<ArgumentNullException>(() => InputChecker.CheckHireDate("date"));
        Assert.AreEqual("Hire date cannot be empty.", ex.Message);
    }

    [TestMethod]
    public void ExpirienxeInputTest()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckExperience("-1"));
        Assert.AreEqual("Experience cannot be negative.", ex.Message);
    }
    
    [TestMethod]
    public void idInputTest()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckId("-12"));
        Assert.AreEqual("ID cannot be negative.", ex.Message);
    }


    [TestMethod]
    public void PositionInputTest2()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckPosition("position"));
        Assert.AreEqual("Position must start with an uppercase letter and be at least 2 characters long.", ex.Message);
    }

    [TestMethod]
    public void PositionInputTest3()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => InputChecker.CheckPosition("G"));
        Assert.AreEqual("Position must start with an uppercase letter and be at least 2 characters long.", ex.Message);
    }

}

