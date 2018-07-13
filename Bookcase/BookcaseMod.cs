using StardewModdingAPI;
using Bookcase.Events;

namespace Bookcase {

    public class BookcaseMod : Mod {

        internal static IModHelper modHelper;
        internal static IReflectionHelper reflection;
        internal static Log logger;

        public override void Entry(IModHelper helper) {

            modHelper = helper;
            reflection = helper.Reflection;
            logger = new Log(this);
            StardewModHooksWrapper.CreateWrapper(this);
        }
    }
}