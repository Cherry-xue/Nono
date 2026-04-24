using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Nodes.Combat;
using MegaCrit.Sts2.Core.ValueProps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoeNegiMod.Nono.Cards;



public class PotionProduction() : NonoCard
    (1,CardType.Skill, CardRarity.Basic,TargetType.Self)
{
    public override List<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
    //卡牌关键词：消耗
    protected override IEnumerable<DynamicVar> CanonicalVars => [new HealVar(4)];
    //定义可变参数：回复数值，初始值为4

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.Heal(Owner.Creature,((DynamicVar)((CardModel)this).DynamicVars.Heal).BaseValue, true);
    }
    //卡牌效果：回复玩家生命，回复数值等同于DynamicVars.Heal的数值，且触发回复时的相关效果（如回复时触发的力量等）也会生效
    protected override void OnUpgrade()
    {
        DynamicVars.Heal.UpgradeValueBy(2m);
        ((CardModel)this).EnergyCost.UpgradeBy(-1);
    }
    //升级效果：回复数值增加2，能量消耗减少1
}
