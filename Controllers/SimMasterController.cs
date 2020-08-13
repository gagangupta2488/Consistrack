using System.Collections.Generic;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Dtos;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
using Consistrack.Interface;
namespace Consistrack.Controllers
{
[Route("api/SimMaster")]
    [ApiController]
    //Get api/Commands
public class simMasterControl:ControllerBase
{
        private readonly ISimMasterRepo _repository;
       private readonly IMapper _mapper;

        public simMasterControl(ISimMasterRepo repository,IMapper mapper)
   {
       _repository=repository;
       _mapper=mapper;
   }
   
    [HttpGet]
   
    public ActionResult <IEnumerable<SimMaster>> GetAllSims(int flag)
{
    var SimItems=_repository.GetAllSims(flag);
    return Ok(SimItems);

}
//Get api/commands/{Id}
[HttpGet("{Id}",Name="GetSimById")]
public ActionResult <SimMaster> GetSimById(int id)
{
var SimItem=_repository.GetSimById(id);
if(SimItem!= null)
{
return Ok (SimItem);
}
return NotFound();
}
     [Route("CreateCommand")]
    [ActionName("CreateCommand")]
    [HttpPost]
 public ActionResult CreateCommand(SimMaster sim)
 {
     if(sim.Id == 0)
           {
     _repository.CreateCommand(sim);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetSimById), new {id=sim.Id},sim);
           }
           else{
        return UpdateCommand(sim.Id, sim);
            
           }

 }
 [HttpPut("{ID}")]
public ActionResult UpdateCommand(int id ,SimMaster simupdatedto)
{
var SimModelRepo=_repository.GetSimById(id);
if(SimModelRepo==null)
{
    return NotFound();
}
_mapper.Map(simupdatedto,SimModelRepo);
_repository.UpdateCommand(SimModelRepo);
_repository.SaveChanges();
return NoContent();
}
[Route("GetATSNUId")]
[HttpGet]
[ActionName("GetATSNUId")]
public ActionResult <string> GetATSNUId()
{
    return _repository.GetATSNUId();
}

[HttpDelete("{Id}/{flag}")]
public ActionResult DeleteCommand(int id, bool flag )
{
_repository.DeleteCommand(id,flag);
_repository.SaveChanges();
return NoContent();
}
}
}


