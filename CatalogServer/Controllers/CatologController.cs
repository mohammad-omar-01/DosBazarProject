using CatalogServer.Bazar.Db;
using CatalogServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServer.Controllers
{
    [ApiController]
    public class CatologController : Controller
    {
        BazarDbRepository bazarDbRepository = new BazarDbRepository();

        [HttpPut("Book/{bookId}")]
        public ActionResult<Book> EditBookStock(
            [FromRoute] int bookId,
            [FromBody] StockUpdateDTO StockDTO
        )
        {
            var book = bazarDbRepository.EditStock(bookId, StockDTO.Stock);

            return Ok(book);
        }

        [HttpGet("/Book/{BookId}")]
        public ActionResult<Book> GetBookById(int BookId)
        {
            var book = bazarDbRepository.RetriveBookById(BookId);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("Search/{Topic}")]
        public ActionResult<List<BookSerachTopicDTO>> GetBookByTopic(string Topic)
        {
            var books = bazarDbRepository.RetriveBookByTopic(Topic);
            if (books == null || books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }
    }
}
