using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Monti.MyBookLibrary.Data;
using Monti.MyBookLibrary.Web.Data.Models;

namespace Monti.MyBookLibrary.Web.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBooksRepository _booksRepository;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
                            IBooksRepository booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;
        }

        public void OnGet()
        {
            Books = _booksRepository.GetAll();
        }

    }
}
