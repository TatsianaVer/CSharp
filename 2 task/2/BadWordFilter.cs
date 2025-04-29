using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    internal class BadWordFilter
    {
        private readonly HashSet<string> _badWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public void Add(string word) =>
            _badWords.Add(word.ToLower());

        public bool ContainsBadWord(string message) =>
            _badWords.Any(badWord => message.ToLower().Contains(badWord));
    }
}
