using System;
using System.Collections.Generic;
using System.Linq;
using Consistrack.Models;
using Consistrack.Interface;

namespace Consistrack.Data
{
    public class SqlSensorMasterRepo : ISensorMasterRepo
    {
        private readonly ConsistrackContext _Context;

        public SqlSensorMasterRepo(ConsistrackContext Context)
        {
            _Context=Context;
        }
        
        public void CreateCommand(SensorMaster sens)
        {
             if(sens== null)
            {
                throw new ArgumentNullException(nameof(sens));
            }
             sens.SensorId=GetSensorUId();
        _Context.SensorMasters.Add(sens);

        }

        public void DeleteCommand(int id, bool flag)
        {
          var sensorModelRepo=_Context.SensorMasters.FirstOrDefault(p=> p.Id==id);
         if(sensorModelRepo!=null)
    {
        if(flag==false)
        sensorModelRepo.IsActive=false;
        else
       sensorModelRepo.IsActive=true;
        
    }
        }

        public IEnumerable<SensorMaster> GetAllSensors(int flag)
        {
            
             if(flag==0)
             return  _Context.SensorMasters.Where(p=> p.IsActive==false).ToList();
             else if(flag==1)
             return  _Context.SensorMasters.Where(p=> p.IsActive==true).ToList();
             else
             return  _Context.SensorMasters.ToList();        }

        public SensorMaster GetSensorById(int id)
        {
            return  _Context.SensorMasters.FirstOrDefault(p=> p.Id==id);
        }

        public string GetSensorUId()
        {
            string id;
           // SimMaster s1 = new SimMaster();
           var usensorid=_Context.SensorMasters.OrderBy(s => s.Id).LastOrDefault();
            if(usensorid==null)
            id="SENS1";
            else
            id="SENS"+(Convert.ToInt32(usensorid.SensorId.Substring(4,(usensorid.SensorId.Length-4)))+1).ToString();
            return id;
        }

        public bool SaveChanges()
        {
            return  (_Context.SaveChanges() >=0);
        }

        public void UpdateCommand(SensorMaster sens)
        {
            //Nothing
        }
    }}
