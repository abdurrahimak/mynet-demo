using MynetDemo.Core;
using UnityEngine;
using DG.Tweening;
using MynetDemo.Game.Ability;
using MynetDemo.Creation;
using MynetDemo.UI;
using System;

namespace MynetDemo.Game
{
    public class PlayState : BaseGameState
    {
        private Character _character;
        private AbilityManager _abilityManager;
        private IPlayStateUI _playStateUI;

        private Vector3 characterStartPosition = new Vector3(0f, 0f, 15f);
        private Vector3 characterEndPosition = new Vector3(0f, 0f, -2f);
        public PlayState(IGameStateController parentGameStateController, IPlayStateUI playStateUI) : base(parentGameStateController)
        {
            _character = CharacterFactory.Instance.CreateCharacter();
            _abilityManager = new AbilityManager();
            _playStateUI = playStateUI;
        }

        public override void Begin()
        {
            base.Begin();
            _playStateUI.ClickedAbility += PlayStateUI_ClickedAbility;
            _playStateUI.GoMainMenu += PlayStateUI_GoMainMenu;

            _character.transform.position = characterStartPosition;
            _character.transform.DOMove(characterEndPosition, 2f).Play().onComplete += () =>
            {
                _character.EnableAttack(true);
            };
        }

        public override void End()
        {
            base.End();
            _playStateUI.ClickedAbility -= PlayStateUI_ClickedAbility;
            _playStateUI.GoMainMenu -= PlayStateUI_GoMainMenu;
            _playStateUI.Destroy();
            GameObject.Destroy(_character.gameObject);
        }

        private void PlayStateUI_ClickedAbility(AbilityType abilityType)
        {
            var ability = AbilityFactory.Instance.CreateAbility(abilityType, _character);
            _abilityManager.AddAbility(ability);
            if (_abilityManager.AbilityCount < 3)
            {
                _playStateUI.DisableAbilityButton(abilityType);
            }
            else
            {
                _playStateUI.DisableAllAbilityButtons();
            }
        }

        private void PlayStateUI_GoMainMenu()
        {
            SwitchToMainMenu();
        }

        public void SwitchToMainMenu()
        {
            _abilityManager.Destroy();
            _character.EnableAttack(false);

            Vector3 euler = _character.transform.rotation.eulerAngles;
            euler.y += 180f;
            _character.transform.DORotate(euler, 1f).Play().onComplete += () =>
            {
                _character.transform.DOMove(characterStartPosition, 2f).Play().onComplete += () =>
                {
                    IMenuStateUI menuStateUI = StateFactory.Instance.CreateMenuStateUI();
                    IGameState menuState = StateFactory.Instance.CreateMenuState(_parentGameStateController, menuStateUI);
                    _parentGameStateController.SwitchGameState(menuState);
                };
            };
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.D))
            {
                _abilityManager.AddAbility(AbilityFactory.Instance.CreateAbility(AbilityFactory.Instance.CreateDuplicateCharacterAbilityBehaviour(_character)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _abilityManager.AddAbility(AbilityFactory.Instance.CreateAbility(AbilityFactory.Instance.CreateMultipleAttackAbilityBehaviour(_character)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _abilityManager.AddAbility(AbilityFactory.Instance.CreateAbility(AbilityFactory.Instance.CreateDoubleAttackAbiltyBehaviour(_character)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _abilityManager.AddAbility(AbilityFactory.Instance.CreateAbility(AbilityFactory.Instance.CreateFrequencyModifyAbilityBehaviour(_character)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _abilityManager.AddAbility(AbilityFactory.Instance.CreateAbility(AbilityFactory.Instance.CreateProjectileSpeedModifyAbilityBehaviour(_character)));
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchToMainMenu();
            }
        }
    }
}
