using Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Classes;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        var username = "user1";
        var password = "psw1";
        var accountStatus = "Admin";
        //act
        var user = new User(username, password, accountStatus);
        //assert
        Assert.IsNotNull(user);
        Assert.AreEqual(username,user.Username);
        Assert.AreEqual(password,user.Password);
        Assert.AreEqual(accountStatus,user.AccountStatus);
    }
}