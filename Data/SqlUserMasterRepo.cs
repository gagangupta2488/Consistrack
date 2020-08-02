using System;
using System.Collections.Generic;
using System.Linq;
using Consistrack.Models;
using Consistrack.Interface;

namespace Consistrack.Data
{
    public class SqlUserMasterRepo : IUserMasterRepo
    {
        private readonly ConsistrackContext _Context;

        public SqlUserMasterRepo(ConsistrackContext Context)
        {
            _Context=Context;
        }
       
        public void CreateCommand(UserMaster user)
        {
             if(user== null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        _Context.UserMasters.Add(user);
        }

        public IEnumerable<UserMaster> GetAllUsers()
        {
            return  _Context.UserMasters.ToList();
       }

        public UserMaster GetUserByIdPwd(string lid, string pwd)
        {
         return  _Context.UserMasters.FirstOrDefault(p=> p.LoginID==lid && p.Password==pwd);                    }

        public bool SaveChanges()
        {
            return  (_Context.SaveChanges() >=0);
        }
        public void UpdateCommand(UserMaster user)
        {
          //Nothing

        }
    }
}