using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Potions;
using Nono.NonoCode.Potions;

namespace Nono.NonoCode.PotionConflateSystem;

public static class PotionRecipeTable
{
	public static readonly List<PotionRecipe> Recipes = new List<PotionRecipe>
	{
		//2魔力药水->强效魔力药水
		new(new Dictionary<Type, int>{{typeof(ManaPotion),2},}, ModelDb.Potion<GreaterManaPotion>()),
		
		//2弱效魔力药水->魔力药水
		new(new Dictionary<Type, int>{{typeof(LesserManaPotion),2},}, ModelDb.Potion<ManaPotion>()),






    };
}
