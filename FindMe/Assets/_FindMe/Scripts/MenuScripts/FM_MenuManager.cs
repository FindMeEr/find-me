using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace find_me
{

    public class FM_MenuManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //To Be Deleted:
            FM_WorldStatus w1 = new FM_WorldStatus(1, 0);
            FM_WorldStatus w2 = new FM_WorldStatus(2, 0);
            FM_WorldStatus w3 = new FM_WorldStatus(3, 0);

            FM_GameState.worldStatusDict = new Dictionary<int, FM_WorldStatus>();

            FM_GameState.worldStatusDict.Add(w1.Id, w1);
            FM_GameState.worldStatusDict.Add(w2.Id, w2);
            FM_GameState.worldStatusDict.Add(w3.Id, w3);

            createMenuWorlds();
        }

        void createMenuWorlds()
        {

            foreach (KeyValuePair<int, FM_WorldStatus> world in FM_GameState.worldStatusDict)
            {
                // do something with entry.Value or entry.Key
                GameObject worldObj = Instantiate(Resources.Load("menu_world")) as GameObject;
                worldObj.name = "world_" + world.Key;
                worldObj.transform.parent = GameObject.Find("worlds").transform;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}