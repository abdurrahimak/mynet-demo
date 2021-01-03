using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MynetDemo.UI
{
    public class MenuStateUI : MonoBehaviour, IMenuStateUI
    {
        [SerializeField] private Button _playButton;

        public event Action ClickedPlay;

        private void Start()
        {
            _playButton.onClick.AddListener(PlayButton_OnClick);
        }

        private void PlayButton_OnClick()
        {
            AnimateUIs();
        }

        private void AnimateUIs()
        {
            _playButton.interactable = false;
            (_playButton.transform as RectTransform).DOAnchorPos(new Vector2(1000f, 0f), 1f).Play().onComplete += () =>
            {
                ClickedPlay?.Invoke();
            };
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
