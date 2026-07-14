using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Nono.NonoCode.Cards;

public sealed class CondensingMana() : NonoCard
    (1, CardType.Skill, CardRarity.Common, TargetType.Self)
//定义卡牌基本属性：1能量，技能，普通稀有度，目标为自己
{
    public override bool GainsBlock => true;
    //卡牌属性：提供格挡
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(7m, ValueProp.Move),
        new StarsVar(1)
    ];
    //定义可变参数：格挡数值，初始值为7；星星数值，初始值为1
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, cardPlay);
        await PlayerCmd.GainStars(DynamicVars.Stars.BaseValue, Owner);
    }
    //卡牌效果：获得等同于DynamicVars.Block数值的格挡，获得等同于DynamicVars.Stars数值的星星
    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(3m);
    }
    //升级效果：格挡数值增加3
}