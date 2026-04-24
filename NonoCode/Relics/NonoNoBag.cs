using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Saves.Runs;
using MoeNegiMod.Nono.Character;
using Nono.NonoCode.Extensions;

namespace MoeNegiMod.Nono.Relics;
public class NonoNoBag : NonoRelics
{
    public override RelicRarity Rarity => RelicRarity.Starter;
    //设置该遗物为Starter类型，使其在角色选择界面默认装备。
    private const string _potionSlotsKey = "PotionSlots";
    //定义一个常量字符串，作为DynamicVar的键，用于表示玩家的药水槽数量。
    public override bool HasUponPickupEffect => true;
    //表示该遗物在获得时会触发特定效果。
    protected override IEnumerable<DynamicVar> CanonicalVars => new global::_003C_003Ez__ReadOnlySingleElementList<DynamicVar>(new DynamicVar("PotionSlots", 3m));
    //定义一个DynamicVar，表示玩家的药水槽数量，初始值为3。
    public override async Task AfterObtained()
    {
        await PlayerCmd.GainMaxPotionCount(base.DynamicVars["PotionSlots"].IntValue, base.Owner);
    }
    //当玩家获得该遗物时，调用PlayerCmd.GainMaxPotionCount命令，增加玩家的最大药水槽数量，数量等同于DynamicVars["PotionSlots"]的整数值。
}
