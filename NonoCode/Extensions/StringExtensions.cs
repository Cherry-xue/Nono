namespace Nono.NonoCode.Extensions;

public static class StringExtensions
{
	public static string ImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", path);
	}

	public static string CardImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Cards", path);
	}

	public static string BigCardImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Cards", path);
	}

	public static string PowerImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Powers", path);
	}
	public static string BigPowerImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Powers", path);
	}

	public static string RelicImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Relics", path);
	}

	public static string BigRelicImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Relics", path);
	}

	public static string CharacterUiPath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Charui", path);
	}
	public static string CharacterScenePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Scenes", path);
	}
	public static string PotionImagePath(this string path)
	{
		return Path.Join(MainFile.ModId, "Images", "Potions", path);
	}
}
