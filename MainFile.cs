using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace Nono;

[ModInitializer(nameof(Initialize))]
public class MainFile
{
    public const string ModId = "Nono";

    public static Logger Logger { get; } =
        new(ModId, LogType.Generic);

    public static void Initialize()
    {
        Harmony harmony = new(ModId);

        harmony.PatchAll();
    }
}
