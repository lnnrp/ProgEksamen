using System;

namespace Observer
{
    public class Event
    {
        // Collection of all listeners that will be notified when event happens
        private List<IListener> listeners = new List<IListener>();

        // Title of event (not necessarily needed, but can be good for debugging etc)
        public string EventTitle { get; set; }

        public Event(string title)
        {
            EventTitle = title;
            Console.WriteLine("New event added: " + title);
        }

        /// <summary>
        /// Attaches a new listener to the event
        /// </summary>
        /// <param name="listener">The specific listener that gets attached</param>
        public void Attach(IListener listener)
        {
            listeners.Add(listener);
        }

        /// <summary>
        /// Detaches a listener from the event
        /// </summary>
        /// <param name="listener">The specific listener to detach</param>
        public void Detach(IListener listener)
        {
            listeners.Remove(listener);
        }

        /// <summary>
        /// Notifies all listeners that event has occured
        /// </summary>
        public void Notify()
        {
            foreach(IListener listener in listeners)
            {
                listener.Notify(EventTitle);
            }
        }
    }
}
