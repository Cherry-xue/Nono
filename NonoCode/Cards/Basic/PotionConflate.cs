using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using Nono.NonoCode.PotionConflateSystem;

namespace Nono.NonoCode.Cards;

public class PotionConflate() : NonoCard
    (1, CardType.Skill, CardRarity.Basic, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("ConflateCount", 1m)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        for (int i = 0; i < ((CardModel)this).DynamicVars["ConflateCount"].IntValue; i++)
        {
            await PotionConflateService.TryCraft(recipe: PotionConflateService.FindFirstCraftableRecipe(((CardModel)this).Owner.PotionSlots), owner: ((CardModel)this).Owner, potionSlots: ((CardModel)this).Owner.PotionSlots);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars["ConflateCount"].UpgradeValueBy(1m);
    }
}