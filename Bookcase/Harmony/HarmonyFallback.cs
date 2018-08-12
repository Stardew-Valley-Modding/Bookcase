using System;
using System.Reflection;
using Harmony;

namespace Bookcase.Harmony {

    /// <summary>
    /// The fallback harmony instance that is provided by SMAPI.
    /// </summary>
    internal class HarmonyFallback : IHarmonyInstance {

        private readonly HarmonyInstance harmony;
        private readonly Version versionInfo;
        public string Version => versionInfo.ToString();

        public HarmonyFallback() {

            BookcaseMod.logger.Info("Loading the fallback Harmony instance.");
            this.harmony = HarmonyInstance.Create("net.darkhax.bookcase");
            this.harmony.VersionInfo(out versionInfo);
        }

        public object GetHarmonyMethod(Type type, string name) {

            MethodInfo method = type.GetMethod(name);
            return method != null ? new HarmonyMethod(method) : null;
        }

        public void PatchMethod(MethodBase target, object prefix, object postfix, object transpile) {

            this.harmony.Patch(target, (HarmonyMethod) prefix, (HarmonyMethod) postfix, (HarmonyMethod) transpile);
        }
    }
}