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
            sim.ATSN=GetATSNUId();
        _Context.SimMasters.Add(sim);

        }

        public void DeleteCommand(int id, bool flag)
        {
            var simModelRepo=_Context.SimMasters.FirstOrDefault(p=> p.Id==id);
         if(simModelRepo!=null)
    {
        if(flag==false)
        simModelRepo.IsActive=false;
        else
       simModelRepo.IsActive=true;
        
    }
        }

        public IEnumerable<SimMaster> GetAllSims(int flag)
        {
             if(flag==0)
             return  _Context.SimMasters.Where(p=> p.IsActive==false).ToList();
             else if(flag==1)
             return  _Context.SimMasters.Where(p=> p.IsActive==true).ToList();
             else
             return  _Context.SimMasters.ToList();
        }

        public string GetATSNUId()
        { 
           string id;
           var uatsn=_Context.SimMasters.OrderBy(s => s.Id).LastOrDefault();
            if(uatsn==null)
            id="ATSN1";
            else
            id="ATSN"+(Convert.ToInt32(uatsn.ATSN.Substring(4,(uatsn.ATSN.Length-4)))+1).ToString();
            return id;
        }

        public  SimMaster GetSimById(int id)
        {
             return  _Context.SimMasters.FirstOrDefault(p=> p.Id==id);
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