using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Xelat.Project.Customers;


namespace Xelat.Project.Customers.Dto
{
    [AutoMap(typeof(customer))]
    public class CustomerDto: EntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GsmNo { get; set; }
    } 
}
