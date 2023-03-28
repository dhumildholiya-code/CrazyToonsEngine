using CrazyToonsEngine.src.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrazyToonsEngine.src.StateMachine
{
    public abstract class BaseGameState : IGameState
    {
        public event EventHandler<BaseGameState> RequestStateChange;
        protected List<IGameobject> gameObjects;

        public BaseGameState()
        {
            gameObjects = new List<IGameobject>();
        }

        public abstract void HandleInput();
        public abstract void Enter(ContentManager content);
        public abstract void Exit(ContentManager content);
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            IGameobject[] orderedByDepth = gameObjects.OrderBy(x => x.Depth).ToArray();
            for (int i = orderedByDepth.Length - 1; i >= 0; i--)
            {
                if (orderedByDepth[i].IsActive())
                {
                    orderedByDepth[i].Draw(spriteBatch, gameTime);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            HandleInput();
            for (int i = gameObjects.Count() - 1; i >= 0; i--)
            {
                if (gameObjects[i].IsActive())
                {
                    gameObjects[i].Update(gameTime);
                }
            }
        }

        protected void ChangeState(BaseGameState newState)
        {
            RequestStateChange?.Invoke(this, newState);
        }
        protected void AddGameobject(IGameobject gameObject)
        {
            gameObjects.Add(gameObject);
        }
    }
}
