using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Nono.NonoCode.Cards;

public class StrengthenDefenses() : NonoCard
    (1, CardType.Skill, CardRarity.Token, TargetType.Self)
//定义卡牌基本属性：1能量，能力，Token稀有度，目标为自己
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(12, ValueProp.Move)];
    //定义可变参数：Block-格挡值，初始值为12
    public override bool GainsBlock => true;
    //定义卡牌是否获得格挡：是

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardBlock(this, cardPlay);
    }
    //卡牌效果:获得等同于DynamicVars.Block数值的格挡
    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(4m);
    }
    //升级效果:获得的格挡数值增加4
}
