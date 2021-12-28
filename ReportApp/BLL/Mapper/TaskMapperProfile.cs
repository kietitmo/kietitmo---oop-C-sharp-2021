using ReportApp.DAL.Entities;
using ReportApp.DTO;

namespace ReportApp.BLL.Mapper
{
    public class TaskMapperProfile : MapperGenericProfile<TaskEntity,TaskDto>
    {
        public TaskMapperProfile() : base() { }
    }
}
