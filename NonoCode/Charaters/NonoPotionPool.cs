using BaseLib.Abstracts;
using Godot;
using Nono.NonoCode.Extensions;

namespace Nono.NonoCode.Charaters;

public class NonoPotionPool : CustomPotionPoolModel
{
    public override string EnergyColorName => Nono.CharacterId;
    public override Color LabOutlineColor => Nono.Color;

    public override string BigEnergyIconPath => "Charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "Charui/text_energy.png".ImagePath();
}
