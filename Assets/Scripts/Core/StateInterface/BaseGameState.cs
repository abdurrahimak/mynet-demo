﻿using UnityEngine;

namespace MynetDemo.Core
{
    public abstract class BaseGameState : IGameState
    {
        protected IGameStateController _parentGameStateController;

        public BaseGameState(IGameStateController parentGameStateController)
        {
            _parentGameStateController = parentGameStateController;
        }

        public void OnServerInitialized(params object[] objects)
        {

        }

        public virtual void Begin()
        {

        }

        public virtual void End()
        {

        }

        public virtual void Update()
        {

        }
    }
}
