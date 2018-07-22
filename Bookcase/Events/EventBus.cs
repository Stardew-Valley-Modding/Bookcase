using System.Collections.Generic;

namespace Bookcase.Events {

    /// <summary>
    /// The event bus used by Bookcase. Allows for fairly efficient events with priority and event cancelling. 
    /// </summary>
    /// <typeparam name="T">The event type</typeparam>
    public class EventBus<T> where T : Event {

        /// <summary>
        /// A delegate for the type of method that is a valid listener.
        /// </summary>
        /// <param name="args">Arg type must match the event type.</param>
        public delegate void EventListener(T args);

        /// <summary>
        /// An enum containing the various event priorities. 
        /// 
        /// Higher priority events happen first. Lower priority happen last.
        /// </summary>
        public enum Priority { Highest, Hight, Normal, Low, Lowest };

        /// <summary>
        /// Internal collection of all the applied listeners.
        /// </summary>
        private List<EventListener> listeners = new List<EventListener>();

        /// <summary>
        /// Adds an event listener to this event bus.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        /// <param name="priority">Optional parameter to set the priority of the listener.</param>
        public void Add(EventListener listener, Priority priority = Priority.Normal) {

            // TODO Implement the priority. Not currently used.
            this.listeners.Add(listener);
        }

        /// <summary>
        /// Removes a listener from the bus.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void Remove(EventListener listener) {

            this.listeners.Remove(listener);
        }

        /// <summary>
        /// Sends an event to all of the listeners.
        /// </summary>
        /// <param name="args">The event object to post.</param>
        /// <returns>Whether or not the event was canceled.</returns>
        public bool Post(T args) {

            foreach (var z in this.listeners) {

                z(args);

                if (args.IsCanceled()) {

                    break;
                }
            }

            return args.IsCanceled();
        }
    }
}
