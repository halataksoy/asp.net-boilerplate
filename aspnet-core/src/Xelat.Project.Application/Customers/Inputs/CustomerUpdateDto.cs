using Abp.Application.Services.Dto;

namespace Xelat.Project.Customers.Inputs;

public class CustomerUpdateDto : EntityDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
}