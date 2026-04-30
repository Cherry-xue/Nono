using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Logging;
using System.Runtime.CompilerServices;

static class PlayerCombatStateExtensions
{
    //挂载数据类
    private class ExtraManaData
    {
        public int ManaTotal;
        public ManaHistory History = new ManaHistory();
    }

    // ConditionalWeakTable 存储每个PlayerCombatState 的数据
    private static readonly ConditionalWeakTable<PlayerCombatState, ExtraManaData> _data = 
        new ConditionalWeakTable<PlayerCombatState, ExtraManaData>();
    
    private static ExtraManaData GetData(PlayerCombatState playerCombatState) =>
        _data.GetOrCreateValue(playerCombatState);

    //查询当前法力值
    public static int GetMana(this PlayerCombatState playerCombatState) => GetData(playerCombatState).ManaTotal;

    //增加法力值
    public static void GainMana(this PlayerCombatState playerCombatState, int amount, Player player)
    {
        if (amount < 0) throw new ArgumentException("Must not be negative", nameof(amount));

        var d = GetData(playerCombatState);
        d.ManaTotal += amount;

        d.History.Add(new ManaModifiedEntry(playerCombatState, amount, player.Creature.CombatState.RoundNumber, CombatSide.Player));

        NonoManaNodeInitPatch.GetManaLabel().Text = $"[center]{d.ManaTotal}[/center]";

        Log.Info(">>>[NonoMod]GainMana Successfull" + $"[Mana] + {amount} total={d.ManaTotal}");
        Log.Info(">>>[NonoMod]GetManaGainedThisTurn = " + GetManaGainThisTurn(playerCombatState, player));
    }
    public static void LoseMana(this PlayerCombatState playerCombatState, int amount, Player player)
    {
        if (amount < 0) throw new ArgumentException("Must not be negative", nameof(amount));

        var d = GetData(playerCombatState);
        d.ManaTotal = Math.Max(d.ManaTotal - amount, 0);

        d.History.Add(new ManaModifiedEntry(playerCombatState, amount, player.Creature.CombatState.RoundNumber, CombatSide.Player));

        NonoManaNodeInitPatch.GetManaLabel().Text = $"[center]{d.ManaTotal}[/center]";
        
        Log.Info(">>>[NonoMod]GainMana Successfull" + $"[Mana] - {amount} total={d.ManaTotal}");
    }
    public static int GetManaGainThisTurn(this PlayerCombatState playerCombatState, Player player)
    {
        return GetData(playerCombatState).History.GainedThisTurn(player.Creature.CombatState);
    }
}