using AutoMapper;
using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Domain.Enums;
using PIMTool.Core.Dtos.Response;
using PIMTool.Dtos.Requests;
using PIMTool.Dtos.Response;

namespace PIMTool.MappingProfiles
{
    public class ProjectAutoMapperProfile : Profile
    {
        public ProjectAutoMapperProfile()
        {
            CreateMap<Project, ProjectResponse>();
            CreateMap<ProjectCreateRequest, Project>().BeforeMap((src, dest) =>
            {
                dest.Status = nameof(ProjectStatus.NEW);
            });
            CreateMap<ProjectUpdateRequest, Project>()
                .ForAllMembers(config => config.Condition((src, dest, srcValue) => srcValue != null));

            CreateMap<Employee, EmployeeResponse>();
            
            CreateMap<Group, GroupResponse>();
        }
    }
}