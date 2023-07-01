using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Xelat.Project.Customers;
using Xelat.Project.MultiTenancy;


namespace Xelat.Project.Products;

[Table("productmappings")]
public class ProductMapping : FullAuditedEntity, IMayHaveTenant
{

    public int? CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public customer customer { get; set; }
    
    public int? TenantId { get; set; }
    [ForeignKey("TenantId")]
    public Tenant Tenant { get; set; }

    public int ProductId { get; set; }

}