using Abp.Application.Services.Dto;

namespace Xelat.Project.Customers.Inputs;

public class CustomerGetAllInput : PagedAndSortedResultRequestDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
}