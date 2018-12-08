using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace find_me
{
    public class WS_ScoreScript : MonoBehaviour
    {

        [SerializeField] TextMeshPro _scoreText;
        [SerializeField] TextMeshPro _maxText;
        [SerializeField] Image _colorsImage;

        public int courentScore;
        int _maxScore = 1000;

        private void Start()
        {
            SetScore(courentScore);
            MaxScore = 1000;
        }

        public int MaxScore
        {
            get { return _maxScore; }
            set
            {
                _maxScore = value;
                _maxText.text = _maxScore.ToString();
            }
        }

        public void SetScore(int score)
        {
            courentScore = score;
            _colorsImage.fillAmount = 0;
            StartCoroutine(ShowAnimation());
        }

        private IEnumerator ShowAnimation()
        {
            int start = 0;
            _scoreText.text = "0";
            while (start < courentScore)
            {
                start += 5;

                if (start >= courentScore) start = courentScore;
                _scoreText.text = start.ToString();
                _colorsImage.fillAmount = ((float)start / (float)_maxScore);


                yield return new WaitForFixedUpdate();
            }
        }

    }
}
