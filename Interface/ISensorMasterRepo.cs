using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface ISensorMasterRepo{
      bool SaveChanges();

    IEnumerable <SensorMaster> GetAllSensors(int flag);
    SensorMaster GetSensorById(int id);
     void CreateCommand(SensorMaster sens);
    void UpdateCommand(SensorMaster sens);
    void DeleteCommand(int id,bool flag);
    string GetSensorUId();



    }

    }
