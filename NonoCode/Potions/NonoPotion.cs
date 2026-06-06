using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Logging;
using Nono.NonoCode.Charaters;
using Nono.NonoCode.Extensions;

namespace Nono.NonoCode.Potions;
[Pool(typeof(NonoPotionPool))]

public abstract class NonoPotions : CustomPotionModel
{
    public override string CustomPackedImagePath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionImagePath();
            Log.Info(">>>[NonoMod]PotionPath=" + path, 2);
            return ResourceLoader.Exists(path) ? path : "potion.png".PotionImagePath();
        }
    }

    public override string CustomPackedOutlinePath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionImagePath();
            return ResourceLoader.Exists(path) ? path : "potion.png".PotionImagePath();
        }
    }
}