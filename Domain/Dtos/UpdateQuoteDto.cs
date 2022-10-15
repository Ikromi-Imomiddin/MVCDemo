using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UpdateQuoteDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Author { get; set; }
    [Required(ErrorMessage = "Plz fill the description")]
    public string QuoteText { get; set; }
}