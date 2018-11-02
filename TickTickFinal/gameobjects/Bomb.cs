using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Bomb : AnimatedGameObject
{
	private float gravity, verticalSpeed;

	public Bomb(bool left, Vector2 position, int layer = 0, string id = "")
		: base(layer, id)
	{
		LoadAnimation("Sprites/Player/spr_celebrate@14", "celebrate", false, 0.05f);
		LoadAnimation("Sprites/Player/spr_explode@5x5", "explode", false, 0.04f);
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
		PlayAnimation("celebrate");
        //TileField tiles = GameWorld.Find("tiles") as TileField;
        //Tile currentTile = tiles.Get((int)position.X, (int)position.Y) as Tile;
        //TileType tileType = tiles.GetTileType((int)position.X, (int)position.Y);
        //if (tileType != TileType.Background)
        //{
        //    PlayAnimation("explode");
        //    velocity = Vector2.Zero;
        //}

    }

    public override void Reset()
	{
		Velocity = Vector2.Zero;
		gravity = 0;
		verticalSpeed = 0;
		PlayAnimation("explode");
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}
}

