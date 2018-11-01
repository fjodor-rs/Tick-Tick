using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Mountain : SpriteGameObject
{
    private Vector2 speedModifier;
    private Vector2 startPosition;

	public Mountain(string assetname, int layer = 0, string id = "")
		: base(assetname, layer, id)
	{
		position = new Vector2((float)GameEnvironment.Random.NextDouble() * GameEnvironment.Screen.X - Width / 2,
				/*Camera.Instance.LevelHeight*/ GameEnvironment.Screen.Y - Height);
        int direction = Camera.Instance.LevelHeight;
        startPosition = position;

        switch (layer)
        {
            case 0: speedModifier = new Vector2(1, 1); break;
            case 1: speedModifier = new Vector2(0.8f, 0.9f); break;
            case 2: speedModifier = new Vector2(0.5f, 0.75f); break;
        }
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);

        position.X = (startPosition.X + Camera.Instance.Position.X) * speedModifier.X;
        //position.Y = (startPosition.Y + Camera.Instance.Position.Y) * speedModifier.Y;
    }
}

