using System.Resources;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Cards;
using MoeNegiMod.Nono.Cards;
[HarmonyPatch]
public static class UpdateStarCostVisualsPatch
{
    // 精确拦截目标方法
    [HarmonyPatch(typeof(NCard), "UpdateStarCostVisuals")]
    [HarmonyPriority(int.MaxValue)]
    public static class UpdateStarCostVisuals
    {
        // 在方法执行前修改参数或执行操作
        static void Prefix(NCard __instance)
        {
            if (__instance.Model is NonoCard mycard) { 
                Log.Info(">>>[NonoMod]--UpdateStarCostVisuals Successful");
                var starIcon = Traverse.Create(__instance).Field("_starIcon").GetValue<TextureRect>();
                Texture2D texture = ResourceLoader.Load<Texture2D>("res://Nono/Images/Packed/Sprite_Fonts/star_cost_icon.png");
                starIcon.Texture = texture;
            }
        }
    }
}