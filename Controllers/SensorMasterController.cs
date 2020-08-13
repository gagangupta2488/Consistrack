using System.Collections.Generic;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Dtos;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
using Consistrack.Interface;
namespace Consistrack.Controllers
{
[Route("api/SensorMaster")]
    [ApiController]
    //Get api/Commands
public class SensorMasterControl:ControllerBase
{
        private readonly ISensorMasterRepo _repository;
       private readonly IMapper _mapper;

        public SensorMasterControl(ISensorMasterRepo repository,IMapper mapper)
   {
       _repository=repository;
       _mapper=mapper;
   }
   
    [HttpGet]
   
    public ActionResult <IEnumerable<SensorMaster>> GetAllSensors(int flag)
{
    var Senseritems=_repository.GetAllSensors(flag);
    return Ok(Senseritems);

}
//Get api/commands/{Id}
[HttpGet("{Id}",Name="GetSensorById")]
public ActionResult <SimMaster> GetSensorById(int id)
{
var Sensoritem=_repository.GetSensorById(id);
if(Sensoritem!= null)
{
return Ok (Sensoritem);
}
return NotFound();
}
 [Route("CreateCommand")]
    [ActionName("CreateCommand")]
    [HttpPost]
 public ActionResult CreateCommand(SensorMaster sens)
 {
    if(sens.Id == 0)
           {
     _repository.CreateCommand(sens);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetSensorById), new {id=sens.Id},sens);
           }
           else{
        return UpdateCommand(sens.Id, sens);
     
 }
 }
 [HttpPut("{ID}")]
public ActionResult UpdateCommand(int id ,SensorMaster sensorupdatedto)
{
var SensorModelRepo=_repository.GetSensorById(id);
if(SensorModelRepo==null)
{
    return NotFound();
}
_mapper.Map(sensorupdatedto,SensorModelRepo);
_repository.UpdateCommand(SensorModelRepo);
_repository.SaveChanges();
return NoContent();
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


