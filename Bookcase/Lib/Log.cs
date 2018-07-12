using StardewModdingAPI;

namespace Bookcase {

    public class Log {

        /// <summary>
        /// Holds the monitor instance used by the logger instance.
        /// </summary>
        private readonly IMonitor monitor;

        /// <summary>
        /// Constructs a new logger using a mod instance.
        /// </summary>
        /// <param name="mod">The instance of the mod used to create the logger.</param>
        public Log(Mod mod) : this(mod.Monitor) {}

        /// <summary>
        /// Constructs a new logger using an IMonitor instance. This is commonly obtained from a mod. 
        /// </summary>
        /// <param name="monitor">The IMonitor to use for logging.</param>
        public Log(IMonitor monitor) {

            this.monitor = monitor;
        }

        /// <summary>
        /// Allows a caught exception to be resolved by throwing it to the logger.
        /// </summary>
        /// <param name="message">The message to put in console.</param>
        public void Trace(string message) {

            this.monitor.Log(message, LogLevel.Trace);
        }

        /// <summary>
        /// Prints a debug message to the console.
        /// </summary>
        /// <param name="message">The message to put in the console.</param>
        public void Debug(string message) {

            this.monitor.Log(message, LogLevel.Debug);
        }

        /// <summary>
        /// Prints an info message to the console.
        /// </summary>
        /// <param name="message">The message to put in the console.</param>
        public void Info(string message) {

            this.monitor.Log(message, LogLevel.Info);
        }

        /// <summary>
        /// Prints a warning message to the console.
        /// </summary>
        /// <param name="message">The message to put in the console.</param>
        public void Warn(string message) {

            this.monitor.Log(message, LogLevel.Warn);
        }

        /// <summary>
        /// Prints an error message to the console.
        /// </summary>
        /// <param name="message">The message to put in the console.</param>
        public void Error(string message) {

            this.monitor.Log(message, LogLevel.Warn);
        }

        /// <summary>
        /// Prints an alert message to the console.
        /// </summary>
        /// <param name="message">The message to put in the console.</param>
        public void Alert(string message) {

            this.monitor.Log(message, LogLevel.Alert);
        }
    }
}
