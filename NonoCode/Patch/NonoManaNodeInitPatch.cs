using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Assets;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Context;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Nodes.Combat;
using MoeNegiMod.Nono.Nodes;

[HarmonyPatch(typeof(NCombatUi), "_Ready")]
public static class NonoManaNodeInitPatch
{
    private static NManaCounter _manaCounter;

    private static RichTextLabel _manaLabel;
    public static void Postfix(NCombatUi __instance)
    {
        Log.Info(">>>[NonoMod]InitingManaNode");
        //防止重复添加
        var old = __instance.GetNodeOrNull<Control>("ManaCounter");
        if (old == null)
        {
            _manaCounter = PreloadManager.Cache.GetScene("res://Nono/Scenes/Combat/ManaCounter.tscn").Instantiate<NManaCounter>();
            __instance.EnergyCounterContainer.AddChild(_manaCounter, false);
            _manaLabel = _manaCounter.GetNode<RichTextLabel>("ManaValue");
        }
    }
    public static NManaCounter GetManaCounter() => _manaCounter;
    public static RichTextLabel GetManaLabel() => _manaLabel;
}
[HarmonyPatch(typeof(NCombatUi), "Activate")]
public static class NonoManaNodeVisiblePatch
{
    public static void Prefix(CombatState state)
    {
        Player player = LocalContext.GetMe(state);
        Log.Info(">>>[NonoMod]Character.Id is" + player.Character.Id.ToString());
        if (player.Character.Id.ToString() == "CHARACTER.MOENEGIMOD-NONO")
        {
            NonoManaNodeInitPatch.GetManaCounter().Visible = true;
        }
        else
        {
            NonoManaNodeInitPatch.GetManaCounter().Visible = false;
        }
    }
}


