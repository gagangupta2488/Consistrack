using System.Collections.Generic;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Dtos;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
using Consistrack.Interface;
namespace Consistrack.Controllers
{
[Route("api/UserMaster")]
    [ApiController]
    //Get api/Commands
public class UserMasterController:ControllerBase
{
        private readonly IUserMasterRepo _repository;
       private readonly IMapper _mapper;

        public UserMasterController(IUserMasterRepo repository,IMapper mapper)
   {
       _repository=repository;
       _mapper=mapper;
   }
   
    [HttpGet]
   
    public ActionResult <IEnumerable<UserMaster>> GetAllUsers()
{
    var useritems=_repository.GetAllUsers();
    return Ok(useritems);

}
//Get api/commands/{Id}
[HttpGet("{LoginID}/{Password}")]
public ActionResult <UserMaster> GetUserByIdPwd(string lid,string pwd)
{
var useritem=_repository.GetUserByIdPwd(lid,pwd);
if(useritem!= null)
{
return Ok (useritem);
}
return NotFound();
}
    [HttpPost]
 public ActionResult CreateCommand(UserMaster user)
 {
     
     _repository.CreateCommand(user);
     _repository.SaveChanges();
   //  return CreatedAtRoute(nameof(GetSensorByMAC), new {mac=sens.MAC_No},sens);
return NoContent();    
 }
 [HttpPut("{LoginID}/{Password}")]
public ActionResult UpdateCommand(string lid,string pwd ,UserUpdateDto userupdatedto)
{
var userModelRepo=_repository.GetUserByIdPwd(lid,pwd);
if(userModelRepo==null)
{
    return NotFound();
}
_mapper.Map(userupdatedto,userModelRepo);
_repository.UpdateCommand(userModelRepo);
_repository.SaveChanges();
return NoContent();
}
}
}


   