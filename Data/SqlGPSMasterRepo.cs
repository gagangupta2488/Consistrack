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

        public IEnumerable<GPSMaster> GetAllGPSs()
        {
             return  _Context.GPSMasters.ToList();
        }

        public  GPSMaster GetGPSByIMEI(string imei)
        {
             return  _Context.GPSMasters.FirstOrDefault(p=> p.IMEINo==imei);
        }

        public string GetGpsUId()
        {
var ugpsid=_Context.GPSMasters.OrderBy(s => s.GPSId).LastOrDefault();
            if(ugpsid.GPSId==null)
            ugpsid.GPSId="GPS1";
            else
            ugpsid.GPSId="GPS"+(Convert.ToInt32(ugpsid.GPSId.Substring(3,(ugpsid.GPSId.Length-3)))+1).ToString();
            return ugpsid.GPSId;        }

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