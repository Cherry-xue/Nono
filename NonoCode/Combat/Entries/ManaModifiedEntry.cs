using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Combat;

public class ManaModifiedEntry
{
    public PlayerCombatState State { get; }
    public int Amount { get; }
    public int RoundNumber { get; }
    public CombatSide Side { get; }

    public ManaModifiedEntry(PlayerCombatState playerCombatState, int amount, int roundNumber, CombatSide side)
    { 
        State = playerCombatState;
        Amount = amount;
        RoundNumber = roundNumber;
        Side = side;
    }

    public bool HappenedThisTurn(CombatState combatState)
    {
        if (combatState == null) return false;
        return RoundNumber == combatState.RoundNumber && Side == combatState.CurrentSide;
    }
}