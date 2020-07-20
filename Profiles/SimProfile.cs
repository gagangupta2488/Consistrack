using AutoMapper;
using Consistrack.Dtos;
using Consistrack.Models;

namespace Commander.profiles
{
    public class SimProfiles:Profile
    {
public SimProfiles()
{
    CreateMap<SimUpdateDto,SimMaster>();
    CreateMap<GPSUpdateDto,GPSMaster>();

}
    }
}