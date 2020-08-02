using System.Collections.Generic;
using Consistrack.Models;

namespace Consistrack.Interface
{
    
    public interface IUserMasterRepo{
      bool SaveChanges();

    IEnumerable <UserMaster> GetAllUsers();
    UserMaster GetUserByIdPwd(string lid,string pwd);
     void CreateCommand(UserMaster user);
    void UpdateCommand(UserMaster user);

    }

    }
