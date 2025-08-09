
namespace BooklyBookStoreApp.Application.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found")
        {
        }
    }
}
