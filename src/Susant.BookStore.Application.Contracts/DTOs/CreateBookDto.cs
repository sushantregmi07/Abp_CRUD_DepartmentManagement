namespace Susant.BookStore.DTOs;

public class CreateBookDto
{
    public string Name { get; set; }
    public string Author { get; set; }
    public long ShelfId { get; set; }
}