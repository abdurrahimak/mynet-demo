using MynetDemo.Core;
using MynetDemo.Game;
using MynetDemo.UI;
using UnityEngine;

namespace MynetDemo.Creation
{
    public class StateFactory : SingletonClass<StateFactory>
    {
        public IGameState CreateMenuState(IGameStateController gameStateController, IMenuStateUI menuUI)
        {
            return new MenuState(gameStateController, menuUI);
        }

        public IGameState CreatePlayState(IGameStateController gameStateController, IPlayStateUI playStateUI)
        {
            return new PlayState(gameStateController, playStateUI);
        }

        public IPlayStateUI CreatePlayStateUI(Transform parent = null)
        {
            GameObject prefab = ResourceManager.Instance.GetResource<GameObject>("PlayStateUI");
            PlayStateUI playStateUI = GameObject.Instantiate(prefab, parent).GetComponent<PlayStateUI>();
            return playStateUI;
        }
        public IMenuStateUI CreateMenuStateUI(Transform parent = null)
        {
            GameObject prefab = ResourceManager.Instance.GetResource<GameObject>("MenuStateUI");
            MenuStateUI menuStateUI = GameObject.Instantiate(prefab, parent).GetComponent<MenuStateUI>();
            return menuStateUI;
        }
    }
}
