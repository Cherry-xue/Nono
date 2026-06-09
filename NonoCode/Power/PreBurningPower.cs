using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using Nono.NonoCode.Powers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nono.NonoCode.Power;

public sealed class PreBurningPower : NonoPower
{
    public override PowerType Type => PowerType.Buff;
    //定义能力类型：增益
    public override PowerStackType StackType => PowerStackType.Counter;
    //定义叠加类型：计数器
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<BurnPower>()];
    //显示BurnPower的相关信息
    public override async Task AfterDamageGiven(PlayerChoiceContext choiceContext, Creature? dealer, DamageResult result, ValueProp props, Creature target, CardModel? cardSource)
    {
        if (dealer != null && dealer == base.Owner && props.IsPoweredAttack() /*&& cardSource.Keywords.Contains(NonoKeywords.MagicCard)*/)
        {
            await PowerCmd.Apply<BurnPower>(target, base.Amount, base.Owner, null);
        }
    }
    //造成伤害时,施加等同PreBurningPower层数的BurnPower,随后移除全部PreBurningPower
    public override async Task AfterAttack(AttackCommand command)
    {
        await PowerCmd.Remove<PreBurningPower>(base.Owner);
    }
}