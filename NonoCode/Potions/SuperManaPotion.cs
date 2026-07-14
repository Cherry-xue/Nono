using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Nono.NonoCode.Potions;

public class SuperManaPotion : NonoPotions
{
    public override PotionRarity Rarity => PotionRarity.Token;

    public override PotionUsage Usage => PotionUsage.CombatOnly;

    public override TargetType TargetType => TargetType.Self;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new StarsVar(12)];

    protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
        await PlayerCmd.GainStars(DynamicVars.Stars.BaseValue, Owner);
    }
}
