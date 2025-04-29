using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Program
    {
        public static void Main()
        {
            var chat = new Chat("MyChat");

            Console.WriteLine("Initial chat state:");
            Console.WriteLine(chat.GetChatInfo());
        }
    }
}
