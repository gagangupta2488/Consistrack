using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface ISimMasterRepo{
    bool SaveChanges();

    IEnumerable <SimMaster> GetAllSims(int flag);
    SimMaster GetSimById(int id);
   void CreateCommand(SimMaster sim);
    void UpdateCommand(SimMaster sim);
    void DeleteCommand(int id,bool flag);
    string GetATSNUId();


    }

    }
