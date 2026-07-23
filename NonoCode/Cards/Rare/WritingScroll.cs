using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;

namespace Nono.NonoCode.Cards;

public class WritingScroll() : NonoCard
    (2, CardType.Skill, CardRarity.Rare, TargetType.Self)
//定义卡牌基本属性：2能量，技能，罕见稀有度，目标为自己
{
    public override int CanonicalStarCost => 2;
    //定义辉星消耗为2
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
            return c!= null && c.Keywords.Contains(NonoKeywords.MagicCard);
        }, source: this)).FirstOrDefault();
        if (selection != null)
        {
            //创建两个克隆卡牌
            CardModel card_1 = selection.CreateClone();
            CardModel card_2 = selection.CreateClone();
            //设置为本次战斗免费
            card_1.SetToFreeThisCombat();
            card_2.SetToFreeThisCombat();
            //添加卡牌关键词：卷轴
            CardCmd.ApplyKeyword(card_1, NonoKeywords.ScrollKeywords);
            CardCmd.ApplyKeyword(card_2, NonoKeywords.ScrollKeywords);
            //添加卡牌关键词：消耗
            CardCmd.ApplyKeyword(card_1, CardKeyword.Exhaust);
            CardCmd.ApplyKeyword(card_2, CardKeyword.Exhaust);
            //将克隆卡牌添加到抽牌堆和弃牌堆
            CardPileAddResult drawResult = await CardPileCmd.AddGeneratedCardToCombat(card_1, PileType.Draw, Owner, CardPilePosition.Random);
            CardPileAddResult discardResult = await CardPileCmd.AddGeneratedCardToCombat(card_2, PileType.Discard, Owner);
            CardCmd.PreviewCardPileAdd([drawResult, discardResult]);
            if (IsUpgraded)
            {
                CardModel card_3 = selection.CreateClone();
                card_3.SetToFreeThisCombat();
                CardCmd.ApplyKeyword(card_3, NonoKeywords.ScrollKeywords);
                CardCmd.ApplyKeyword(card_3, CardKeyword.Exhaust);
                await CardPileCmd.AddGeneratedCardToCombat(card_3, PileType.Hand, Owner);
            }
            //如果卡牌升级，则再创建一个克隆卡牌并添加到手牌
        }
    }
    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
    //升级效果：能量消耗减少1
}