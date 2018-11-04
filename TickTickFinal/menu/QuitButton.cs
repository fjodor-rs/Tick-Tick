using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class QuitButton : Button
{
    public QuitButton(string imageAsset, int layer = 0, string id = "quitButton") : base(imageAsset, layer, id)
    {
    }
	
    public override void HandleInput(InputHelper inputHelper)
    {
        //De muispositie binnen het scherm wordt gechecked t.o.v. de boundingbox
        pressed = inputHelper.MouseLeftButtonPressed() &&
            BoundingBox.Contains((int)inputHelper.MousePosition.X + Camera.Instance.Position.X, (int)inputHelper.MousePosition.Y + Camera.Instance.Position.Y);
		Camera.Instance.ResetScreen();
    }

    public override void Update(GameTime gameTime)
    {
        //het laten meebewegen van de button t.o.v. de camera
        base.Update(gameTime);
        position.X = Camera.Instance.Position.X + GameEnvironment.Screen.X - 10 - Width;
        position.Y = Camera.Instance.Position.Y + 10;
    }
}