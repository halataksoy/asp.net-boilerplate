using System.ComponentModel.DataAnnotations.Schema;
using Xelat.Project.Customers;
using Xelat.Project.MultiTenancy;

namespace Xelat.Project.Products.Dto;

public class ProductDto
{
    public int? CustomerId { get; set; }
    public int? TenantId { get; set; }
    public int ProductId { get; set; }
}