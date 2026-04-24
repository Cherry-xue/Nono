using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Models.Relics;
using Nono.NonoCode.Extensions;
using MoeNegiMod.Nono.Character;
namespace MoeNegiMod.Nono.Character;

public class NonoRelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => Nono.CharacterId;
    public override Color LabOutlineColor => Nono.Color;

    public override string BigEnergyIconPath => "Charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "Charui/text_energy.png".ImagePath();
}
