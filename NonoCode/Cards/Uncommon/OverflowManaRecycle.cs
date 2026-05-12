using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Nono.NonoCode.Powers;

namespace Nono.NonoCode.Cards;

public class OverflowManaRecycle() : NonoCard
    (1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    //定义卡牌基本属性：1能量，能力，罕见稀有度，目标为自己
{
    private const string _blockOnManaKey = "BlockOnMana";
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("BlockOnMana", 4m)];
    //定义可变参数：使用魔法卡获得的格挡数值，初始值为4
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromKeyword(NonoKeywords.MagicCard),
        HoverTipFactory.Static(StaticHoverTip.Block)
    ];
    //定义魔法和格挡效果的提示
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<OverflowManaRecyclePower>(base.Owner.Creature, base.DynamicVars["BlockOnMana"].BaseValue, base.Owner.Creature, this);
    }
    //卡牌效果：施加等同于DynamicVars.Weak数值的弱化，施加等同于DynamicVars.Vulnerable数值的易伤
    protected override void OnUpgrade()
    {

        base.DynamicVars["BlockOnMana"].UpgradeValueBy(1m);
    }
    //升级效果：弱化和易伤数值均增加1
}
