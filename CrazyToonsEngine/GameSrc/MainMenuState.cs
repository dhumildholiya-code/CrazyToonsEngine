using CrazyToonsEngine.src;
using CrazyToonsEngine.src.InputSystem;
using CrazyToonsEngine.src.Objects;
using CrazyToonsEngine.src.StateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyToonsEngine.GameSrc
{
    public class MainMenuState : BaseGameState
    {
        private Texture2D _testTex;
        private SpriteFont _testFont;

        public MainMenuState() : base()
        {
        }

        public override void Enter(ContentManager content)
        {
            _testTex = new Texture2D(Global.GraphicsDevice, 1, 1);
            _testTex.SetData(new Color[] { Color.White });
            _testFont = content.Load<SpriteFont>("TestFont");

            Transform ballTransform = new Transform(new Vector2(Screen.HalfWidth, Screen.HalfHeight));
            Sprite ballSprite = new Sprite("Test", _testTex, ballTransform);
            ballSprite.transform.scale = new Vector2(300, 200);
            Text ballLabel = new Text("Test Label", _testFont, "Testing", ballTransform);
            Ball ball = new Ball("Ball", ballTransform, ballSprite, ballLabel);
            AddGameobject(ball);

            Text text1 = new Text("Text 1",_testFont, "Testing 1", Vector2.Zero, Anchor.TopCenter);
            AddGameobject(text1);
            Text text2 = new Text("Text 2", _testFont, "Testing 2", Vector2.Zero, Anchor.BottomCenter);
            AddGameobject(text2);
        }

        public override void Exit(ContentManager content)
        {
            _testTex.Dispose();
            content.Unload();
        }

        public override void HandleInput()
        {
            if (Input.GetKeyDown(Keys.Space))
            {
                ChangeState(new GameplayState());
            }
        }
    }
}
