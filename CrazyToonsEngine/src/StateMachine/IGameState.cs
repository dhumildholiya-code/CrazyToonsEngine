using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyToonsEngine.src.StateMachine
{
    public interface IGameState
    {
        public void Enter(ContentManager content);
        public void Exit(ContentManager content);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
