using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class Camera
{
	private static Camera instance;
	Vector2 position;
	Matrix viewMatrix = Matrix.Identity;
	private int levelWidth, levelHeight;

	public Vector2 Position
	{
		get { return position; }
	}

	public Matrix ViewMatrix
	{
		get { return viewMatrix; }
	}

	public static Camera Instance
    {
		get
		{
			if (instance == null)
				instance = new Camera();
			return instance;
		}
    }

    //het focussen van de camera op de player, mits deze niet bij de randen van het level is
	public void SetFocalPoint(Vector2 focalPosition)
	{
		position = new Vector2(focalPosition.X - GameEnvironment.Screen.X / 2, focalPosition.Y - GameEnvironment.Screen.Y / 2);
        position.X = MathHelper.Clamp(position.X, 0, -GameEnvironment.Screen.X + levelWidth * 72);
		position.Y = MathHelper.Clamp(position.Y, 0, -GameEnvironment.Screen.Y + levelHeight * 55);
		viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
	}

    //We zetten de matrix op identity zodat de camera niet zwart is als het spel begint
	public void ResetScreen()
	{
		viewMatrix = Matrix.Identity;
	}

    public int LevelWidth
    {
        get { return levelWidth; }
        set { levelWidth = value; }
    }

    public int LevelHeight
    {
        get { return levelHeight; }
        set { levelHeight = value; }
    }
}

