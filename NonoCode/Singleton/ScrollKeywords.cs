using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Nono.NonoCode.Singleton;

public class ScrollKeywords : CustomSingletonModel
{
    public ScrollKeywords() : base(HookType.Combat)
    {
    }

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;

        if (card.Keywords.Contains(NonoKeywords.ScrollKeywords))
        {
            await CardPileCmd.RemoveFromCombat(card, skipVisuals: false);
        }
    }
}
