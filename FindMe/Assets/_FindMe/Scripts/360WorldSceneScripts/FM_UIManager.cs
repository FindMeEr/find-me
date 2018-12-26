using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace find_me{
public class FM_UIManager : MonoBehaviour
{
		[SerializeField] TextMeshProUGUI _scoreText;
		[SerializeField] TextMeshProUGUI _timeText;

		public event Action OnTimesUP;

		Camera centerCamera; 

		int sumOfPoint = 0;

		private void Start(){
			centerCamera = GameObject.Find ("CenterEyeAnchor").GetComponent<Camera>();
			_scoreText.text = "0";
			_timeText.text = "00:00";
		}
			
		public void ScoreUpdate(int points){

			sumOfPoint += points;
			_scoreText.text = sumOfPoint.ToString();
		}
			
		public void ShowTheNextObject(GameObject go,float duration){

			StartCoroutine(ShowNext(go,duration));
		}

		private IEnumerator ShowNext(GameObject go,float duration){

			GameObject clone = Instantiate (go, centerCamera.transform);
			clone.transform.localPosition = new Vector3 (0, 0, 3);
			yield return new WaitForSeconds (duration);
			DestroyImmediate (clone);
		}

		public void SetTimer(int seconds){
			StopTimer();
			StartCoroutine(TimerUpdate(seconds));
		}

		public void StopTimer(){
			StopAllCoroutines();
			_timeText.text = "00:00";
		}
			
		private IEnumerator TimerUpdate(int seconds){
			while (seconds >= 0) {

				if((seconds - (seconds / 60) < 10))
					{
					_timeText.text = (seconds / 60) + ":0" + (seconds - (seconds / 60));
					}else{
					_timeText.text = (seconds / 60) + ":" + (seconds - (seconds / 60));
					}
				yield return new WaitForSeconds(1);
				seconds--;
			}
			OnTimesUP.Invoke();
		}
}
}