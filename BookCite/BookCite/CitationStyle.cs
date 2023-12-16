using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKCITE
{
    public abstract class CitationStyles
    {
        public string[] AuthorLastnames;
        public string[] AuthorFirstnames;
        public char[] AuthorMiddleInitial;
        public string Title;
        public string Publisher;
        public string PublisherAddress;
        public int YearPublished;
        public int Page;
        public string Text;
        public CitationStyles(string[] lastnames, string[] firstnames, char[] middleinitial, string title, string publisher, string publisheraddress, int yearpublished, string text, int page)
        {
            AuthorLastnames = lastnames;
            AuthorFirstnames = firstnames;
            AuthorMiddleInitial = middleinitial;
            Title = title;
            Publisher = publisher;
            PublisherAddress = publisheraddress;
            YearPublished = yearpublished;
            Page = page;
            Text = text;
        }
        public abstract string CitationFormat();
    }
}
