using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheAirBlow.Engine.API.Binary;
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
            Logger.Log("[GAME] Initializing...");
            Exiting += ExitingEvent;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            Window.Title = "Untitled Engine Runner";
            IsMouseVisible = true;
        }

        private void ExitingEvent(object sender, EventArgs e)
        {
            Logger.Log("[GAME] Exiting...");
            Loader.loaded = false;
            MainWorker.loaded = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Logger.Log("[GAME] Loading the game's assets...");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (BinaryObject obj in Loader.data.objects)
                if (obj.spritePath != "")
                {
                    string path;
                    if (Loader.debug) path = Loader.path + "\\Assets\\Sprites\\" + obj.spritePath;
                    else path = Loader.path + "\\Sprites\\" + obj.spritePath;

                    MessageBox.Show(obj.spritePath, "Debug", new string[] { "OK" });

                    if (!File.Exists(path))
                        Throw(new Exception($"Could not load sprites: Sprite for GameObject {obj.name} does not exist."));

                    using (FileStream stream = File.OpenRead(path))
                        textures.Add(obj.name, Texture2D.FromStream(graphics.GraphicsDevice, stream));
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
            GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(MainWorker.currentRoom.color.R, MainWorker.currentRoom.color.G, MainWorker.currentRoom.color.B));
            spriteBatch.Begin();

            foreach (RoomObject obj in MainWorker.currentRoom.roomObjects)
            {
                try
                {
                    int posX = obj.x * MainWorker.currentRoom.gridSize;
                    int posY = obj.y * MainWorker.currentRoom.gridSize;

                    spriteBatch.Draw(textures[obj.name], new Microsoft.Xna.Framework.Rectangle(new Microsoft.Xna.Framework.Point(posX, posY), 
                        new Microsoft.Xna.Framework.Point(MainWorker.currentRoom.gridSize, MainWorker.currentRoom.gridSize)), 
                        Microsoft.Xna.Framework.Color.White);
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
