using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monti.MyBookLibrary.Data;
using Monti.MyBookLibrary.Data.Models;
using Monti.MyBookLibrary.Web.Data.Models;

namespace Monti.MyBookLibrary.Web.Pages.Books
{

    [Authorize]
    public class DetailsModel : PageModel
    {
        
        private readonly IBooksRepository _booksRepository;
        public Book Book { get; set; }

        public DetailsModel(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);
        }
    }
}