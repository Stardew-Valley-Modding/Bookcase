using StardewModdingAPI;
using Bookcase.Events;
using Bookcase.Patches;
using System;

namespace Bookcase {

    public class BookcaseMod : Mod {

        internal static IModHelper modHelper;
        internal static IReflectionHelper reflection;
        internal static Log logger;
        internal static Random random;

        public override void Entry(IModHelper helper) {

            modHelper = helper;
            reflection = helper.Reflection;
            logger = new Log(this);
            random = new Random();

            StardewModHooksWrapper.CreateWrapper(this);
            PatchManager patchManager = new PatchManager();
        }
    }
}