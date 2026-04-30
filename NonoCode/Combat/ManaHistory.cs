using MegaCrit.Sts2.Core.Combat;
using System.Collections.Generic;
using System.Linq;

public class ManaHistory
{
    private readonly List<ManaModifiedEntry> _entries = new();

    public IEnumerable<ManaModifiedEntry> Entries => _entries;

    public void Add(ManaModifiedEntry entry)
    { 
        _entries.Add(entry);
    }
    public void Clear()
    {
        _entries.Clear();
    }

    //查询本回合增加量
    public int GainedThisTurn(CombatState combatState)
    {
        return _entries.Where(e => e.HappenedThisTurn(combatState) && e.Amount > 0).Sum(e => e.Amount);
    }
}