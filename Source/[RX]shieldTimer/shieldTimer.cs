// RimWorld\Data\Royalty\Defs\ThingDefs_Buildings\Buildings_Exotic.xml
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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
            Log.Message("[RX] Shield Timer Loaded.");
        }
    }

    [HarmonyPatch(typeof(CompProjectileInterceptor))]
    [HarmonyPatch(nameof(CompProjectileInterceptor.CompTick))]
    public static class CompProjectileInterceptor_CompTick_Patch
    {
        public static void Postfix(CompProjectileInterceptor __instance)
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
