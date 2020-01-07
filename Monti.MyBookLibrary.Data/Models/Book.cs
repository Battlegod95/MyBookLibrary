using Dapper.Contrib.Extensions;
using System;

namespace Monti.MyBookLibrary.Web.Data.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }

        public byte? GenreId { get; set; }

        public DateTime? PublishedDate { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateLastUpdate { get; set; }

        public string ImageUrl { get; set; }

        public byte? Rate { get; set; }

        /*
         * 
         * Id	int	Unchecked
Title	nvarchar(100)	Checked
Author	nvarchar(100)	Unchecked
Description	nvarchar(MAX)	Unchecked
CreationDate	datetime	Unchecked
GenreId	tinyint	Checked
PublishedDate	date	Checked
IsRead	bit	Unchecked
DateLastUpdate	datetime	Checked
ImageUrl	nvarchar(250)	Checked
Rate	tinyint	Checked
         * 
         * 
         */

    }
}
