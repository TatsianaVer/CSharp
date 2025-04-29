using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    internal class MessageLog
    {
        private readonly List<string> _messages = new List<string>();
        private readonly BadWordFilter _badWordFilter;

        public MessageLog(BadWordFilter badWordFilter) =>
            _badWordFilter = badWordFilter;

        public int Count => _messages.Count;

        public bool Add(string username, string message)
        {
            if (_badWordFilter.ContainsBadWord(message)) return false;

            _messages.Add($"{username}: {message}");
            return true;
        }
    }
}
