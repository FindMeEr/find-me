
using System.Collections.Generic;


namespace find_me
{
    public static class FM_GameState
    {
        static int currentWorldId = 0;
        static int level = 0;
        static int totalScore = 0;
        public static Dictionary<int, FM_WorldStatus> worldStatusDict;

        public static void Init()
        {

        }

        public static int CurrentWorldId
        {
            get { return currentWorldId; }
            set { currentWorldId = value; }
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

        public static FM_WorldStatus GetCurrentWorldGame()
        {
            FM_WorldStatus wg;
            worldStatusDict.TryGetValue(currentWorldId, out wg);
            return wg;
        }
        /*
        //have no additional logic than the original dictionary add
        public static void AddWorldGame(int key, FM_WorldStatus wg)
        {
            worldStatusDict.Add(key, wg);
        }
        
        
        public static bool IfContainsWorldGame(int key)
        {
            return worldStatusDict.ContainsKey(key);
        }
        */
        public static int GetTheWorldGameLastKeyIndex()
        {
            int index = 0;

            while (worldStatusDict.ContainsKey(index))
            {
                index++;
            }

            index--;

            return index; // lest index can be -1 if the dictionary is empty
        }
    }
}