using DataAccess.Classes;
using Interface.Dtos;
using Interface.Interfaces;
using Logic.Containers;
using Microsoft.AspNetCore.Mvc;

namespace GalleryManager.Controllers;

[ApiController]
[Route("[action]")]
public class AlbumController : ControllerBase
{
    private readonly ILogger<AlbumController> _logger;
    private readonly IAlbumContainer _albumContainer;


    public AlbumController(ILogger<AlbumController> logger)
    {
        _logger = logger;
        _albumContainer = new AlbumContainer(new AlbumDal());
    }

    [HttpGet]
    [ActionName("Album")]
    public AlbumDto Get([FromQuery] int id)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.GetAlbum(id);
        }
        catch
        {
            return new AlbumDto();
        }
    }
    

    [HttpPost]
    [ActionName("Albums")]
    public IList<AlbumDto> Get([FromQuery] UserDto? userDto = null)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (userDto != null)
            {
                return _albumContainer.GetAllAlbumsByUser(userDto.Id);
            }
            else
            {
                return _albumContainer.GetAllAlbums();
            }
        }
        catch
        {
            return new List<AlbumDto>();
        }
    }

    [HttpPost]
    [ActionName("Album")]
    public int Post(AlbumDto albumDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.AddAlbum(albumDto);
        }
        catch
        {
            return 0;
        }
    }

    [HttpDelete]
    [ActionName("Album")]
    public bool Delete(AlbumDto albumDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.RemoveAlbum(albumDto);
        }
        catch
        {
            return false;
        }
    }

    [HttpPut]
    [ActionName("Album")]
    public bool Put(AlbumDto albumDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _albumContainer.UpdateAlbum(albumDto);
        }
        catch
        {
            return false;
        }
    }
}