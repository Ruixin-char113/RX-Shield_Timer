// RimWorld\Data\Royalty\Defs\ThingDefs_Buildings\Buildings_Exotic.xml
using RimWorld;
using HarmonyLib;
using Verse;

// RimWorld.CompProjectileInterceptor
namespace _RX_shieldTimer
{
    [StaticConstructorOnStartup]
    public static class RXshieldTimer
    {
        static RXshieldTimer()
        {
            var harmony = new Harmony("ruixinchar113.shieldTimer");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(CompProjectileInterceptor))]
    [HarmonyPatch(nameof(CompProjectileInterceptor.CompTick))]
    public static class CompProjectileInterceptor_CompTick_Patch
    {
        public static void Postfix(CompProjectileInterceptor __instance)
        {
            // Turn on this mod
            if (LoadedModManager.GetMod<RXSTmod>().GetSettings<RXSTmodSettings>().modToggle)
            {
                // Skipshield
                if(__instance.parent.def.defName == "BulletShieldPsychic")
                {
                    if (LoadedModManager.GetMod<RXSTmod>().GetSettings<RXSTmodSettings>().displaySkipshieldTimer)
                    {
                        SpawnShieldTimer(__instance);
                    }
                }
                // Burnout low-shieldTimer
                else if (__instance.parent.def.defName == "BroadshieldProjector")
                {
                    if (LoadedModManager.GetMod<RXSTmod>().GetSettings<RXSTmodSettings>().displayBurnoutlowshieldTimer)
                    {
                        SpawnShieldTimer(__instance);
                    }
                }
                // Other shield
                else if (LoadedModManager.GetMod<RXSTmod>().GetSettings<RXSTmodSettings>().displayOtherShieldTimer)
                {
                    SpawnShieldTimer(__instance);
                }
            }
        }

        public static void SpawnShieldTimer(CompProjectileInterceptor __instance)
        {
            CompDestroyAfterDelay compDelay = __instance.parent.TryGetComp<CompDestroyAfterDelay>();
            int leftTick = compDelay?.TicksLeft ?? 0;
            if (leftTick > 0)
            {
                MoteMaker.ThrowText(__instance.parent.DrawPos, __instance.parent.Map, leftTick.ToStringSecondsFromTicks("F1"), 1 / 60f);
            }
        }
    }
}
