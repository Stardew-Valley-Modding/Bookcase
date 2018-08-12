using System;
using System.Reflection;

namespace Bookcase.Harmony {

    /// <summary>
    /// An interface used to define an instance of the harmony library and what we need from it. 
    /// </summary>
    internal interface IHarmonyInstance {

        /// <summary>
        /// The version of harmony loaded.
        /// </summary>
        String Version { get;}

        /// <summary>
        /// Applies patches to the method.
        /// </summary>
        /// <param name="target">The target method.</param>
        /// <param name="prefix">A prefix patch applied to start of method.</param>
        /// <param name="postfix">A postfix patch applied to end of method.</param>
        /// <param name="transpile">A transpile patch which rewrites the method.</param>
        void PatchMethod(MethodBase target, Object prefix, Object postfix, Object transpile);

        /// <summary>
        /// Look up code for getting a HarmonyMethod by name. 
        /// </summary>
        /// <param name="type">The type to load method from.</param>
        /// <param name="name">The name of the method.</param>
        /// <returns></returns>
        object GetHarmonyMethod(Type type, String name);
    }
}