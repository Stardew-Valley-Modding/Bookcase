using StardewValley;
using Microsoft.Xna.Framework.Input;
using StardewValley.Events;
using System;
using xTile.Dimensions;
using StardewModdingAPI;
using System.Reflection;

namespace Bookcase.Events {

    class StardewModHooksWrapper : ModHooks {

        private readonly Mod owner;
        private readonly ModHooks previousHooks;

        public static StardewModHooksWrapper CreateWrapper(Mod mod) {

            try {

                FieldInfo hooksField = mod.Helper.Reflection.GetField<ModHooks>(typeof(Game1), "hooks").FieldInfo;
                StardewModHooksWrapper wrapper = new StardewModHooksWrapper(mod, (ModHooks) hooksField.GetValue(null));
                hooksField.SetValue(null, wrapper);
                mod.Monitor.Log("This mod has wrapped Game1.hooks!", LogLevel.Debug);
                return wrapper;
            }

            catch (Exception e) {

                mod.Monitor.Log($"Could not create StardewModHooksWrapper. Failed with {e.Message}", LogLevel.Error);
            }

            return null;
        }

        public StardewModHooksWrapper(Mod mod, ModHooks previous) {

            this.owner = mod;
            this.previousHooks = previous;
        }

        public override void OnGame1_PerformTenMinuteClockUpdate(Action action) {

            this.previousHooks.OnGame1_PerformTenMinuteClockUpdate(action);
        }

        public override void OnGame1_NewDayAfterFade(Action action) {

            this.previousHooks.OnGame1_NewDayAfterFade(action);
        }

        public override void OnGame1_ShowEndOfNightStuff(Action action) {

            this.previousHooks.OnGame1_ShowEndOfNightStuff(action);
        }

        public override void OnGame1_UpdateControlInput(ref KeyboardState keyboardState, ref MouseState mouseState, ref GamePadState gamePadState, Action action) {

            this.previousHooks.OnGame1_UpdateControlInput(ref keyboardState, ref mouseState, ref gamePadState, action);
        }

        public override void OnGameLocation_ResetForPlayerEntry(GameLocation location, Action action) {

            this.previousHooks.OnGameLocation_ResetForPlayerEntry(location, action);
        }

        public override bool OnGameLocation_CheckAction(GameLocation location, Location tileLocation, Rectangle viewport, Farmer who, Func<bool> action) {

            return this.previousHooks.OnGameLocation_CheckAction(location, tileLocation, viewport, who, action);
        }

        public override FarmEvent OnUtility_PickFarmEvent(Func<FarmEvent> action) {

            return this.previousHooks.OnUtility_PickFarmEvent(action);
        }
    }
}
