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
   
    public ActionResult <IEnumerable<SensorMaster>> GetAllSensors()
{
    var Senseritems=_repository.GetAllSensors();
    return Ok(Senseritems);

}
//Get api/commands/{Id}
[HttpGet("{MAC_No}",Name="GetSensorByMAC")]
public ActionResult <SimMaster> GetSensorByMAC(string mac)
{
var Senseritem=_repository.GetSensorByMAC(mac);
if(Senseritem!= null)
{
return Ok (Senseritem);
}
return NotFound();
}
    [HttpPost]
 public ActionResult CreateCommand(SensorMaster sens)
 {
     
     _repository.CreateCommand(sens);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetSensorByMAC), new {mac=sens.MAC_No},sens);
     
 }
 [HttpPut("{MAC_No}")]
public ActionResult UpdateCommand(string mac ,SensorUpdateDto sensorupdatedto)
{
var SensorModelRepo=_repository.GetSensorByMAC(mac);
if(SensorModelRepo==null)
{
    return NotFound();
}
_mapper.Map(sensorupdatedto,SensorModelRepo);
_repository.UpdateCommand(SensorModelRepo);
_repository.SaveChanges();
return NoContent();
}
}
}


