using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Data
{
    
    public interface ISimMasterRepo{
      bool SaveChanges();

    IEnumerable <SimMaster> GetAllSims();
    SimMaster GetSimByATSN(string atsn);
     void CreateCommand(SimMaster sim);
    void UpdateCommand(SimMaster sim);


    }

    }
