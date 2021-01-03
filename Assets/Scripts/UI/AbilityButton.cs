using MynetDemo.Game.Ability;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MynetDemo.UI
{
    [RequireComponent(typeof(Button))]
    public class AbilityButton : MonoBehaviour
    {
        [SerializeField] private AbilityType _abilityType;
        private Button _button;

        public bool Interactable
        {
            get { return _button.interactable; }
            set { _button.interactable = value; }
        }

        public AbilityType AbilityType => _abilityType;

        public event Action<AbilityType> ClickedAbility;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick_AbilityButton);
        }

        private void OnClick_AbilityButton()
        {
            ClickedAbility?.Invoke(_abilityType);
        }
    }
}
