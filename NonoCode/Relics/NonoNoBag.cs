using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Nono.NonoCode.Relics;

public class NonoNoBag : NonoRelics
{
    public override RelicRarity Rarity => RelicRarity.Starter;
    //设置该遗物为Starter类型，使其在角色选择界面默认装备。
    private const string _potionSlotsKey = "PotionSlots";
    //定义一个常量字符串，作为DynamicVar的键，用于表示玩家的药水槽数量。
    public override bool HasUponPickupEffect => true;
    //表示该遗物在获得时会触发特定效果。
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DynamicVar("PotionSlots", 3m),//定义一个DynamicVar，表示玩家的药水槽数量，初始值为3。
        new StarsVar(1),//定义一个StarsVar，表示玩家的星星数量，初始值为1。
    ];
    public override async Task AfterObtained()
    {
        await PlayerCmd.GainMaxPotionCount(base.DynamicVars["PotionSlots"].IntValue, base.Owner);
    }
    //当玩家获得该遗物时，调用PlayerCmd.GainMaxPotionCount命令，增加玩家的最大药水槽数量，数量等同于DynamicVars["PotionSlots"]的整数值。
    public override async Task AfterEnergyResetLate(Player player)
    {
        if (player == base.Owner)
        {
            await PlayerCmd.GainStars(base.DynamicVars.Stars.BaseValue, base.Owner);
        }
    }
    //在每回合开始时，如果玩家是该遗物的拥有者，调用PlayerCmd.GainStars命令，增加玩家的星星数量，数量等同于DynamicVars.Stars的基础值。
}
