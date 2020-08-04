using System.Collections.Generic;
using AutoMapper;
using Consistrack.Data;
using Consistrack.Dtos;
using Consistrack.Models;
using Microsoft.AspNetCore.Mvc;
using Consistrack.Interface;
using ClosedXML.Excel;
using System.IO;
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
   
    public ActionResult <IEnumerable<GPSMaster>> GetAllGPSs(int flag)
{
    var GPSItems=_repository.GetAllGPSs(flag);
    return Ok(GPSItems);

}
//Get api/commands/{Id}
[HttpGet("{Id}",Name="GetGPSById")]
public ActionResult <GPSMaster> GetGPSById(int id)
{
var GPSItem=_repository.GetGPSById(id);
if(GPSItem!= null)
{
return Ok (GPSItem);
}
return NotFound();
}
    
    [Route("CreateCommand")]
    [ActionName("CreateCommand")]
    [HttpPost]
 public ActionResult CreateCommand(GPSMaster gps)
 {
     
     _repository.CreateCommand(gps);
     _repository.SaveChanges();
     return CreatedAtRoute(nameof(GetGPSById), new {id=gps.Id},gps);
     
 }
 [HttpPut("{Id}")]
public ActionResult UpdateCommand(int id ,GPSUpdateDto gpsupdatedto)
{
var gpsModelRepo=_repository.GetGPSById(id);
if(gpsModelRepo==null)
{
    return NotFound();
}
_mapper.Map(gpsupdatedto,gpsModelRepo);
_repository.UpdateCommand(gpsModelRepo);
_repository.SaveChanges();
return NoContent();
}
[HttpDelete("{Id}")]
public ActionResult DeleteCommand(int id )
{
_repository.DeleteCommand(id);
_repository.SaveChanges();
return NoContent();
}

// [Route("ExportExcel")]
// [HttpGet]
// [ActionName("ExportExcel")]
// public IActionResult ExportExcel()
// {
//     using (var workbook = new XLWorkbook())
//     {
//         var worksheet = workbook.Worksheets.Add("GpsMaster");
//         var currentRow = 1;
//         worksheet.Cell(currentRow, 1).Value = "Id";
//         worksheet.Cell(currentRow, 2).Value = "Vender";
//         worksheet.Cell(currentRow, 3).Value = "DOP";
//         worksheet.Cell(currentRow, 4).Value = "DeviceModel";
//         worksheet.Cell(currentRow, 5).Value = "ATModel";
//         worksheet.Cell(currentRow, 6).Value = "IMEINo";
//         worksheet.Cell(currentRow, 7).Value = "Status";
//         worksheet.Cell(currentRow, 8).Value = "Remark";
//         worksheet.Cell(currentRow, 9).Value = "CreatedBy";
//         worksheet.Cell(currentRow, 10).Value = "CreatedDT";
//         worksheet.Cell(currentRow, 11).Value = "UpdatedBy";
//         worksheet.Cell(currentRow, 12).Value = "UpdatedDT";
//         worksheet.Cell(currentRow, 13).Value = "IsActive";
//        var GPSItems=_repository.GetAllGPSs();

//         foreach (var gps in GPSItems)
//         {
//             currentRow++;
        
//         worksheet.Cell(currentRow, 1).Value = gps.Id;
//         worksheet.Cell(currentRow, 2).Value = gps.Vender;
//         worksheet.Cell(currentRow, 3).Value = gps.DOP;
//         worksheet.Cell(currentRow, 4).Value = gps.DeviceModel;
//         worksheet.Cell(currentRow, 5).Value = gps.ATModel;
//         worksheet.Cell(currentRow, 6).Value = gps.IMEINo;
//         worksheet.Cell(currentRow, 7).Value = gps.Status;
//         worksheet.Cell(currentRow, 8).Value = gps.Remark;
//         worksheet.Cell(currentRow, 9).Value = gps.CreatedBy;
//         worksheet.Cell(currentRow, 10).Value = gps.CreatedDT;
//         worksheet.Cell(currentRow, 11).Value = gps.UpdatedBy;
//         worksheet.Cell(currentRow, 12).Value = gps.UpdatedDT;
//         worksheet.Cell(currentRow, 13).Value = gps.IsActive;
//         }

//         using (var stream = new MemoryStream())
//         {
//             workbook.SaveAs(stream);
//             var content = stream.ToArray();

//             return File(
//                 content,
//                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
//                 "gps.xlsx");
//         }
//     }
// }
[Route("GetGPSUId")]
[HttpGet]
[ActionName("GetGPSUId")]
public ActionResult <string> GetGpsUId()
{
    return _repository.GetGpsUId();
}


        }  
    }  





