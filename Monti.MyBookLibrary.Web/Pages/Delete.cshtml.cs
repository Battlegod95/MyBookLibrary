using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Monti.MyBookLibrary.Data;

namespace Monti.MyBookLibrary.Web
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IBooksRepository _booksRepository;

        public DeleteModel(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void OnGet(int id)
        {
            _booksRepository.Delete(id);
            Response.Redirect("/Index");
        }
    }
}