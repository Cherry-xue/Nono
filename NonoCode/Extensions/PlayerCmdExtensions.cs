using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using System.Threading.Tasks;

static class PlayerCmdExtensions
{
    public static async Task GainMana(decimal amount, Player player)
    {
        if (!CombatManager.Instance.IsEnding)
        {
            player.PlayerCombatState.GainMana((int)amount, player);
        }
    }

    public static Task LoseMana(decimal amount, Player player)
    {
        if (CombatManager.Instance.IsEnding)
        {
            return Task.CompletedTask;
        }
        player.PlayerCombatState.LoseMana((int)amount, player);
        return Task.CompletedTask;
    }
}

