namespace ShoppingList.Models
{
    public class ProductDetailsDto
    {
        public string? ProductName { get; set; }

        public List<ProductNoteDto>? ProductNotes { get; set; }
    }
}
