using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace find_me
{
	public class WS_WorldManager : MonoBehaviour
    {
		[SerializeField] Material _skybox;

        Dictionary<int, WS_ObjectData> objectsDataDictionary = new Dictionary<int, WS_ObjectData>();

		WS_UIManager uiManager;

        bool _controllerClick = false;

        int numOfPoints = 0;

		int currentObjectId = -1;

        bool look = false;

		protected Transform laserTransform;

		private void SubscribeToEvents(){
			uiManager.OnTimesUP += Timesup;
		}

		private void UnSubscribeToEvents(){
			uiManager.OnTimesUP -= Timesup;
		}

		private void OnEnable()
		{
			RenderSettings.skybox = _skybox;
			uiManager = GameObject.FindObjectOfType<WS_UIManager>();

			GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");

			for (int i = 0; i < lasers.Length; i++)
			{
				if (lasers[i].activeSelf)
				{
					laserTransform = lasers[i].transform;
				}
			}
			SubscribeToEvents ();
		}

		private void OnDisable(){
			UnSubscribeToEvents ();
		}
			
        public Dictionary<int, WS_ObjectData> ObjectsDataDictionary
        {
            get { return objectsDataDictionary; }
        }

        public bool ControllerClick
        {
            set { _controllerClick = value; }
            get { return _controllerClick; }
        }

        public void AddObjectData(WS_ObjectData od)
        {
			numOfPoints += od.Points;
            objectsDataDictionary.Add(od.ID, od);
        }

        public WS_ObjectData GetObjectDataById(int id)
        {
            WS_ObjectData od = null;
            if (objectsDataDictionary.TryGetValue(id, out od))
            {
                return od;
            }
            return null;
        }
			
        protected void ObjectSelected(WS_ObjectData od)
        {
            if (look) return; // this is because the function call from an Update function
            look = true;

			if(currentObjectId == od.ID && GetObjectDataById(od.ID)!= null)
            {
				currentObjectId = -1;
                objectsDataDictionary.Remove(od.ID);
                numOfPoints += od.Points;
				uiManager.StopTimer();
				uiManager.ScoreUpdate (od.Points);

            }
            look = false;
        }
			
		protected void SetNextObject(){
			WS_ObjectData od = null;

			if (objectsDataDictionary.Count == 0) {
				//TODO
				return;
			}

			foreach (int key in objectsDataDictionary.Keys) {
				currentObjectId = key;
			}

			if (objectsDataDictionary.TryGetValue (currentObjectId, out od)) {
				uiManager.SetTimer (od.Seconds);
				uiManager.ShowTheNextObject (od.ObjectIDentifeir, 5);
			}
		}

		private void Timesup(){
			if (currentObjectId == -1)
				return;

			objectsDataDictionary.Remove(currentObjectId);
			SetNextObject ();
		}
    }
}