using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

namespace find_me
{
	public class WS_3DWorldManager : WS_WorldManager
    {
		private void Start()
		{
			WS_ObjectData3D[] objectData3DArray = GameObject.FindObjectsOfType<WS_ObjectData3D>();

			foreach (WS_ObjectData3D od in objectData3DArray)
			{
				AddObjectData(od);
			}

			SetNextObject ();
		}

		void Update()
		{
			RaycastHit[] hits;
			hits = Physics.RaycastAll(laserTransform.position, laserTransform.forward,100f);
			if (OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger)) {
				
				if (hits != null) {

					foreach (RaycastHit hit in hits) {
						if (hit.collider.gameObject.name.Contains("Solar")) {
							//hit.collider.enabled = false;
							//hit.collider.gameObject.SetActive (false);
							ObjectSelected (hit.collider.gameObject.GetComponent<WS_ObjectData> ());
						}
					}
				}
			}
   		 }
	}
}