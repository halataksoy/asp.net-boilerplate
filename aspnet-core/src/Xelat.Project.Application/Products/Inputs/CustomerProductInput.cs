using System.ComponentModel.DataAnnotations;

namespace Xelat.Project.Products.Inputs;

public class CustomerProductInput
{
    [Required]
    public int CustomerId { get; set; }
}