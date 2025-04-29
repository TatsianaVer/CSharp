using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Chat
    {
        private readonly string _chatName;
        private readonly UserList _users = new UserList();
        private readonly BadWordFilter _badWordFilter = new BadWordFilter();
        private readonly MessageLog _messageLog;

        public Chat(string chatName)
        {
            if (string.IsNullOrWhiteSpace(chatName))
                throw new ArgumentException("Chat name required", nameof(chatName));

            _chatName = chatName;
            _messageLog = new MessageLog(_badWordFilter);
        }

        public string ChatName => _chatName;
        public int UsersCount => _users.Count;
        public int MessagesCount => _messageLog.Count;

        public void AddUser(string username) => _users.Add(username);
        public void RemoveUser(string username) => _users.Remove(username);
        public bool AddMessage(string username, string message) => _messageLog.Add(username, message);
        public void AddBadWord(string badWord) => _badWordFilter.Add(badWord);

        public string GetChatInfo() =>
            $"Chat: {ChatName}, Users: {UsersCount}, Messages: {MessagesCount}, " +
            $"Participants: {(UsersCount > 0 ? _users.ToString() : "none")}";
    }
}
