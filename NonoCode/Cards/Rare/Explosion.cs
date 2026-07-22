using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
namespace Nono.NonoCode.Cards;



public class Explosion() : NonoCard
    (2,CardType.Attack, CardRarity.Rare,TargetType.AllEnemies)
    //定义卡牌基本属性：3能量，攻击，稀有稀有度，目标为所有敌人
{

    protected override IEnumerable<DynamicVar> CanonicalVars => 
        [
        new DynamicVar("ExplosionDamage", 7m),
        new DynamicVar("PowerMultiple", 2m)
        ];
    //定义可变参数：伤害数值，初始值为7；力量加成的倍率，初始值为2
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
        decimal explosiondamage = DynamicVars["ExplosionDamage"].BaseValue * stars + Owner.Creature.GetPowerAmount<StrengthPower>() * DynamicVars["PowerMultiple"].BaseValue;
        await DamageCmd.Attack(explosiondamage).FromCard(this).TargetingAllOpponents(CombatState).Execute(choiceContext);
        await PowerCmd.Apply<WeakPower>(choiceContext, Owner.Creature, 2, Owner.Creature, this);
        await PlayerCmd.SetStars(0, Owner);
    }
    //卡牌效果:对所有敌人造成伤害，伤害数值等于DynamicVars.ExplosionDamage的数值乘以玩家当前的魔力,增加力量数值乘以DynamicVars.PowerMultiple的数值,之后施加2点弱化，并将玩家的魔力重置为0
    protected override void OnUpgrade()
    {
        DynamicVars["ExplosionDamage"].UpgradeValueBy(3m);
        DynamicVars["PowerMultiple"].UpgradeValueBy(2m);
        EnergyCost.UpgradeBy(-1);
    }
    //升级效果：伤害数值增加5，力量加成增加2，能量消耗减少1
}
