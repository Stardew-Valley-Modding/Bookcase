using System.Collections;
using System.Collections.Generic;

namespace Bookcase.Events {

    /// <summary>
    /// An enum containing the various event priorities. 
    /// 
    /// Higher priority events happen first. Lower priority happen last.
    /// </summary>
    public enum Priority {
        /// <summary>
        /// Happen first.
        /// </summary>
        Highest,
        /// <summary>
        /// Happen second.
        /// </summary>
        Hight,
        /// <summary>
        /// Happen third.
        /// </summary>
        Normal,
        /// <summary>
        /// Happen second last.
        /// </summary>
        Low,
        /// <summary>
        /// Happen last.
        /// </summary>
        Lowest };
}