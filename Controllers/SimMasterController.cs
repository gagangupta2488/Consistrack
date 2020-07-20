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
   
    public ActionResult <IEnumerable<SimMaster>> GetAllSims()
{
    var SimItems=_repository.GetAllSims();
    return Ok(SimItems);

}
//Get api/commands/{Id}
[HttpGet("{ATSN}",Name="GetSimByATSN")]
public ActionResult <SimMaster> GetSimByATSN(string atsn)
{
var SimItem=_repository.GetSimByATSN(atsn);
if(SimItem!= null)
{
return Ok (SimItem);
}
return NotFound();
}
    [HttpPost]
 public ActionResult CreateCommand(SimMaster sim)
 {
     
     _repository.CreateCommand(sim);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetSimByATSN), new {atsn=sim.ATSN},sim);
     
 }
 [HttpPut("{ATSN}")]
public ActionResult UpdateCommand(string atsn ,SimUpdateDto simupdatedto)
{
var SimModelRepo=_repository.GetSimByATSN(atsn);
if(SimModelRepo==null)
{
    return NotFound();
}
_mapper.Map(simupdatedto,SimModelRepo);
_repository.UpdateCommand(SimModelRepo);
_repository.SaveChanges();
return NoContent();
}
}
}


