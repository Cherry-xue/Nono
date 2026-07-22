using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using Nono.NonoCode.Powers;

namespace Nono.NonoCode.Cards;

public class MagicCircuit() : NonoCard
    (2, CardType.Power, CardRarity.Uncommon, TargetType.Self)
//定义卡牌基本属性：2能量，能力，罕见稀有度，目标为自己
{
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromKeyword(NonoKeywords.MagicCard)
    ];
    //定义魔法效果的提示
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<MagicCircuitPower>(choiceContext, Owner.Creature, 1, Owner.Creature, this);
    }
    //卡牌效果：施加1层MagicCircuitPower
    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
    //升级效果：能量消耗减少1
}
