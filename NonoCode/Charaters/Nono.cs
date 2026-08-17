using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using Nono.NonoCode.Cards;
using Nono.NonoCode.Cards.Common;
using Nono.NonoCode.Extensions;
using Nono.NonoCode.Relics;

namespace Nono.NonoCode.Charaters;

  
public class Nono : PlaceholderCharacterModel
{
	public const string CharacterId = "Nono";
	public override string PlaceholderID => "necrobinder";

	public static readonly Color Color = new Color("7FFFD4");
	public override Color MapDrawingColor => Color;
	public override Color NameColor => Color;
	public override CharacterGender Gender => CharacterGender.Feminine;
	public override int StartingHp => 80;
	//初始生命值设定为80。
	public override bool ShouldAlwaysShowStarCounter => true;
	//始终显示星辉计数器。
	public override IEnumerable<CardModel> StartingDeck => [
		ModelDb.Card<NonoAttack>(),
        ModelDb.Card<NonoAttack>(),
        ModelDb.Card<NonoAttack>(),
        ModelDb.Card<NonoAttack>(),
		ModelDb.Card<NonoBlock>(),
        ModelDb.Card<NonoBlock>(),
        ModelDb.Card<NonoBlock>(),
        ModelDb.Card<NonoBlock>(),
        ModelDb.Card<FireBall>(),
        ModelDb.Card<PotionConflate>(),
        ModelDb.Card<PotionProduction>()
    ];
	//初始卡牌
    public override IReadOnlyList<RelicModel> StartingRelics => [ModelDb.Relic<NonoNoBag>()];
    //初始遗物
    public override CardPoolModel CardPool => ModelDb.CardPool<NonoCardPool>();
	public override RelicPoolModel RelicPool => ModelDb.RelicPool<NonoRelicPool>();
	public override PotionPoolModel PotionPool => ModelDb.PotionPool<NonoPotionPool>();

	/*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
		override all the other methods that define those assets.
		These are just some of the simplest assets, given some placeholders to differentiate your character with.
		You don't have to, but you're suggested to rename these images. */
	public override string CustomVisualPath => "res://Nono/Scenes/nono.tscn";
	public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
	public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
	public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
	public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
	public override string CustomCharacterSelectBg => "res://Nono/Scenes/nono_bg.tscn";
}
