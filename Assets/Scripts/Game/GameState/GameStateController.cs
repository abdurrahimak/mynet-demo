using MynetDemo.Core;
using MynetDemo.Creation;
using MynetDemo.UI;
using System;
using UnityEngine;

namespace MynetDemo.Game
{
    public class GameStateController : MonoBehaviour, IGameStateController
    {
        private IGameState _subState;
        public void SwitchGameState(IGameState gameState)
        {
            _subState?.End();
            _subState = gameState;
            _subState.Begin();
        }

        private void Start()
        {
            // initializing resources and pool objects before game start
            ResourceManager.Instance.Initialize();
            PoolerManager.Instance.Initialize();

            // game start with menu state.
            IMenuStateUI menustateUI = StateFactory.Instance.CreateMenuStateUI();
            IGameState menuState = StateFactory.Instance.CreateMenuState(this, menustateUI);
            SwitchGameState(menuState);
        }

        private void Update()
        {
            _subState?.Update();
        }
    }
}
