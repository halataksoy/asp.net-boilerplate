using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Xelat.Project.Customers;


[Table("customers")]
public class customer : FullAuditedEntity, IMustHaveTenant
{
    public int TenantId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string GsmNo { get; set; }
}