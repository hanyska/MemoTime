using AutoMapper;
using MemoTime.Core.Domain;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Mappers
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Initialize()
            => new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Project, ProjectDto>();
                    cfg.CreateMap<TodoTask, TaskDto>();
                    cfg.CreateMap<Label, LabelDto>()
                        .ForMember(src => src.Name, x => x.MapFrom(z => z.Name));
                })
        .CreateMapper();
    }
}