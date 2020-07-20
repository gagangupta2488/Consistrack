using System.Collections.Generic;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Dtos;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
using Consistrack.Interface;
namespace Consistrack.Controllers
{
[Route("api/GpsMaster")]
    [ApiController]
    //Get api/Commands
public class GPSMasterControl:ControllerBase
{
        private readonly IGPSMasterRepo _repository;
       private readonly IMapper _mapper;

        public GPSMasterControl(IGPSMasterRepo repository,IMapper mapper)
   {
       _repository=repository;
       _mapper=mapper;
   }
   
    [HttpGet]
   
    public ActionResult <IEnumerable<GPSMaster>> GetAllGPSs()
{
    var GPSItems=_repository.GetAllGPSs();
    return Ok(GPSItems);

}
//Get api/commands/{Id}
[HttpGet("{IMEI}",Name="GetGPSByIMEI")]
public ActionResult <GPSMaster> GetGPSByIMEI(string imei)
{
var GPSItem=_repository.GetGPSByIMEI(imei);
if(GPSItem!= null)
{
return Ok (GPSItem);
}
return NotFound();
}
    [HttpPost]
 public ActionResult CreateCommand(GPSMaster gps)
 {
     
     _repository.CreateCommand(gps);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetGPSByIMEI), new {imei=gps.IMEI},gps);
     
 }
 [HttpPut("{IMEI}")]
public ActionResult UpdateCommand(string imei ,GPSUpdateDto gpsupdatedto)
{
var gpsModelRepo=_repository.GetGPSByIMEI(imei);
if(gpsModelRepo==null)
{
    return NotFound();
}
_mapper.Map(gpsupdatedto,gpsModelRepo);
_repository.UpdateCommand(gpsModelRepo);
_repository.SaveChanges();
return NoContent();
}
}
}


