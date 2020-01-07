using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monti.MyBookLibrary.Web.Models
{
        public class BookApiDetails
        {
            public string info_url { get; set; }
            public string bib_key { get; set; }
            public string preview_url { get; set; }
            public string thumbnail_url { get; set; }
            public Details details { get; set; }
            public string preview { get; set; }
        }

        public class Details
        {
            //blic string[] publishers { get; set; }
            public string key { get; set; }
            public string[] source_records { get; set; }
            public string title { get; set; }
            public int? number_of_pages { get; set; }
            public int[] covers { get; set; }
            public Created created { get; set; }
            public string[] isbn_13 { get; set; }
            public string full_title { get; set; }
            public string[] isbn_10 { get; set; }
            public int? latest_revision { get; set; }
            public Last_Modified last_modified { get; set; }
            public Author[] authors { get; set; }
            public string publish_date { get; set; }
            public Work[] works { get; set; }
            public Type type { get; set; }
            public int? revision { get; set; }
        }


        public class Created
        {
            public string type { get; set; }
            public DateTime? value { get; set; }
        }

        public class Last_Modified
        {
            public string type { get; set; }
            public DateTime? value { get; set; }
        }

        public class Type
        {
            public string key { get; set; }
        }

        public class Author
        {
            public string name { get; set; }
            public string key { get; set; }
        }

        public class Work
        {
            public string key { get; set; }
        }
}
