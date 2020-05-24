using AutoMapper;
using Sample.IoC.Domain.Entities;
using Sample.IoC.Resources;

namespace Sample.IoC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveMovieResource, Movie>();
        }
    }
}
