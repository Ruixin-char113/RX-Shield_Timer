using Verse;

namespace _RX_shieldTimer
{
    public class RXSTmodSettings : ModSettings
    {
        public bool modToggle = true;
        public bool displaySkipshieldTimer = true;
        public bool displayBurnoutlowshieldTimer = true;
        public bool displayOtherShieldTimer = true;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref modToggle, "modSwitch", true, true);
            Scribe_Values.Look(ref displaySkipshieldTimer, "displaySkipshieldTimer", true, true);
            Scribe_Values.Look(ref displayBurnoutlowshieldTimer, "displayBurnoutlowshieldTimer", true, true);
            Scribe_Values.Look(ref displayOtherShieldTimer, "displayOtherShieldTimer", true, true);
        }
    }
}
