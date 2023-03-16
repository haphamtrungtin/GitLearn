using AutoMapper;
using GitAPI.DTO;
using GitLearn.Data;

namespace GitAPI.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {
            CreateMap<Team, TeamDTO>().ReverseMap();
        }
    }
}
