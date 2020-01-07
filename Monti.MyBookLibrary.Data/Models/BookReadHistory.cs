using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monti.MyBookLibrary.Data.Models
{
    [Table("ReadHistories")]
    public class BookReadHistory
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public DateTime ReadStart { get; set; }

        public DateTime? ReadEnd { get; set; }

        public string Notes { get; set; }
        /*
         * Id	int	Unchecked
BookId	int	Unchecked
ReadStart	date	Unchecked
ReadEnd	date	Checked
Notes	nvarchar(MAX)	Checked
         * */
    }
}
