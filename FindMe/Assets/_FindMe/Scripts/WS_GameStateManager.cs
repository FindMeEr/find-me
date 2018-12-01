using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WS_GameStateManager {

    static int currentWorldGameIndex = 0;
    static int level = 0;
    static int totalScore =0;
    static Dictionary<int, WS_WorldGame> worldGameDict;

    public static int CurrentWorldGameIndex
    {
        get { return currentWorldGameIndex; }
        set { currentWorldGameIndex = value; }
    }
    public static int Level
    {
        get { return level; }
        set { level = value; }
    }
    public static int TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    public static WS_WorldGame GetCurrentWorldGame()
    {
        WS_WorldGame wg;
        worldGameDict.TryGetValue(currentWorldGameIndex,out wg);
        return wg;
    }

    public static void AddWorldGame(int key, WS_WorldGame wg)
    {
        worldGameDict.Add(key, wg);
    }

    public static bool IfContainsWorldGame(int key)
    {
        return worldGameDict.ContainsKey(key);
    }

    public static int GetTheWorldGameLestKeyIndex()
    {
        int index = 0;

        while (worldGameDict.ContainsKey(index))
        {
            index++;
        }

        index--;

        return index; // lest index can be -1 if the dictionary is empty
    }
}
