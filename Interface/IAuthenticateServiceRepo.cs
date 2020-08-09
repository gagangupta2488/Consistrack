using Consistrack.Models;

namespace Consistrack.Interface
{
    public interface IAuthenticateServiceRepo
    {
        
        UserMaster Authenticate (string lLoginid, string password);
    }
}