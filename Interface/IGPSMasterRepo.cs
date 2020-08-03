using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface IGPSMasterRepo{
      bool SaveChanges();

    IEnumerable <GPSMaster> GetAllGPSs();
    GPSMaster GetGPSById(int id);
     void CreateCommand(GPSMaster gps);
    void UpdateCommand(GPSMaster gps);
    string GetGpsUId();


    }

    }
