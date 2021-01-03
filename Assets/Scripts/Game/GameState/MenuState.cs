using MynetDemo.Core;
using MynetDemo.Creation;
using MynetDemo.UI;
using System;
using UnityEngine;

namespace MynetDemo.Game
{
    public class MenuState : BaseGameState
    {
        IMenuStateUI _menuUI;
        public MenuState(IGameStateController parentGameStateController, IMenuStateUI menuUI) : base(parentGameStateController)
        {
            _menuUI = menuUI; 
        }

        public override void Begin()
        {
            base.Begin();

            _menuUI.ClickedPlay += MenuUI_ClickedPlay;
        }

        public override void End()
        {
            base.End();

            _menuUI.ClickedPlay -= MenuUI_ClickedPlay;
            _menuUI.Destroy();
        }

        private void MenuUI_ClickedPlay()
        {
            SwitchToPlayState();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchToPlayState();
            }
        }

        private void SwitchToPlayState()
        {
            IPlayStateUI playStateUI = StateFactory.Instance.CreatePlayStateUI();
            _parentGameStateController.SwitchGameState(StateFactory.Instance.CreatePlayState(_parentGameStateController, playStateUI));
        }
    }
}
