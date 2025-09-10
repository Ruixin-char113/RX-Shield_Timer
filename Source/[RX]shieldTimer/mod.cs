using UnityEngine;
using Verse;

namespace _RX_shieldTimer
{
    public class RXSTmod : Mod
    {
        public RXSTmodSettings settings = new RXSTmodSettings();

        public RXSTmod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<RXSTmodSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Enable this mod.", ref settings.modToggle);
            listingStandard.CheckboxLabeled("Display skipshield timer.", ref settings.displaySkipshieldTimer);
            listingStandard.CheckboxLabeled("Display burnout low-shield timer.", ref settings.displayBurnoutlowshieldTimer);
            listingStandard.CheckboxLabeled("[Experiment] Display timer for shields from other mods.", ref settings.displayOtherShieldTimer);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "[RX] Shield Timer";
        }
    }
}
