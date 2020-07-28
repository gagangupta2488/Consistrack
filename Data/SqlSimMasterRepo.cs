using System;
using System.Collections.Generic;
using System.Linq;
using Consistrack.Models;
using Consistrack.Interface;
namespace Consistrack.Data
{
    public class SqlSimMasterRepo : ISimMasterRepo
    {
        private readonly ConsistrackContext _Context;

        public SqlSimMasterRepo(ConsistrackContext Context)
        {
            _Context=Context;
        }
        public void  CreateCommand(SimMaster sim)
        {
             if(sim== null)
            {
                throw new ArgumentNullException(nameof(sim));
            }
        _Context.SimMasters.Add(sim);

        }

        public IEnumerable<SimMaster> GetAllSims()
        {
             return  _Context.SimMasters.ToList();
        }

        public string GetATSNUId()
        { 
           // SimMaster s1 = new SimMaster();
           var uatsn=_Context.SimMasters.OrderBy(s => s.ATSN).LastOrDefault();
            if(uatsn.ATSN==null)
            uatsn.ATSN="ATSN1";
            else
            uatsn.ATSN="ATSN"+(Convert.ToInt32(uatsn.ATSN.Substring(4,(uatsn.ATSN.Length-4)))+1).ToString();
            return uatsn.ATSN;
        }

        public  SimMaster GetSimByATSN(string atsn)
        {
             return  _Context.SimMasters.FirstOrDefault(p=> p.ATSN==atsn);
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