using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Nono.NonoCode.Cards;

public class FireBall() : NonoCard
    (0,CardType.Attack, CardRarity.Basic,TargetType.AnyEnemy)
    //定义卡牌基本属性：0能量，攻击，基础稀有度，目标为任意敌人
{
    public override int CanonicalStarCost => 1;
    //定义辉星消耗为1
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(6, ValueProp.Move)];
    //定义可变参数：伤害数值，初始值为6
    public override IEnumerable<CardKeyword> CanonicalKeywords => [NonoKeywords.MagicCard];
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardAttack(this, cardPlay.Target).Execute(choiceContext);
    }
    //卡牌效果：对目标造成等同于DynamicVars.Damage数值的伤害
    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(2m);
    }
    //升级效果：伤害数值增加2
}
