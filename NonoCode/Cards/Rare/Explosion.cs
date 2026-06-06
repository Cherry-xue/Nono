using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
namespace Nono.NonoCode.Cards;



public class Explosion() : NonoCard
    (0,CardType.Attack, CardRarity.Rare,TargetType.AllEnemies)
    //定义卡牌基本属性：0能量，攻击，稀有稀有度，目标为所有敌人
{
    public override int CanonicalStarCost => 0;
    //定义星辉消耗为X
    protected override IEnumerable<DynamicVar> CanonicalVars => 
        [
        new DynamicVar("ExplosionDamage", 6m),
        new DynamicVar("PowerMultiple", 2m)
        ];
    //定义可变参数：伤害数值，初始值为6
    public override IEnumerable<CardKeyword> CanonicalKeywords => [NonoKeywords.MagicCard];
    //卡牌关键词：魔法牌
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<WeakPower>(),
        HoverTipFactory.FromPower<StrengthPower>()
    ];
    //定义提示：提示内容为弱化和力量的相关信息
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        int stars = Owner.PlayerCombatState.Stars;
        decimal explosiondamage = ((DynamicVar)((CardModel)this).DynamicVars["ExplosionDamage"]).BaseValue *(stars) + +(decimal)((CardModel)this).Owner.Creature.GetPowerAmount<StrengthPower>() * ((DynamicVar)((CardModel)this).DynamicVars["PowerMultiple"]).BaseValue;
        await DamageCmd.Attack(explosiondamage).FromCard(this).TargetingAllOpponents(base.CombatState).Execute(choiceContext);
        await PowerCmd.Apply<WeakPower>(base.Owner.Creature, 2, base.Owner.Creature, this);
        await PlayerCmd.SetStars(0, base.Owner);
    }
    //卡牌效果：对目标造成等同于DynamicVars.Damage数值的伤害
    protected override void OnUpgrade()
    {
        base.DynamicVars["ExplosionDamage"].UpgradeValueBy(3m);
        base.DynamicVars["PowerMultiple"].UpgradeValueBy(1m);
    }
    //升级效果：伤害数值增加3
}
