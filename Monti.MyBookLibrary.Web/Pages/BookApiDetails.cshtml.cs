using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monti.MyBookLibrary.Data;
using Monti.MyBookLibrary.Web.Data.Models;
using Monti.MyBookLibrary.Web.Models;
using Monti.MyBookLibrary.Web.Services;

namespace Monti.MyBookLibrary.Web
{
    [AllowAnonymous]
    public class BookApiDetailsModel : PageModel
    {
        private readonly IBookApiDataService _bookApiDataService;
        private readonly IBooksRepository _booksRepository;
        public Task<Details> BookApiDetails { get; set; }
        public Book BookDetails { get; set; }

        public BookApiDetailsModel(IBookApiDataService bookApiDataService, IBooksRepository booksRepository)
        {
            _bookApiDataService = bookApiDataService;
            _booksRepository = booksRepository;
        }
        public async Task<IActionResult> OnGet(string Isbn)
        {
            var bookApiDetails = await _bookApiDataService.GetBookDetails(Isbn);
            var newBook = new Book();
            newBook.Title = bookApiDetails.title ?? "";
            newBook.Author = bookApiDetails.authors?.FirstOrDefault()?.name ?? "no";
            newBook.CreationDate = DateTime.Now;
            newBook.IsRead = false;

            _booksRepository.Insert(newBook);

            return RedirectToPage("/Index");
        }
    }
}