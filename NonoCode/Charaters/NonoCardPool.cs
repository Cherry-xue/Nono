using BaseLib.Abstracts;
using Godot;
using Nono.NonoCode.Extensions;

namespace Nono.NonoCode.Charaters;

public class NonoCardPool : CustomCardPoolModel
{
    public override string Title => Nono.CharacterId; //This is not a display name.

    public override string BigEnergyIconPath => "Charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "Charui/text_energy.png".ImagePath();
    public override Color DeckEntryCardColor => new("7FFFD4");
    public override Color EnergyOutlineColor => new("#7D7D7D");
    public override Color ShaderColor => new("#00FFEA");

    public override bool IsColorless => false;


}
