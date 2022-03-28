using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingProgress
{
    private static int MainBuildingLevel,MarketLevel,PubLevel,CraftLevel,BarrackLevel;

    #region SetLevelsOnStart
    public static void SetMainBuildingLevel(int level)=> MainBuildingLevel = level;
    
    public static void SetMarketLevel(int level)=> MarketLevel = level;
    
    public static void SetPubLevel(int level)=> PubLevel = level;
   
    public static void SetBarrackLevel(int level) => BarrackLevel = level;
   
    public static void SetCraftLevel(int level)=> CraftLevel = level;
    #endregion
    #region GetBuidlingLevels
    public static int GetCurrentMainBuildingLevel() => MainBuildingLevel;
    public static int GetCurrentMarketLevel() => MarketLevel;
    public static int GetCurrentCraftLevel() => CraftLevel;
    public static int GetCurrentPubLevel() => PubLevel;
    public static int GetCurrentBarrackLevel() => BarrackLevel;
    #endregion

}
