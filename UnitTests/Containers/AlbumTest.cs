using Interface.Dtos;
using Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Containers;

[TestClass]
public class AlbumTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        var photoDal = new PhotoMock();
        List<Photo> photos = new();
        var photo1 = new Photo("photo1", "href1", "desc1", "type1");
        var photo2 = new Photo("photo2", "href2", "desc2", "type2");
        photos.Add(photo1);
        photos.Add(photo2);
        //act
        var album = new Album(photos, "name1", "description1", new DateTime(2011, 1, 1), photoDal);
        //assert
        Assert.AreEqual(photos, album.Photos);
        Assert.AreEqual("name1", album.Name);
        Assert.AreEqual("description1", album.Description);
        Assert.AreEqual(new DateTime(2011, 1, 1), album.Date);
    }

    [TestMethod]
    public void GetPhotoById()
    {
        //arrange
        var photoDal = new PhotoMock();
        var album = new Album(photoDal);
        var photo1 = new PhotoDto()
        {
            Description = "desc1",
            Href = "href1",
            Id = 933,
            Name = "name1",
            PhotoType = "type1"
        };
        album.AddPhoto(photo1, 933);
        //act
        var photo2 = album.GetPhoto(photo1.Id);
        //assert
        Assert.AreEqual(photo1.Name, photo2.Name);
        Assert.AreEqual(photo1.Description, photo2.Description);
        Assert.AreEqual(photo1.Href, photo2.Href);
        Assert.AreEqual(photo1.PhotoType, photo2.PhotoType);
    }
    
    [TestMethod]
    public void AddPhoto()
    {
        //arrange
        var photoDal = new PhotoMock();
        var album = new Album(photoDal);
        var photo1 = new PhotoDto()
        {
            Description = "desc1",
            Href = "href1",
            Id = 933,
            Name = "name1",
            PhotoType = "type1"
        };
        //act
        album.AddPhoto(photo1, 933);
        //assert
        Assert.AreEqual(4, photoDal.PhotoDtos.Count);
        Assert.AreEqual(photo1.Name, photoDal.PhotoDtos[3].Name);
        Assert.AreEqual(photo1.Description, photoDal.PhotoDtos[3].Description);
        Assert.AreEqual(photo1.Href, photoDal.PhotoDtos[3].Href);
        Assert.AreEqual(photo1.PhotoType, photoDal.PhotoDtos[3].PhotoType);
    }

    [TestMethod]
    public void UpdatePhoto()
    {
        //arrange
        var photoDal = new PhotoMock();
        var album = new Album(photoDal);
        var photo1 = new PhotoDto()
        {
            Description = "desc1",
            Href = "href1",
            Id = 933,
            Name = "name1",
            PhotoType = "type1"
        };
        album.AddPhoto(photo1, 933);
        var photo2 = new PhotoDto()
        {
            Description = "desc2",
            Href = "href2",
            Id = 933,
            Name = "name2",
            PhotoType = "type2"
        };
        //act
        album.UpdatePhoto(photo2);
        //assert
        Assert.AreEqual(4,photoDal.PhotoDtos.Count);
        Assert.AreEqual(photo2.Name, photoDal.PhotoDtos[3].Name);
        Assert.AreEqual(photo2.Description, photoDal.PhotoDtos[3].Description);
        Assert.AreEqual(photo2.Href, photoDal.PhotoDtos[3].Href);
        Assert.AreEqual(photo2.PhotoType, photoDal.PhotoDtos[3].PhotoType);
    }
    
    [TestMethod]
    public void RemovePhoto()
    {
        //arrange
        var photoDal = new PhotoMock();
        var album = new Album(photoDal);
        var photo1 = new PhotoDto()
        {
            Description = "desc1",
            Href = "href1",
            Id = 933,
            Name = "name1",
            PhotoType = "type1"
        };
        album.AddPhoto(photo1, 933);
        //act
        album.RemovePhoto(photo1);
        //assert
        Assert.AreEqual(3, photoDal.PhotoDtos.Count);
        Assert.IsFalse(photoDal.PhotoDtos.Contains(photo1));
    }
}