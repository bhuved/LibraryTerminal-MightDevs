using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal_MightyDevs
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime? DueDate { get; set; } = null;

        public override string ToString()
        {
            return $"{Title}|{Author}|{Status}";
        }

        public string FormatText()
        {
            return $"{Title}     \t\t\t{Author}\t         {Status} {DueDate}";
        }

    }
}
