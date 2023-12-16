using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKCITE
{
    class CMOS : CitationStyles, ReferenceStyle
    {
        public CMOS(string[] lastnames, string[] firstnames, string title, string publisher, string publisheraddress, int yearpublished, string Text, int Page)
            : base(lastnames, firstnames, default(char[]), title, publisher, publisheraddress, yearpublished, Text, Page)
        {
        }
        public override string CitationFormat()
        {
            if (AuthorLastnames.Length >= 3)
            {
                return $"{AuthorLastnames[0]}, {AuthorFirstnames[0]}, et al. {Title}. {PublisherAddress}: {Publisher}, {YearPublished}.";
            }
            else
            {
                StringBuilder authors = new StringBuilder();
                for (int i = 0; i < AuthorLastnames.Length; i++)
                {
                    authors.Append($"{AuthorLastnames[i]}, {AuthorFirstnames[i]}");
                    if (i < AuthorLastnames.Length - 1)
                    {
                        authors.Append(" & ");
                    }
                }
                return $"{authors.ToString()}. {Title}. {PublisherAddress}: {Publisher}, {YearPublished}.";
            }
        }
    }
}