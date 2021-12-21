using AutoMapper;
namespace ReportApp.BLL.Mapper
{
    public class MapperGenericProfile <Entity, EntityDTO> : Profile
        where Entity : class
        where EntityDTO : class
    {
        public MapperGenericProfile()
        {
            CreateMap<Entity, EntityDTO>().ReverseMap();
        }   
    }
}
