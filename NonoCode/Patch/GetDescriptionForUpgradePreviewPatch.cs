using System;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MoeNegiMod.Nono.Cards;
[HarmonyPatch]
public static class GetDescriptionForUpgradePreviewPatch
{
    // 精确拦截目标方法
    [HarmonyPatch(typeof(CardModel), "GetDescriptionForUpgradePreview")]
    [HarmonyPriority(int.MaxValue)]
    public static class GetDescriptionForUpgradePreview
    {
        // 在方法执行后修改返回值
        static void Postfix(CardModel __instance , ref string __result)
        {   if (__instance is NonoCard mycard)
            {
                Log.Info(">>>[NonoMod]--CardUpgradePathPatch:" + __result);
                // 执行精确路径替换
                __result = ModifyReturnPath(__result);
                Log.Info(">>>[NonoMod]--CardUpgradePathfix:" + __result);
            }
        }
        // 路径替换核心方法
        private static string ModifyReturnPath(string input)
        {
            // 使用正则表达式确保精确匹配（避免误替换）
            return System.Text.RegularExpressions.Regex.Replace(
                input,
                @"\[img\]res://images/packed/sprite_fonts/star_icon\.png\[/img\]",
                "[img]res://Nono/Images/Packed/Sprite_Fonts/mana_icon.png[/img]",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );
        }
    }
}