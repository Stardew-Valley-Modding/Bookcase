using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StardewValley;

namespace Bookcase.Utils
{
    public class NPCUtils
    {
        #region GetNPCUnderCursor
        private static Vector2 npcTileLoc;
        /// <summary>
        /// Gets all NPC Characters in the player's current location
        /// </summary>
        private static IList<NPC> LocationCharacters
        {
            get
            {
                return Game1.player.currentLocation.getCharacters();
            }
        }
        /// <summary>
        /// Checks if an NPC is on the same tile as the mouse, with the option of checking the tile above aswell. (Adults span 2 tiles)
        /// </summary>
        /// <param name="checkOneTileAbove"></param>
        /// <returns></returns>
        public static bool IsNPCOnMouseTile(bool checkOneTileAbove = false)
        {
            return (npcTileLoc == Game1.currentCursorTile || checkOneTileAbove && npcTileLoc == Game1.currentCursorTile - Vector2.UnitY);
        }
        /// <summary>
        /// Tries to get an NPC which is on the tile under the mouse cursor.
        /// Depending on the NPC's Age, the method will also look at one tile above the NPC's tile.
        /// </summary>
        /// <param name="npc">The NPC under the cursor, or null if none is found.</param>
        /// <returns>True if there is an NPC present, False if there is not.</returns>
        public static bool TryGetNPCUnderCursor(out NPC npc)
        {
            foreach(NPC n in LocationCharacters)
            {
                npcTileLoc = n.getTileLocation();
                if (IsNPCOnMouseTile(n.Age != NPC.child))
                {
                    npc = n;
                    return true;
                }
            }
            npc = null;
            return false;
        }
        /// <summary>
        /// Tries to get an NPC (filtered by some specified filter) on the tile under the mouse cursor.
        /// Depending on the NPC's Age, the method will also look at one tile above the NPC's tile.
        /// </summary>
        /// <param name="npc">The NPC present under the mouse cursor or null</param>
        /// <param name="filter">The filter to be applied when searching for a </param>
        /// <returns>True if there is a filtered NPC present, False if there is not, or the filter removes the NPC present</returns>
        public static bool TryGetNPCUnderCursor(out NPC npc, Func<NPC, bool> filter)
        {
            bool b = TryGetNPCsUnderCursor(out List<NPC> toFilter, filter);
            if (b)
                npc = toFilter.First();
            else
                npc = null;
            return b;
        }
        /// <summary>
        /// Tries to get a list of NPCs on the tile under the mouse cursor.
        /// Depending on the NPC's Age, the method will also look at one tile above the NPC's tile.
        /// </summary>
        /// <param name="npcs"></param>
        /// <returns></returns>
        public static bool TryGetNPCsUnderCursor(out List<NPC> npcs)
        {
            npcs = new List<NPC>();
            foreach (NPC n in LocationCharacters)
            {
                npcTileLoc = n.getTileLocation();
                if (IsNPCOnMouseTile(n.Age != NPC.child))
                {
                    npcs.Add(n);
                }
            }
            return npcs.Count > 0;
        }
        /// <summary>
        /// Tries to get a List of NPCs (filtered by some specified filter) on the tile under the mouse cursor.
        /// Depending on the NPC's Age, the method will also look at one tile above the NPC's tile.
        /// </summary>
        /// <param name="npc">The NPCs present under the mouse cursor or null</param>
        /// <param name="filter">The filter to be applied when searching for a </param>
        /// <returns>True if there is a filtered NPC present, False if there is not, or the filter removes the NPC present</returns>
        public static bool TryGetNPCsUnderCursor(out List<NPC> npc, Func<NPC, bool> filter)
        {
            npc = new List<NPC>();
            bool b = TryGetNPCsUnderCursor(out List<NPC> toFilter);
            if (!b)
                return false;//No NPCs Present
            npc = toFilter.Where(filter).ToList();
            return npc.Count > 0;
        }
        #endregion
    }
}
