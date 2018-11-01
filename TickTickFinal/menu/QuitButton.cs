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

    public override Rectangle BoundingBox
    {
        get
        {
            int left = (int)(position.X - origin.X);
            int top = (int)(GlobalPosition.Y - origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        pressed = inputHelper.MouseLeftButtonPressed() &&
            BoundingBox.Contains((int)inputHelper.MousePosition.X + Camera.Instance.Position.X, (int)inputHelper.MousePosition.Y + Camera.Instance.Position.Y);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        position.X = Camera.Instance.Position.X + GameEnvironment.Screen.X - 10 - Width;
        position.Y = Camera.Instance.Position.Y + 10;
    }
}