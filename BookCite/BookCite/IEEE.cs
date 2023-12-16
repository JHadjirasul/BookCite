using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKCITE
{
    class IEEE : CitationStyles, ReferenceStyle
    {
        public IEEE(string[] lastnames, string[] firstnames, string title, string publisher, string publisheraddress, int yearpublished, string Text, int Page)
            : base(lastnames, firstnames, default(char[]), title, publisher, publisheraddress, yearpublished, Text, Page)
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

                return $"{firstAuthor} {AuthorLastnames[0]}, et al. {Title}. {PublisherAddress}: {Publisher}, {YearPublished}.";
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
                    authors.Append($"{initials} {AuthorLastnames[i]}");
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