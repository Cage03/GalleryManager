using Interface.Dtos;
using Logic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Containers;

[TestClass]
public class UserContainerTest
{
    [TestMethod]
    public void AddUserTest()
    {
        //arrange
        var userDal = new UserMock();
        var userContainer = new UserContainer(userDal);
        var user = new UserDto()
        {
            AccountStatus = "Standard",
            Id = 933,
            Password = "Password933",
            Username = "Username933"
        };
        //act
        userContainer.AddUser(user);
        //assert
        Assert.AreEqual(4, userDal.UserDtos.Count);
        Assert.AreEqual(user.Username, userDal.UserDtos[3].Username);
        Assert.AreEqual(user.Password, userDal.UserDtos[3].Password);
        Assert.AreEqual(user.AccountStatus, userDal.UserDtos[3].AccountStatus);
    }
    
    [TestMethod]
    public void GetUserTest()
    {
        //arrange
        var userDal = new UserMock();
        var userContainer = new UserContainer(userDal);
        var user1 = new UserDto()
        {
            Id = 933,
            AccountStatus = "Standard",
            Password = "Password1",
            Username = "Username1"
        };
        userContainer.AddUser(user1);
        //act
        var user = userContainer.GetUser(933);
        //assert
        Assert.AreEqual(933, user.Id);
        Assert.AreEqual("Username1", user.Username);
        Assert.AreEqual("Password1", user.Password);
        Assert.AreEqual("Standard", user.AccountStatus);
    }
    
    [TestMethod]
    public void GetUserByUsernameTest()
    {
        //arrange
        var userDal = new UserMock();
        var userContainer = new UserContainer(userDal);
        var user1 = new UserDto()
        {
            AccountStatus = "Standard",
            Id = 933,
            Password = "Password933",
            Username = "Username933"
        };
        userContainer.AddUser(user1);
        //act
        var user = userContainer.GetUserByUsername("Username933");
        //assert
        Assert.AreEqual(933, user.Id);
        Assert.AreEqual("Username933", user.Username);
        Assert.AreEqual("Password933", user.Password);
        Assert.AreEqual("Standard", user.AccountStatus);
    }

    [TestMethod]
    public void RemoveUserTest()
    {
        //arrange
        var userDal = new UserMock();
        var userContainer = new UserContainer(userDal);
        var user = new UserDto()
        {
            AccountStatus = "Standard",
            Id = 933,
            Password = "Password933",
            Username = "Username933"
        };
        userContainer.AddUser(user);
        //act
        userContainer.RemoveUser(user.Id);
        //assert
        Assert.IsFalse(userDal.UserDtos.Contains(user));
    }

    [TestMethod]
    public void UpdateUserTest()
    {
       //arrange
       var userDal = new UserMock();
       var userContainer = new UserContainer(userDal);
       var user1 = new UserDto()
       {
           AccountStatus = "Standard",
           Id = 933,
           Password = "Password933",
           Username = "Username933"
       };
         userContainer.AddUser(user1);
         var user2 = new UserDto()
         {
             AccountStatus = "Admin",
             Id = 933,
             Password = "Password934",
             Username = "Username934"
         };
         //act
         userContainer.UpdateUser(user2);
         //assert
            Assert.AreEqual(4, userDal.UserDtos.Count);
            Assert.AreEqual(user2.Username, userDal.UserDtos[3].Username);
            Assert.AreEqual(user2.Password, userDal.UserDtos[3].Password);
            Assert.AreEqual(user2.AccountStatus, userDal.UserDtos[3].AccountStatus);
    }
}