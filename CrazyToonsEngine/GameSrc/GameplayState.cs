using CrazyToonsEngine.src.InputSystem;
using CrazyToonsEngine.src.Objects;
using CrazyToonsEngine.src.StateMachine;
using CrazyToonsEngine.src.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyToonsEngine.GameSrc
{
    public class GameplayState : BaseGameState
    {
        private Texture2D _testTex;

        public GameplayState() : base()
        {
        }

        public override void Enter(ContentManager content)
        {
            _testTex = new Texture2D(Global.GraphicsDevice, 1, 1);
            _testTex.SetData(new Color[] { Color.White });

            Sprite test = new Sprite("Test", _testTex, Vector2.Zero);
            test.Color = Color.Green;
            test.transform.scale = new Vector2(300, 200);
            AddGameobject(test);
        }

        public override void Exit(ContentManager content)
        {
            gameObjects.Clear();
            _testTex.Dispose();
            content.Unload();
        }

        public override void HandleInput()
        {
            if (Input.GetKeyDown(Keys.Space))
            {
                ChangeState(new MainMenuState());
            }
        }
    }
}
