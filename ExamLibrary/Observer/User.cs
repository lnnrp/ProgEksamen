using System;

namespace Observer
{
    public class User : IListener
    {
        private string userName;

        public User(string userName)
        {
            this.userName = userName;

            Console.WriteLine("New user added: " + userName);
        }

        /// <summary>
        /// Gets called when user is notified and event occurs
        /// </summary>
        /// <param name="title"></param>
        public void Notify(string title)
        {
            Console.WriteLine($"User {userName} has been notified of event: {title}");
        }
    }
}
