using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface ISensorMasterRepo{
      bool SaveChanges();

    IEnumerable <SensorMaster> GetAllSensors();
    SensorMaster GetSensorByMAC(string mac);
     void CreateCommand(SensorMaster sens);
    void UpdateCommand(SensorMaster sens);


    }

    }
