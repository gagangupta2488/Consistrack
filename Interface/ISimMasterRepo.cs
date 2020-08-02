using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface ISimMasterRepo{
    bool SaveChanges();

    IEnumerable <SimMaster> GetAllSims();
    SimMaster GetSimById(int id);
   void CreateCommand(SimMaster sim);
    void UpdateCommand(SimMaster sim);
    string GetATSNUId();


    }

    }
