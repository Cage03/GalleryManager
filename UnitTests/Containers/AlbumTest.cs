using Interface.Dtos;
using Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Containers;

[TestClass]
public class AlbumTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        List<PhotoDto> photos = new();
        var photo1 = new Photo("photo1", "href1", "desc1", "type1");
        var photo2 = new Photo("photo2", "href2", "desc2", "type2");
        //act

        //assert
    }
}