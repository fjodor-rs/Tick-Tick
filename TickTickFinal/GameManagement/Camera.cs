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
	public int levelWidth, levelHeight;

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

	public void SetFocalPoint(Vector2 focalPosition)
	{
		position = new Vector2(focalPosition.X - GameEnvironment.Screen.X / 2, focalPosition.Y - GameEnvironment.Screen.Y / 2);
        position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X / 2 - levelWidth * 72);
		position.Y = MathHelper.Clamp(position.Y, 0, -GameEnvironment.Screen.Y + levelHeight * 55);
		viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
	}

	public void ResetScreen()
	{
		viewMatrix = Matrix.Identity;
		//levelWidth = 0;
		//levelHeight = 0;
	}
}

