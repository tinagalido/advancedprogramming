// LibraryBranchViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels;
public class LibraryBranchViewModel
{
    [Key]
    public int LibraryBranchId { get; set; }
    public required string BranchName { get; set; }

}
