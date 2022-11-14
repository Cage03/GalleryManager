using Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Classes;

[TestClass]
public class PhotoTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        var name = "Test1";
        var description = "Desc1";
        var href = "TestHref1";
        var photoType = "Type1";
        //act
        var photo = new Photo(name, href, description, photoType);
        //assert
        Assert.IsNotNull(photo);
        Assert.AreEqual(name, photo.Name);
        Assert.AreEqual(description, photo.Description);
        Assert.AreEqual(href, photo.Href);
        Assert.AreEqual(photoType, photo.PhotoType);
    }
}