using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Nono.NonoCode;

public class NonoKeywords
{
    // 自定义枚举的名字。最终会变成{前缀}-{枚举值大写}的形式
    [CustomEnum("MagicCard")]
    // 放在原版卡牌描述的位置，这里是卡牌描述的前面
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword MagicCard;

    [CustomEnum("PotionMaking")]
    [KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword PotionMaking;


}