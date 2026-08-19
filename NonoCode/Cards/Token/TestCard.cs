using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Cards;
using MegaCrit.Sts2.Core.ValueProps;
using Nono.NonoCode.Powers;

namespace Nono.NonoCode.Cards;

public class TestCard() : NonoCard
    (1, CardType.Skill, CardRarity.Token, TargetType.Self)
//定义卡牌基本属性：1能量，攻击，普通稀有度，目标为任意敌人
{
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromKeyword(NonoKeywords.Choice)
    ];
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        CardModel cardModel;
        List<CardModel> cards =
        [
             CombatState.CreateCard<TestCards>(Owner),
             CombatState.CreateCard<TestCard>(Owner)
        ];
        cardModel = await CardSelectCmd.FromChooseACardScreen(choiceContext, cards, Owner, canSkip: true);
        cardModel.SetToFreeThisTurn();
        await CardPileCmd.AddGeneratedCardToCombat(cardModel, PileType.Hand, Owner);

    }
    
}
