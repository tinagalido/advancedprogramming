using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models;

// Book.cs
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    public required string Title { get; set; }
    public required int AuthorId { get; set; }
    public required int LibraryBranchId { get; set; }
}



