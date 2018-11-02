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
    private int levelHeight;

	public Mountain(string assetname, int layer = 0, string id = "", int levelHeight = 1)
		: base(assetname, layer, id)
	{
        position = new Vector2((float)GameEnvironment.Random.NextDouble() * GameEnvironment.Screen.X - Width / 2, 0);
        startPosition = position;
        this.levelHeight = levelHeight;

        switch (layer)
        {
            case 0: speedModifier = new Vector2(1f, 0.2f); break;
            case 1: speedModifier = new Vector2(0.8f, 0.25f); break;
            case 2: speedModifier = new Vector2(0.5f, 0.3f); break;
        }
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
	{
		base.Draw(gameTime, spriteBatch);
	}

	public override void Update(GameTime gameTime)
	{
		base.Update(gameTime);

        //parallax
        position.X = (startPosition.X + Camera.Instance.Position.X) * speedModifier.X;
        int cameraDif = levelHeight - GameEnvironment.Screen.Y;
        float heightMod = Camera.Instance.Position.Y / cameraDif * speedModifier.Y;
        position.Y = Camera.Instance.Position.Y + GameEnvironment.Screen.Y - Height - heightMod * cameraDif;
        
    }
}

