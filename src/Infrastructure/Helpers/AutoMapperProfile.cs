using AutoMapper;
using HomiePages.Domain.Entities;
using System.Linq;

namespace HomiePages.Infrastructure.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<News, News>();
            CreateMap<Layout, Layout>();
            CreateMap<BaseContainer, BaseContainer>();
        }
    }
}