using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Nodes.Rooms;

namespace Nono.NonoCode.Potions;

public sealed class LesserSwiftPotion : NonoPotions
{
    public override PotionRarity Rarity => PotionRarity.Common;

    public override PotionUsage Usage => PotionUsage.CombatOnly;

    public override TargetType TargetType => TargetType.AnyPlayer;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1)];

    protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature target)
    {
        AssertValidForTargetedPotion(target);
        NCombatRoom.Instance.PlaySplashVfx(target, new Color("3d708e"));
        await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.BaseValue, target.Player);
    }
}
