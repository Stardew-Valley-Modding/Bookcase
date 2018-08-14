using System.Collections;
using System.Collections.Generic;

namespace Bookcase.Events {

    /// <summary>
    /// Defines the various priority values.
    /// </summary>
    public class Priority {

        /// <summary>
        /// This will happen first.
        /// </summary>
        public const int highest = 0;

        /// <summary>
        /// This is not first, but before normal.
        /// </summary>
        public const int high = 1;

        /// <summary>
        /// This is the normal priority.
        /// </summary>
        public const int normal = 2;

        /// <summary>
        /// This is not last, but after normal.
        /// </summary>
        public const int low = 3;

        /// <summary>
        /// This will happen last.
        /// </summary>
        public const int lowest = 4;

        /// <summary>
        /// An array for all the priorities.
        /// </summary>
        public static readonly int[] priorities = { highest, high, normal, low, lowest };
    }
}