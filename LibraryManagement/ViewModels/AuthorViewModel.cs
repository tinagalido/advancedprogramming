// AuthorViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels;

public class AuthorViewModel
{
    [Key]
    public int AuthorId { get; set; }
    public required string AuthorName { get; set; }
}