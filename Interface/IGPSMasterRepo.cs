using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface IGPSMasterRepo{
      bool SaveChanges();

    IEnumerable <GPSMaster> GetAllGPSs();
    GPSMaster GetGPSByIMEI(string imei);
     void CreateCommand(GPSMaster gps);
    void UpdateCommand(GPSMaster gps);
    string GetGpsUId();


    }

    }
