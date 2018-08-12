using System;
using System.Collections.Generic;
using System.Reflection;
using Bookcase.Harmony;

namespace Bookcase.Patches {

    class PatchManager {

        private IHarmonyInstance harmony;

        /// <summary>
        /// List of loaded patches. Please don't reflect this.
        /// </summary>
        private List<IGamePatch> gamePatches;

        public PatchManager() {

            this.harmony = LoadHarmony();

            if (harmony != null) {

                BookcaseMod.logger.Info($"Loaded Harmony {harmony.Version}.");
                this.Load();
                this.Apply();
            }

            else {

                BookcaseMod.logger.Error("Failed to load Harmony. Mod will still run but no patches are applied. Things wont work right!");
            }
        }

        /// <summary>
        /// Attempt to load an instance of harmony to apply patches with.
        /// </summary>
        /// <returns>The version of harmony that is loaded.</returns>
        private static IHarmonyInstance LoadHarmony() {

            IHarmonyInstance instance = null;

            // Try to load the harmony that is bundled with bookcase.
            try {

                instance = new HarmonyBundled();
            }

            catch (Exception e) {

                BookcaseMod.logger.Error($"Failed to load bundled Harmony instance. {e.ToString()}");
            }

            // If the bundled instance failed to load, attempt to use the fallback smapi harmony instance.
            if (instance == null) {

                try {

                    instance = new HarmonyFallback();
                }

                catch (Exception e) {

                    BookcaseMod.logger.Error($"Failed to load fallback Harmony instance. {e.ToString()}");
                }
            }

            return instance;
        }

        /// <summary>
        /// Analyzes the current assembly and try to load patches from it. Patches must implement IGamePatch.
        /// </summary>
        private void Load() {

            this.gamePatches = new List<IGamePatch>();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type typePatch = typeof(IGamePatch);

            // Loop through all the types in the Bookcase assembly.
            foreach (Type type in assembly.GetTypes()) {

                // Check if the type implements the IGamePatch interface.
                if (Array.Exists(type.GetInterfaces(), element => element == typePatch)) {

                    // Iterate constructors and find one that can be loaded.
                    foreach (ConstructorInfo constructor in type.GetConstructors()) {

                        // Check if the constructor has no parameters. 
                        if (constructor.GetParameters().Length == 0) {

                            try {

                                // Try to create an instance of the patch object and load it into our registry.
                                IGamePatch patch = Activator.CreateInstance(type) as IGamePatch;
                                this.gamePatches.Add(patch);
                            }


                            catch (Exception e) {

                                // Rat out the bad bois
                                BookcaseMod.logger.Debug($"Failed to construct patch {type.FullName} with error {e.ToString()}.");
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
                    harmony.PatchMethod(patch.TargetMethod, harmony.GetHarmonyMethod(type, "Prefix"), harmony.GetHarmonyMethod(type, "Postfix"), harmony.GetHarmonyMethod(type, "Transpile"));
                }

                catch (Exception e) {

                    BookcaseMod.logger.Error($"Patch failed: {e.ToString()}");
                }
            }
        }
    }
}