using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Adding_Content
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D dinoTexture,backGround,penTexture,eraserTexture,rulerTexture;
        Random gen = new Random();
        float dinoX, dinoY,penX,penY,eraserX,eraserY,rulerX,rulerY;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 500; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions
            dinoX = gen.Next(_graphics.PreferredBackBufferWidth - dinoTexture.Width);
            dinoY = gen.Next(_graphics.PreferredBackBufferHeight - dinoTexture.Height);
            penX = gen.Next(_graphics.PreferredBackBufferWidth - penTexture.Width);
            penY = gen.Next(_graphics.PreferredBackBufferHeight - penTexture.Height);
            eraserX = gen.Next(_graphics.PreferredBackBufferWidth - eraserTexture.Width);
            eraserY = gen.Next(_graphics.PreferredBackBufferHeight - eraserTexture.Height);
            rulerX = gen.Next(_graphics.PreferredBackBufferWidth - rulerTexture.Width);
            rulerY = gen.Next(_graphics.PreferredBackBufferHeight - rulerTexture.Height);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            dinoTexture = Content.Load<Texture2D>("dino");
            backGround = Content.Load<Texture2D>("TableBackground");
            penTexture = Content.Load<Texture2D>("pen");
            eraserTexture = Content.Load<Texture2D>("eraser");
            rulerTexture = Content.Load<Texture2D>("ruler");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backGround, new Vector2(0, 0), Color.White);
            for (int i = 0; i < _graphics.PreferredBackBufferWidth / dinoTexture.Width; i++)//_graphics.PreferredBackBufferWidth/dinoTexture.Width
            {
                for (int j = 0; j < _graphics.PreferredBackBufferHeight / dinoTexture.Height; j++)//_graphics.PreferredBackBufferHeight/dinoTexture.Height
                {
                    _spriteBatch.Draw(dinoTexture, new Vector2(i * dinoTexture.Width, j * dinoTexture.Height), Color.White);//i*dinoTexture.Width, j*dinoTexture.Height
                }
            }
            
            //_spriteBatch.Draw(dinoTexture, new Vector2(dinoX, dinoY), Color.White);
            _spriteBatch.Draw(penTexture, new Vector2(penX, penY), Color.White);
            _spriteBatch.Draw(eraserTexture, new Vector2(eraserX, eraserY), Color.White);
            _spriteBatch.Draw(rulerTexture, new Vector2(rulerX, rulerY), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}