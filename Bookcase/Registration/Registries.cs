using Bookcase.Mail;
using StardewModdingAPI;
using System.Collections.Generic;

namespace Bookcase.Registration {

    /// <summary>
    /// Class containing all registries added by Bookcase, along with related code for them.
    /// </summary>
    public class Registries {

        /// <summary>
        /// Registry for mail/letters. Letters added here will be handled by Bookcase.
        /// </summary>
        public static readonly Registry<Letter> Mail = new Registry<Letter>();

        /// <summary>
        /// Used to register any of the asset editors or other injectors. For internal use only.
        /// </summary>
        internal static void LoadInjectors() {

            BookcaseMod.modHelper.Content.AssetEditors.Add(new MailLoader());
        }

        /// <summary>
        /// Responsible for loading mail from the mail registry into the mail assets.
        /// </summary>
        class MailLoader : IAssetEditor {

            public bool CanEdit<T>(IAssetInfo asset) {

                return asset.AssetNameEquals("Data/mail");
            }

            public void Edit<T>(IAssetData asset) {

                IDictionary<string, string> mail = asset.AsDictionary<string, string>().Data;

                foreach (KeyValuePair<Identifier, Letter> entry in Mail.contents) {

                    mail.Add(entry.Key.FullString, entry.Value.Contents);
                }

                BookcaseMod.logger.Debug($"Loadded {Mail.contents.Count} new letters.");
            }
        }
    }
}