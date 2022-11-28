using DataAccess.Classes;
using Interface.Classes;
using Interface.Dtos;
using Logic.Containers;
using Microsoft.AspNetCore.Mvc;

namespace GalleryManager.Controllers;

[ApiController]
[Route("[action]")]
public class PhotoController : ControllerBase
{
    private readonly ILogger<AlbumController> _logger;
    private readonly IAlbumContainer _albumContainer;
    
    public PhotoController(ILogger<AlbumController> logger)
    {
        _logger = logger;
        _albumContainer = new AlbumContainer(new AlbumDal());
    }

    [HttpGet]
    [ActionName("Photos")]
    public IList<PhotoDto> Get(int albumId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.GetPhotosByAlbum(albumId);
        }
        catch
        {
            return new List<PhotoDto>();
        }
    }
    
    [HttpGet]
    [ActionName("Photo")]
    public PhotoDto Get(int albumId, int photoId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.GetPhoto(photoId, albumId);
        }
        catch
        {
            return new PhotoDto();
        }
    }

    [HttpPost]
    [ActionName("Photo")]
    public void Post(PhotoDto photoDto, int albumId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            _albumContainer.AddPhoto(photoDto, albumId);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    
    [HttpPost]
    [ActionName("Photos")]
    public void Post(IList<PhotoDto> photoDtos, int albumId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            _albumContainer.AddPhotosToAlbum(photoDtos, albumId);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    
    [HttpPut]
    [ActionName("Photo")]
    public void Put(PhotoDto photoDto, int albumId)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            _albumContainer.UpdatePhoto(photoDto, albumId);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    
    [HttpDelete]
    [ActionName("Photo")]
    public void Delete(int albumId, PhotoDto photoDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            _albumContainer.RemovePhoto(photoDto, albumId);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}