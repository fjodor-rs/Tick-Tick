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
		position = new Vector2(focalPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 2, focalPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
		if (position.X < 0) 
			position.X = 0;
		if (position.Y < 0)
			position.Y = 0;

		viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
	}
}

