using System;
using System.Collections.Generic;
using System.Linq;
using Consistrack.Models;
using Consistrack.Interface;

namespace Consistrack.Data
{
    public class SqlGPSMasterRepo : IGPSMasterRepo
    {
        private readonly ConsistrackContext _Context;

        public SqlGPSMasterRepo(ConsistrackContext Context)
        {
            _Context=Context;
        }
        public void  CreateCommand(GPSMaster gps)
        {
             if(gps== null)
            {
                throw new ArgumentNullException(nameof(gps));
            }
           gps.GPSId=GetGpsUId();
        _Context.GPSMasters.Add(gps);

        }

        public void DeleteCommand(int id)
        {
         var gpsModelRepo=_Context.GPSMasters.FirstOrDefault(p=> p.Id==id);
         if(gpsModelRepo!=null)
    {
        gpsModelRepo.IsActive=false;
        
    }
         }


        public IEnumerable<GPSMaster> GetAllGPSs()
        {
             return  _Context.GPSMasters.ToList();
        }

        public  GPSMaster GetGPSById(int id)
        {
             return  _Context.GPSMasters.FirstOrDefault(p=> p.Id==id);
        }

        public string GetGpsUId()
        { 
            string id;
var ugpsid=_Context.GPSMasters.OrderBy(s => s.GPSId).LastOrDefault();
            if(ugpsid==null)
            id="GPS1";
            else
            id="GPS"+(Convert.ToInt32(ugpsid.GPSId.Substring(3,(ugpsid.GPSId.Length-3)))+1).ToString();
            return id;        }

        public bool SaveChanges()
        {
            return  (_Context.SaveChanges() >=0);
        }

        public void UpdateCommand(GPSMaster gps)
        {
            //Nothing
        }
    }
}