using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models;

// LibraryBranch.cs
public class LibraryBranch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LibraryBranchId { get; set; }
    public required string BranchName { get; set; }
}
