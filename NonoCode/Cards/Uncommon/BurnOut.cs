using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Nono.NonoCode.Power;

namespace Nono.NonoCode.Cards;

public class BurnOut() : NonoCard
    (0, CardType.Attack, CardRarity.Uncommon, TargetType.AllEnemies)
    //定义卡牌基本属性：0能量，攻击，罕见稀有度，目标为所有敌人
{
    public override int CanonicalStarCost => 1;
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(5, ValueProp.Move)];
    //定义可变参数：伤害数值，初始值为5
    public override IEnumerable<CardKeyword> CanonicalKeywords => [NonoKeywords.MagicCard];
    //卡牌关键词：魔法牌
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<PreBurningPower>(),
    ];
    //定义提示：提示内容为弱化和力量的相关信息
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        int amount = this.Owner.Creature.GetPowerAmount<PreBurningPower>();
        await PowerCmd.Remove<PreBurningPower>(base.Owner.Creature);
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue).WithHitCount(amount).FromCard(this).TargetingAllOpponents(base.CombatState).Execute(choiceContext);
    }
    //卡牌效果:对所有敌人造成伤害，伤害数值等于DynamicVars.ExplosionDamage的数值乘以玩家当前的魔力,增加力量数值乘以DynamicVars.PowerMultiple的数值,之后施加2点弱化，并将玩家的魔力重置为0
    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(2m);
    }
    //升级效果：伤害数值增加5，力量加成增加2，能量消耗减少1
}