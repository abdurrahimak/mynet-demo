using MynetDemo.Game.Ability;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MynetDemo.UI
{
    public class PlayStateUI : MonoBehaviour, IPlayStateUI
    {
        [SerializeField] private List<AbilityButton> _abilityButtons;
        [SerializeField] private Button _menuButton;

        public event Action GoMainMenu;
        public event Action<AbilityType> ClickedAbility;

        private void Start()
        {
            _menuButton.onClick.AddListener(MenuButton_OnClick);
            foreach (var abilityButton in _abilityButtons)
            {
                abilityButton.ClickedAbility += AbilityButton_ClickedAbility;
            }
        }

        private void AbilityButton_ClickedAbility(AbilityType abilityType)
        {
            ClickedAbility?.Invoke(abilityType);
        }

        private void MenuButton_OnClick()
        {
            GoMainMenu?.Invoke();
            AnimateUIs();
        }

        private void AnimateUIs()
        {
            _menuButton.interactable = false;
            DisableAllAbilityButtons();
            (_menuButton.transform as RectTransform).DOAnchorPos(new Vector2(1000f, 0f), 1f).Play();
            (_abilityButtons[0].transform.parent as RectTransform).DOAnchorPos(new Vector2(0, -1000f), 1f).Play();
        }

        public void DisableAllAbilityButtons()
        {
            foreach (var abilityButton in _abilityButtons)
            {
                abilityButton.Interactable = false;
            }
        }

        public void DisableAbilityButton(AbilityType abilityType)
        {
            foreach (var abilityButton in _abilityButtons)
            {
                if (abilityButton.AbilityType == abilityType)
                {
                    abilityButton.Interactable = false;
                    break;
                }
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
