using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Potions;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Nono.NonoCode.Potions;

namespace Nono.NonoCode.Cards;


public class RefiningStones() : NonoCard
    (1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)//定义卡牌基本属性：1能量，攻击，罕见稀有度，目标为任意敌人。
{
    public override List<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
    //卡牌关键词：消耗
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(3, ValueProp.Move)];
    //定义可变参数：伤害数值，初始值为3
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPotion<PotionShapedRock>(),
        HoverTipFactory.FromPotion<PotionShapedObsidian>()
    ];
    //定义提示：提示内容为PotionShapedRock的相关信息
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardAttack(this, cardPlay.Target).Execute(choiceContext);
        if (base.IsUpgraded)
        {
            await PotionCmd.TryToProcure<PotionShapedObsidian>(base.Owner);
        }
        else 
        {
            await PotionCmd.TryToProcure<PotionShapedRock>(base.Owner);
        }
    }
    //卡牌效果：对目标造成等同于DynamicVars.Damage数值的伤害，尝试获得一个PotionShapedRock
    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(2m);
    }
    //升级效果:能量消耗减少1
}
