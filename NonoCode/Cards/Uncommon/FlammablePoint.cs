using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Nono.NonoCode.Power;
using Nono.NonoCode.Powers;

namespace Nono.NonoCode.Cards;

public class FlammablePoint() : NonoCard
    (1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    //定义卡牌基本属性：1能量，能力，罕见稀有度，目标为自己
{
    private const string _flammablepointKey = "flammablepoint";
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("FlammablePoint", 2m)];
    //定义可变参数：FlammablePoint数值，初始值为2
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
[
    HoverTipFactory.FromPower<PreBurningPower>(),
    ];
    //显示PreBurningPower的相关信息
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<FlammablePointPower>(choiceContext, base.Owner.Creature, base.DynamicVars["FlammablePoint"].BaseValue, base.Owner.Creature, this);
    }
    //卡牌效果:获得一个FlammablePointPower，效果为:回合开始时,获得等同于FlammablePoint数值的PreBurningPower
    protected override void OnUpgrade()
    {

        base.DynamicVars["FlammablePoint"].UpgradeValueBy(1m);
    }
    //升级效果:回合开始时,获得等同于FlammablePoint数值的PreBurningPower数值增加1
}
