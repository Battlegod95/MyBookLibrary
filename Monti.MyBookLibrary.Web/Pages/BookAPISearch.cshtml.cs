using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monti.MyBookLibrary.Web.Models;
using Monti.MyBookLibrary.Web.Services;

namespace Monti.MyBookLibrary.Web.Pages
{
    [AllowAnonymous]
    public class BookApiSearchModel : PageModel
    {
        private readonly IBookApiDataService _bookApiDataService;
        public IList<Doc> BookList { get; set; }

        [BindProperty]
        public string Title { get; set; }
        public BookApiSearchModel(IBookApiDataService bookApiDataService)
        {
            _bookApiDataService = bookApiDataService;
        }

        public void OnGet()
        {
            BookList = new List<Doc>();
        }

        public async Task OnPost()
        {
            this.BookList = await _bookApiDataService.GetBooksApi(Title);
        }
    }
}