using AutoMapper;
using Sample.IoC.Domain.Entities;
using Sample.IoC.Resources;

namespace Sample.IoC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Movie, MovieResource>();
        }
    }
}
