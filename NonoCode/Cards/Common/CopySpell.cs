using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;

namespace Nono.NonoCode.Cards;

public class CopySpell() : NonoCard
    (1, CardType.Skill, CardRarity.Common, TargetType.Self)
//定义卡牌基本属性：1能量，技能，普通稀有度，目标为自己
{
    public override int CanonicalStarCost => 1;
    //定义辉星消耗为1
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
    [
        CardKeyword.Exhaust
    ];
    //卡牌关键词：消耗
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromKeyword(NonoKeywords.ScrollKeywords),
    ];
    //定义卷轴关键词的悬停提示
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        CardModel selection = (await CardSelectCmd.FromHand(prefs: new CardSelectorPrefs(SelectionScreenPrompt, 1), context: choiceContext, player: Owner, filter: delegate (CardModel c)
        {
            return c != null && c.Keywords.Contains(NonoKeywords.MagicCard);
        }, source: this)).FirstOrDefault();
        if (selection != null)
        {
            //创建克隆卡牌
            CardModel card = selection.CreateClone();
            //设置为本次战斗免费
            card.SetToFreeThisCombat();
            //添加卡牌关键词：卷轴
            CardCmd.ApplyKeyword(card, NonoKeywords.ScrollKeywords);
            //添加卡牌关键词：消耗
            CardCmd.ApplyKeyword(card, CardKeyword.Exhaust);
            //将克隆卡牌添加到弃牌堆
            CardPileAddResult discardResult = await CardPileCmd.AddGeneratedCardToCombat(card, PileType.Discard, Owner);
            CardCmd.PreviewCardPileAdd(discardResult);
        }
    }
    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Retain);
    }
    //升级效果:添加保留关键词
}
