using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKCITE
{
    class APA : CitationStyles, ReferenceStyle
    {
        public APA(string[] lastnames, string[] firstnames, char[] middleinitials, string title, string publisher, int yearpublished, string Text, int Page)
            : base(lastnames, firstnames, middleinitials, title, publisher, " ", yearpublished, Text, Page)
        {
        }
        public override string CitationFormat()
        {
            if (AuthorLastnames.Length >= 3)
            {
                StringBuilder firstAuthor = new StringBuilder();
                string[] firstAuthorNames = AuthorFirstnames[0].Split(' ');
                foreach (string name in firstAuthorNames)
                {
                    firstAuthor.Append(Char.ToUpper(name[0])).Append(".");
                }
                return $"{AuthorLastnames[0]}, {firstAuthor}, et al. {AuthorMiddleInitial[0]}. ({YearPublished}). {Title}. {Publisher}.";
            }
            else
            {
                StringBuilder authors = new StringBuilder();
                for (int i = 0; i < AuthorLastnames.Length; i++)
                {
                    string[] names = AuthorFirstnames[i].Split(' ');
                    StringBuilder initials = new StringBuilder();

                    foreach (string name in names)
                    {
                        initials.Append(Char.ToUpper(name[0])).Append(".");
                    }

                    authors.Append($"{AuthorLastnames[i]}, {initials} {AuthorMiddleInitial[i]}.");
                    if (i < AuthorLastnames.Length - 1)
                    {
                        authors.Append(" & ");
                    }
                }
                return $"{authors.ToString()} ({YearPublished}). {Title}. {Publisher}.";
            }
        }
    }
}
