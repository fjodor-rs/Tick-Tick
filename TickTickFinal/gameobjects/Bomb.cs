using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Bomb : SpriteGameObject
{
	private float gravity, verticalSpeed;

	public Bomb(bool left, Vector2 position, int layer = 0, string id = "")
		: base("Sprites/spr_match", layer, id)
	{
		this.position = position;
        if (!left)
		    velocity = new Vector2(1000, -1000);
        else
            velocity = new Vector2(-1000, -1000);
        gravity = 55;
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);
		position.Y += verticalSpeed;
		verticalSpeed += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public override void Reset()
	{
		Velocity = Vector2.Zero;
		gravity = 0;
		verticalSpeed = 0;
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}
}

