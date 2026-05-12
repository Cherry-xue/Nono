using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Potions;

namespace Nono.NonoCode.PotionConflateSystem;

public static class PotionRecipeTable
{
	public static readonly List<PotionRecipe> Recipes = new List<PotionRecipe>
	{

		new PotionRecipe(new Dictionary<Type, int>
		{
			{
				typeof(BlockPotion),2
			},
		}, (PotionModel)(object)ModelDb.Potion<FlexPotion>()),
	};
}
