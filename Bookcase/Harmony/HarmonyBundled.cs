using System;
using System.Reflection;
using System.IO;

namespace Bookcase.Harmony {

    /// <summary>
    /// The version of Harmony that is bundled with Bookcase.
    /// </summary>
    internal class HarmonyBundled : IHarmonyInstance {

        private readonly Type harmonyInstance;
        private readonly ConstructorInfo harmonyMethod;
        private readonly MethodBase create;
        private readonly MethodBase patch;

        private readonly Object harmony;
        private readonly Version version;
        public string Version => version.ToString();

        public HarmonyBundled() {

            String localHarmonyPath = $"{BookcaseMod.modHelper.DirectoryPath}{Path.DirectorySeparatorChar}0Harmony.dll";
            String localHarmonyPdb = $"{BookcaseMod.modHelper.DirectoryPath}{Path.DirectorySeparatorChar}0Harmony.pdb";

            byte[] rawAssembly = File.ReadAllBytes(localHarmonyPath);
            byte[] rawSymbolStore = File.ReadAllBytes(localHarmonyPdb);
            Assembly localHarmony = AppDomain.CurrentDomain.Load(rawAssembly, rawSymbolStore);

            BookcaseMod.logger.Info($"Attempting to load the bundled harmony from {localHarmonyPath}");

            this.harmonyInstance = localHarmony.GetType("Harmony.HarmonyInstance");
            this.harmonyMethod = localHarmony.GetType("Harmony.HarmonyMethod").GetConstructor(new Type[] { typeof(MethodInfo) });
            this.create = harmonyInstance.GetMethod("Create");
            this.patch = harmonyInstance.GetMethod("Patch");

            this.harmony = this.create.Invoke(null, new Object[] { "net.darkhax.bookcase" });
            this.version = localHarmony.GetName().Version;
        }

        public object GetHarmonyMethod(Type type, string name) {

            MethodInfo method = type.GetMethod(name);
            return method != null ? this.harmonyMethod.Invoke(new Object[] { method }) : null;
        }

        public void PatchMethod(MethodBase target, object prefix, object postfix, object transpile) {

            Object[] ob = new Object[] { target, prefix, postfix, transpile };
            this.patch.Invoke(this.harmony, ob);
        }
    }
}
