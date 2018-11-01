using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Mountain : SpriteGameObject
{
	public Mountain(string assetname, int layer = 0, string id = "")
		: base(assetname, layer, id)
	{
		position = new Vector2((float)GameEnvironment.Random.NextDouble() * GameEnvironment.Screen.X - Width / 2,
				GameEnvironment.Screen.Y - Height);
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);
	}
}

