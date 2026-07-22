using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;

namespace Nono.NonoCode.Powers;

public sealed class MagicCircuitPower : NonoPower
{
    private class Data
    {
        public int magiccardPlayed;

        public int triggerCount;
    }

    private const int _magiccardIncrement = 3;

    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override int DisplayAmount => 3 - GetInternalData<Data>().magiccardPlayed % 3;

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromKeyword(NonoKeywords.MagicCard),
    ];

    protected override object InitInternalData()
    {
        return new Data();
    }

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner != Owner.Player || !cardPlay.Card.Keywords.Contains(NonoKeywords.MagicCard))
        {
            return;
        }
        Data data = GetInternalData<Data>();
        data.magiccardPlayed++;
        int triggers = data.magiccardPlayed / 3 - data.triggerCount;
        if (triggers > 0)
        {
            Flash();
            await PlayerCmd.GainStars(Amount * triggers, Owner.Player);
            data.triggerCount += triggers;
        }
        InvokeDisplayAmountChanged();
    }
}
