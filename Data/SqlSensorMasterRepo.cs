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
        _Context.SensorMasters.Add(sens);

        }
        
        public IEnumerable<SensorMaster> GetAllSensors()
        {
            
             return  _Context.SensorMasters.ToList();
        }

        public SensorMaster GetSensorByMAC(string mac)
        {
            return  _Context.SensorMasters.FirstOrDefault(p=> p.MAC_No==mac);
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
