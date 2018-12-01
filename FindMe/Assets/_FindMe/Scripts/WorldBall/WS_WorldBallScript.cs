using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindMe
{
    public class WS_WorldBallScript : MonoBehaviour
    {

        [SerializeField] WS_ClockScript _clockScript;
        [SerializeField] WS_ScoreScript _scoreScript;

        string _worldId;
        int _worldPoints;
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string WorldId
        {
            get { return _worldId; }
            set { _worldId = value; }
        }

        public int WorldPoints
        {
            get { return _worldPoints; }
            set { _worldPoints = value; }
        }

        public void WorldInit(string worldId, int worldPoints, int index)
        {
            _worldId = worldId;
            _worldPoints = worldPoints;
            _index = index;
        }

    }
}