using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.HoverTips;
using Nono.NonoCode.Powers;

namespace Nono.NonoCode.Power;

public sealed class FlammablePointPower : NonoPower
{
    public override PowerType Type => PowerType.Buff;
    //定义能力类型：增益
    public override PowerStackType StackType => PowerStackType.Counter;
    //定义叠加类型：计数器
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<PreBurningPower>(),
    ];
    //显示PreBurningPower的相关信息
    public override async Task AfterSideTurnStart(CombatSide side, CombatState combatState)
    {
        if (side != base.Owner.Side)
        {
            return;
        }
        await PowerCmd.Apply<PreBurningPower>(base.Owner, base.Amount, base.Owner, null);
    }
    //在回合开始时,施加等同FlammablePointPower层数的PreBurningPower
}
