using BepInEx;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[BepInDependency("com.willis.rounds.unbound")]
[BepInDependency("pykess.rounds.plugins.moddingutils")]
[BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch")]
[BepInPlugin(MOD_ID, MOD_NAME, VERSION)]
[BepInProcess("Rounds.exe")]
public class PekingJamCardPack : BaseUnityPlugin
{
    public const string MOD_ID = "com.quackandcheese.rounds.pekingjamcardpack";
    public const string MOD_NAME = "PekingJamCardPack";
    public const string VERSION = "0.1.0";

    internal static AssetBundle assets;

    internal static string modInitials = "Peking Jam";

    void Awake()
    {
        var harmony = new Harmony(MOD_ID);
        harmony.PatchAll();
        assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("assets", typeof(PekingJamCardPack).Assembly);

        //assets.LoadAsset<GameObject>("ModCards").GetComponent<CardHolder>().RegisterCards();
    }
}