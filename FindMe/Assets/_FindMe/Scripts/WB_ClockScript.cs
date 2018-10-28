using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FindMe
{
    public class WB_ClockScript : MonoBehaviour
    {

        [SerializeField] SpriteRenderer _outsideSprite;
        [SerializeField] SpriteRenderer _spriteInsideSprite;

        [SerializeField] TextMeshPro _percentText;
        [SerializeField] TextMeshPro _loadingText;
        [SerializeField] bool _playOnAwake;
        public bool _loadingEnd = false;

        int percent = 0;

        float endTime = 0.5f;
        float time = 0;
        int countPoint = 0;

        public int Value
        {
            set
            {
                percent = value;
                _percentText.text = percent + " %";
            }
            get
            {
                return percent;
            }
        }
        public bool LoadingEnd
        {
            get
            {
                return _loadingEnd;
            }
            set
            {
                _loadingEnd = value;
            }
        }

        private void Update()
        {
            if (!_loadingEnd)
            {
                time += Time.deltaTime;

                if (time >= endTime)
                {
                    time = 0;

                    switch (countPoint)
                    {
                        case 0:
                            _loadingText.text = "Loading";
                            countPoint++;
                            break;
                        case 1:
                            _loadingText.text = "Loading.";
                            countPoint++;
                            break;
                        case 2:
                            _loadingText.text = "Loading..";
                            countPoint++;
                            break;
                        case 3:
                            _loadingText.text = "Loading...";
                            countPoint = 0;
                            break;
                    }

                }

                _outsideSprite.transform.localRotation = _outsideSprite.transform.localRotation * Quaternion.Euler(0, 0, 1);
                _spriteInsideSprite.transform.localRotation = _spriteInsideSprite.transform.localRotation * Quaternion.Euler(0, 0, -1);
            }
            else
            {
                _loadingText.text = "";
            }
        }
    }
}
