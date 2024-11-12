// CustomerViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels;
public class CustomerViewModel
{
    [Key]
    public int CustomerId { get; set; }
    public required string CustomerName { get; set; }

}
