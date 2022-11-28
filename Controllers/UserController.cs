using DataAccess.Classes;
using Interface.Classes;
using Interface.Dtos;
using Logic.Containers;
using Microsoft.AspNetCore.Mvc;

namespace GalleryManager.Controllers;


[ApiController]
[Route("[action]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserContainer _userContainer;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
        _userContainer = new UserContainer(new UserDal());
    }

    [HttpGet]
    [ActionName("User")]
    public UserDto Get([FromQuery]int id)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _userContainer.GetUser(id);
        }
        catch
        {
            return new UserDto();
        }
    }

    [HttpGet]
    [ActionName("Users")]
    public IList<UserDto> Get()
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _userContainer.GetAllUsers();
        }
        catch
        {
            return new List<UserDto>();
        }
    }

    [HttpPost]
    [ActionName("User")]
    public int Post(UserDto userDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _userContainer.AddUser(userDto);
        }
        catch
        {
            return 0;
        }
    }

    [HttpDelete]
    [ActionName("User")]
    public bool Delete([FromQuery]int id)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _userContainer.RemoveUser(id);
        }
        catch
        {
            return false;
        }
    }

    [HttpPut]
    [ActionName("User")]
    public bool Put(UserDto userDto)
    {
        try
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _userContainer.UpdateUser(userDto);
        }
        catch
        {
            return false;
        }
    }
}