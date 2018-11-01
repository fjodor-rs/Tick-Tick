using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Bomb : SpriteGameObject
{
	public Bomb(Vector2 position, int layer = 0, string id = "")
		: base("Sprites/Player/spr_celebrate@14", layer, id)
	{
		this.position = position;
		velocity = new Vector2(600, 10);
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);
	}

	public override void Reset()
	{
		base.Reset();
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}

	
}

