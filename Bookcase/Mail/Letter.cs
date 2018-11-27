using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using StardewValley;
using StardewValley.Menus;
using Bookcase.Registration;

namespace Bookcase.Mail {

    public class Letter : Identifiable {

        /// <summary>
        /// The contents of the mail. This is the text that the player will read. This uses the vanilla mail format, meaning 
        /// any special character formatting will apply here as well.
        /// </summary>
        public String Contents { get; private set; }

        /// <summary>
        /// A list of gift items to give to the reader. If this is null/empty it will be ignored.
        /// </summary>
        public List<Item> Gifts { get; private set; }

        /// <summary>
        /// Allows code to be executed before the message has been created. The resulting string is what will be used in place
        /// of the value defined for constants. This allows for you to define custom replacement and formatting tokens in your
        /// mail text.
        /// </summary>
        public Func<Letter, String> PreProcessor;

        /// <summary>
        /// A callback hook for after the letter has been closed. This allows mail to do additional things like track data or
        /// modify the player.
        /// </summary>
        public Action<Letter, LetterViewerMenu> Callback;

        /// <summary>
        /// The color of the text to be displayed in the mail. This is a color id, and not a packed integer. 
        /// </summary>
        public int TextColor;

        /// <summary>
        /// The texture to use for the backround of the mail. If this is null the original background will be used. 
        /// </summary>
        public Texture2D Background;

        public Letter(String id, String contents) : this(new Identifier(id), contents) {

            // String based constructor for lazy people (IE: me).
        }

        public Letter(Identifier id, String contents) {

            this.Identifier = id;
            this.Contents = contents;
            this.Gifts = new List<Item>();
            this.TextColor = -1;
        }

        /// <summary>
        /// A helper method for sending the letter to players. This is not required, but can be useful.
        /// </summary>
        /// <param name="noLetter"></param>
        /// <param name="sendToEveryone"></param>
        public void addMailForTomorrow(bool noLetter = false, bool sendToEveryone = false) {

            Game1.addMailForTomorrow(this.Identifier.FullString, noLetter, sendToEveryone);
        }

        /// <summary>
        /// Attempts to immediately deliver this letter to a player.
        /// </summary>
        /// <param name="farmer">The player to deliver the mail to.</param>
        public void addMailImmediately(Farmer farmer) {

            if (!farmer.hasOrWillReceiveMail(this.Identifier.FullString)) {

                farmer.mailbox.Add(this.Identifier.FullString);
            }
        }
    }
}