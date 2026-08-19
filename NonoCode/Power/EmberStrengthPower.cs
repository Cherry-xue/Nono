using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Nono.NonoCode.Powers;

public sealed class EmberStrengthPower : NonoPower
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
   [
       new DynamicVar("TriggerAmount", 10m)
   ];
    public override PowerType Type => PowerType.Buff;
    //定义能力类型：增益
    public override PowerStackType StackType => PowerStackType.Counter;
    //定义叠加类型：计数器
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<AfterGlowPower>()];
    //显示BurnPower的相关信息
    public override async Task AfterSideTurnStart(CombatSide side, IReadOnlyList<Creature> participants, ICombatState combatState)
    {
        if (participants.Contains(Owner))
        {
            int after_glow_amount = Owner.GetPowerAmount<AfterGlowPower>();
            int _amount = after_glow_amount / (int)DynamicVars["TriggerAmount"].BaseValue;
            if (_amount > 0)
            {
                await PowerCmd.Apply<AfterGlowPower>(new ThrowingPlayerChoiceContext(), Owner, -_amount * (int)DynamicVars["TriggerAmount"].BaseValue, Owner, null);
                await PowerCmd.Apply<StrengthPower>(new ThrowingPlayerChoiceContext(), Owner, _amount, Owner, null);
            }
        }
    }
    //在回合开始时,施加等同EmberStrength层数的PreBurningPower
}