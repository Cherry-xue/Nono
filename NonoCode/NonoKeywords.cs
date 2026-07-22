using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Nono.NonoCode;

public class NonoKeywords
{
    //魔法牌
    [CustomEnum("MagicCard")]
    // 放在原版卡牌描述的位置，这里是卡牌描述的前面
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword MagicCard;
    //药水制作
    [CustomEnum("PotionMaking")]
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword PotionMaking;
    //药水合成
    [CustomEnum("PotionConflation")]
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword PotionConflation;
    //火山
    [CustomEnum("VolcanoKeywords")]
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword VolcanoKeywords;

}