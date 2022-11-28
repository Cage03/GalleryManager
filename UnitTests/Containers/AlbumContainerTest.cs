using Interface.Dtos;
using Logic.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.Containers;

[TestClass]
public class AlbumContainerTest
{
    [TestMethod]
    public void AddAlbumTest()
    {
        //arrange
        var albumDal = new AlbumMock();
        var albumContainer = new AlbumContainer(albumDal);
        var albumDto = new AlbumDto()
        {
            Id = 1319,
            Name = "TestAlbum",
            Date = new DateTime(2021, 1, 1),
            Description = "TestDescription",
            Photos = new List<PhotoDto>()
        };
        //act
        albumContainer.AddAlbum(albumDto);
        //assert
        Assert.AreEqual(albumDal.AlbumDtos.Count, 4);
        Assert.AreEqual(albumDal.AlbumDtos[3].Id, 1319);
    }

    [TestMethod]
    public void RemoveAlbumTest()
    {
        //arrange
        var albumDal = new AlbumMock();
        var albumContainer = new AlbumContainer(albumDal);
        var albumDto = new AlbumDto()
        {
            Id = 1319,
            Name = "TestAlbum",
            Date = new DateTime(2021, 1, 1),
            Description = "TestDescription",
            Photos = new List<PhotoDto>()
        };
        //act
        albumContainer.AddAlbum(albumDto);
        albumContainer.RemoveAlbum(albumDto.Id);
        //assert
        Assert.AreEqual(albumDal.AlbumDtos.Count, 3);
        Assert.IsFalse(albumDal.AlbumDtos.Contains(albumDto));
    }

    [TestMethod]
    public void UpdateAlbumTest()
    {
        //arrange
        var albumDal = new AlbumMock();
        var albumContainer = new AlbumContainer(albumDal);
        var albumDto = new AlbumDto()
        {
            Id = 1319,
            Name = "TestAlbum",
            Date = new DateTime(2021, 1, 1),
            Description = "TestDescription",
            Photos = new List<PhotoDto>()
        };
        var albumDto2 = new AlbumDto()
        {
            Id = 1319,
            Name = "TestAlbum2",
            Date = new DateTime(2021, 1, 1),
            Description = "TestDescription2",
            Photos = new List<PhotoDto>()
        };
        //act
        albumContainer.AddAlbum(albumDto);
        albumContainer.UpdateAlbum(albumDto2);
        //assert
        Assert.AreEqual(4, albumDal.AlbumDtos.Count);
        Assert.AreEqual("TestAlbum2", albumDal.AlbumDtos[3].Name);
        Assert.AreEqual("TestDescription2", albumDal.AlbumDtos[3].Description);
    }
    
    [TestMethod]
    public void GetAlbumTest()
    {
        //arrange
        var albumDal = new AlbumMock();
        var albumContainer = new AlbumContainer(albumDal);
        var albumDto = new AlbumDto()
        {
            Id = 1319,
            Name = "TestAlbum",
            Date = new DateTime(2021, 1, 1),
            Description = "TestDescription",
            Photos = new List<PhotoDto>()
        };
        //act
        albumContainer.AddAlbum(albumDto);
        var album = albumContainer.GetAlbum(albumDto.Id);
        //assert
        Assert.AreEqual(albumDto.Id, album.Id);
        Assert.AreEqual(albumDto.Name, album.Name);
        Assert.AreEqual(albumDto.Description, album.Description);
        Assert.AreEqual(albumDto.Date, album.Date);
    }
}