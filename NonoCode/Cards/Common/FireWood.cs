using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Nono.NonoCode.Power;

namespace Nono.NonoCode.Cards;

public class FireWood() : NonoCard
    (1, CardType.Skill, CardRarity.Common, TargetType.Self)
    //定义卡牌基本属性：1能量，技能，普通稀有度，目标为自己
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("FireWood", 4m)];
    //定义可变参数：FireWood数值，初始值为4
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<PreBurningPower>()
    ];
    //定义提示：提示PreBurningPower的相关信息
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<PreBurningPower>(base.Owner.Creature, base.DynamicVars["FireWood"].BaseValue, base.Owner.Creature, this);
    }
    //卡牌效果:获得PreBurningPower效果,层数等同于DynamicVars["FireWood"]数值.
    protected override void OnUpgrade()
    {

        base.DynamicVars["FireWood"].UpgradeValueBy(2m);
    }
    //升级效果:FireWood数值增加2
}
