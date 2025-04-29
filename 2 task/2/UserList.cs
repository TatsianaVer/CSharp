// See https://aka.ms/new-console-template for more information
namespace Chat
{
    internal class UserList
    {
        private readonly List<string> _users = new List<string>();

        public int Count => _users.Count;

        public void Add(string username)
        {
            if (!_users.Any(u => u.Equals(username, StringComparison.OrdinalIgnoreCase)))
                _users.Add(username);
        }

        public void Remove(string username) =>
            _users.RemoveAll(u => u.Equals(username, StringComparison.OrdinalIgnoreCase));

        public override string ToString() => string.Join(", ", _users);
    }
}
