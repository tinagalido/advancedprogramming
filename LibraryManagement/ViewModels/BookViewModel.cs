// BookViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string AuthorName { get; set; }
        public required string BranchName { get; set; }
    }
}