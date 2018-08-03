using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bookcase.Patches {

    class PatchManager {

        /// <summary>
        /// Bookcases specific harmony instance. If you want to patch the game use your own!
        /// </summary>
        private readonly HarmonyInstance harmony;

        /// <summary>
        /// List of loaded patches. Please don't reflect this.
        /// </summary>
        private List<IGamePatch> gamePatches;

        public PatchManager() {

            BookcaseMod.logger.Debug("Creating harmony instance...");
            harmony = HarmonyInstance.Create("net.darkhax.bookcase");

            this.Load();
            this.Apply();
        }

        /// <summary>
        /// Analyzes the current assembly and try to load patches from it. Patches must implement IGamePatch.
        /// </summary>
        private void Load() {

            this.gamePatches = new List<IGamePatch>();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type typePatch = typeof(IGamePatch);

            // Loop through all the types in the Bookcase assembly.
            foreach(Type type in assembly.GetTypes()) {

                // Check if the type implements the IGamePatch interface.
                if (Array.Exists(type.GetInterfaces(), element => element == typePatch)) {

                    // Iterate constructors and find one that can be loaded.
                    foreach(ConstructorInfo constructor in type.GetConstructors()) {

                        // Check if the constructor has no parameters. 
                        if (constructor.GetParameters().Length == 0) {
                            
                            try {

                                // Try to create an instance of the patch object and load it into our registry.
                                IGamePatch patch = Activator.CreateInstance(type) as IGamePatch;
                                this.gamePatches.Add(patch);
                            }


                            catch(Exception e) {

                                // Rat out the bad bois
                                BookcaseMod.logger.Debug($"Failed to construct patch {type.FullName} with error {e.Message}.");
                            }

                            // Only one valid constructor per class.
                            break;
                        }
                    }
                }
            }

            BookcaseMod.logger.Debug($"Loaded {this.gamePatches.Count} patches!");
        }

        /// <summary>
        /// Loop through all of the loaded bookcase game patches, and apply them to the game.
        /// </summary>
        private void Apply() {

            // Loop through all the game patches.
            foreach (IGamePatch patch in gamePatches) {

                try {

                    BookcaseMod.logger.Debug($"Patching {patch.TargetType.ToString()} - {patch.TargetMethod.ToString()}");

                    Type type = patch.GetType();

                    // Search for Prefix, Postfix, Transpile methods from type to patch in to target method.
                    harmony.Patch(patch.TargetMethod, FindMethod(type, "Prefix"), FindMethod(type, "Postfix"), FindMethod(type, "Transpile"));
                }

                catch (Exception e) {

                    BookcaseMod.logger.Error($"Patch failed: {e.ToString()}");
                }
            }
        }

        /// <summary>
        /// Attempts to find a method in a class, and return the harmony method for it.
        /// </summary>
        /// <param name="type">The type to search in.</param>
        /// <param name="name">The name of the target method.</param>
        /// <returns>The harmony method, or null if it was not found.</returns>
        private HarmonyMethod FindMethod(Type type, String name) {

            MethodInfo method = type.GetMethod(name);
            return method != null ? new HarmonyMethod(method) : null;
        }
    }
}
