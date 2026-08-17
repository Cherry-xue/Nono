using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Nono.NonoCode.Cards;

public class LightOfWisdom() : NonoCard
    (1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
//定义卡牌基本属性：0能量，技能，罕见稀有度，目标为自身
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new StarsVar(1),
        new CardsVar(2)
    ];
    //定义可变参数:获得辉星数值，初始值为1;抽取卡牌数值，初始值为2
    public override IEnumerable<CardKeyword> CanonicalKeywords => [NonoKeywords.MagicCard];
    //定义卡牌关键词：魔法牌
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PlayerCmd.GainStars(DynamicVars.Stars.BaseValue, Owner);
        await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.BaseValue, Owner);
    }
    //卡牌效果:获得等同于DynamicVars.Stars数值的辉星，并抽取等同于DynamicVars.Cards数值的卡牌
    protected override void OnUpgrade()
    {
        DynamicVars.Stars.UpgradeValueBy(1m);
    }
    //升级效果:获得的辉星数值增加1
}