using System;
using System.Collections.Generic;
using System.Linq;
using Consistrack.Models;

namespace Consistrack.Data
{
    public class SqlSimMasterRepo : ISimMasterRepo
    {
        private readonly ConsistrackContext _Context;

        public SqlSimMasterRepo(ConsistrackContext Context)
        {
            _Context=Context;
        }
        public async void  CreateCommand(SimMaster sim)
        {
             if(sim== null)
            {
                throw new ArgumentNullException(nameof(sim));
            }
       await _Context.SimMasters.Add(sim);

        }

        public async IEnumerable<SimMaster> GetAllSims()
        {
             return await _Context.SimMasters.ToList();
        }

        public async SimMaster GetSimByATSN(string atsn)
        {
             return await _Context.SimMasters.FirstOrDefault(p=> p.ATSN==atsn);
        }

        public bool SaveChanges()
        {
            return  (_Context.SaveChanges() >=0);
        }

        public void UpdateCommand(SimMaster sim)
        {
            //Nothing
        }
    }
}