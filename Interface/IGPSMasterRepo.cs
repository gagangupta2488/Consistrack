using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface IGPSMasterRepo{
      bool SaveChanges();

    IEnumerable <GPSMaster> GetAllGPSs(int flag);
    GPSMaster GetGPSById(int id);
     void CreateCommand(GPSMaster gps);
    void UpdateCommand(GPSMaster gps);
    void DeleteCommand(int id);
    string GetGpsUId();


    }

    }
