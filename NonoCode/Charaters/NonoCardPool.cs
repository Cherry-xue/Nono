using BaseLib.Abstracts;
using Godot;
using Nono.NonoCode.Extensions;

namespace MoeNegiMod.Nono.Character;

public class NonoCardPool : CustomCardPoolModel
{
    public override string Title => Nono.CharacterId; //This is not a display name.

    public override string BigEnergyIconPath => "Charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "Charui/text_energy.png".ImagePath();
    //Alternatively, leave these values at 1 and provide a custom frame image.
    /*public override Texture2D CustomFrame(CustomCardModel card)
	{
		//This will attempt to load Oddmelt/images/cards/frame.png
		return PreloadManager.Cache.GetTexture2D("cards/frame.png".ImagePath());
	}*/

    //Color of small card icons
    public override Color DeckEntryCardColor => new("7FFFD4");
    public override Color EnergyOutlineColor => new("#7D7D7D");
    public override Color ShaderColor => new("#00FFEA");

    public override bool IsColorless => false;


}
