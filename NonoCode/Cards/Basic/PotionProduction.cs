using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using Nono.NonoCode.Potions;
namespace Nono.NonoCode.Cards;



public class PotionProduction() : NonoCard
    (1,CardType.Skill, CardRarity.Basic,TargetType.Self)
{
    public override List<CardKeyword> CanonicalKeywords => [
        CardKeyword.Exhaust,
        NonoKeywords.PotionMaking
    ];
    //卡牌关键词:消耗,药水制作
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("PotionCount", 1m)];
    //定义可变参数：制作的药水数量，初始值为1
    private readonly List<PotionModel> PotionPool =
    [
        ModelDb.Potion<LesserManaPotion>(),
        ModelDb.Potion<LesserSwiftPotion>(),
        ModelDb.Potion<LesserHealingPotion>(),
        ModelDb.Potion<SwiftnessPotion>(),
        ModelDb.Potion<IronskinPotion>(),
        ModelDb.Potion<LesserExplosiveAmpoule>(),
        ModelDb.Potion<LesserFirePotion>()
    ];
    //定义药水池
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        for (int i = 0; i < DynamicVars["PotionCount"].IntValue; i++)
        {
            PotionModel potionModel = PotionPool[Owner.RunState.Rng.CombatPotionGeneration.NextInt(PotionPool.Count)];
            await PotionCmd.TryToProcure(potionModel.ToMutable(), Owner, -1);
        }
    }
    //卡牌效果：随机制作PotionCount个药水
    protected override void OnUpgrade()
    {
        DynamicVars["PotionCount"].UpgradeValueBy(1m);
        EnergyCost.UpgradeBy(-1);
    }
    //升级效果:制作的药水数量增加1
}
