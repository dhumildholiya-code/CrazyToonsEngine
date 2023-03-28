using CrazyToonsEngine.src.InputSystem;
using CrazyToonsEngine.src.Objects;
using CrazyToonsEngine.src.StateMachine;
using CrazyToonsEngine.src.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CrazyToonsEngine.GameSrc
{
    public class MainMenuState : BaseGameState
    {
        private Texture2D _testTex;
        private Texture2D _ballTex;
        private SpriteFont _testFont;
        Text text1;

        public MainMenuState() : base()
        {
        }

        public override void Enter(ContentManager content)
        {
            _testTex = new Texture2D(Global.GraphicsDevice, 1, 1);
            _testTex.SetData(new Color[] { Color.White });
            _ballTex = content.Load<Texture2D>("ball");
            _testFont = content.Load<SpriteFont>("TestFont");

            Button button = new Button("Button", _testTex, Vector2.Zero, Anchor.MiddleCenter);
            button.transform.scale *= 100f;
            button.OnClick += HandleClick;
            AddGameobject(button);

            //Transform ballTransform = new Transform(new Vector2(Screen.HalfWidth, Screen.HalfHeight));
            //Sprite ballSprite = new Sprite("Test", _testTex, ballTransform);
            //ballSprite.transform.scale = new Vector2(300, 200);
            //Text ballLabel = new Text("Test Label", _testFont, "Testing", new Vector2(0, -150), ballTransform.position);
            //Ball ball = new Ball("Ball", ballTransform, ballSprite, ballLabel);
            //AddGameobject(ball);

            text1 = new Text("Text 1",_testFont, "Testing 1", Vector2.Zero, Anchor.TopCenter);
            AddGameobject(text1);
            Text text2 = new Text("Text 2", _testFont, "Testing 2", Vector2.Zero, Anchor.BottomCenter);
            AddGameobject(text2);
        }

        private void HandleClick(object sender, EventArgs e)
        {
            text1.SetActive(false);
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
