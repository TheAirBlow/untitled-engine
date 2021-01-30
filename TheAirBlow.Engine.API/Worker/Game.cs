using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Worker
{
    public class EngineGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public EngineGame()
        {
            Exiting += ExitingEvent;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            Window.Title = "Untitled Engine Runner";
            IsMouseVisible = true;
        }

        private void ExitingEvent(object sender, EventArgs e)
        {
            Loader.loaded = false;
            MainWorker.loaded = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (GameObject obj in Loader.objects.objects)
            {
                if (obj.sprite != "")
                {
                    if (!File.Exists(Loader.path + "\\Assets\\Sprites\\" + obj.sprite))
                        Throw(new Exception($"Could not load objects' sprites: GameObject's {obj.name} sprite wasn't found in game's Assets."));

                    using (FileStream fileStream = new FileStream(Loader.path + "\\Assets\\Sprites\\" + obj.sprite, FileMode.Open))
                        textures.Add(obj.name, Texture2D.FromStream(graphics.GraphicsDevice, fileStream));
                }
            }

            font = Content.Load<SpriteFont>("main");
        }

        protected override void Update(GameTime gameTime)
        {
            graphics.PreferredBackBufferWidth = MainWorker.currentRoom.gridSize * MainWorker.currentRoom.gridWidth;
            graphics.PreferredBackBufferHeight = MainWorker.currentRoom.gridSize * MainWorker.currentRoom.gridHeight;
            graphics.ApplyChanges();

            // TODO: Input processing

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(MainWorker.currentRoom.color.R, MainWorker.currentRoom.color.G, MainWorker.currentRoom.color.B));
            spriteBatch.Begin();

            foreach (RoomObject obj in MainWorker.currentRoom.roomObjects)
            {
                try
                {
                    int posX = obj.x * MainWorker.currentRoom.gridSize;
                    int posY = obj.y * MainWorker.currentRoom.gridSize;

                    spriteBatch.Draw(textures[obj.name], new Rectangle(new Point(posX, posY), 
                        new Point(MainWorker.currentRoom.gridSize, MainWorker.currentRoom.gridSize)), Color.White);
                }
                catch { }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Throw(Exception e)
        {
            Logger.LogException(e);
            throw e;
        }
    }
}
