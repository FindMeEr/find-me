using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace find_me
{
    public class WS_WorldStatus : MonoBehaviour
    {

        int id;
        int score;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
