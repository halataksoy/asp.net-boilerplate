using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Xelat.Project.Products;
[Table("products")]
public class product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
}