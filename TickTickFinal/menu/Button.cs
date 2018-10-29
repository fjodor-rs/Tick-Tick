using Microsoft.Xna.Framework;

class Button : SpriteGameObject
{
    protected bool pressed;

    public Button(string imageAsset, int layer = 0, string id = "")
        : base(imageAsset, layer, id)
    {
        pressed = false;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        pressed = inputHelper.MouseLeftButtonPressed() &&
            BoundingBox.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y);
    }

    public override void Reset()
    {
        base.Reset();
        pressed = false;
    }

    public bool Pressed
    {
        get { return pressed; }
    }

	public override void Update(GameTime gameTime)
	{
		if(GameEnvironment.GameStateManager.CurrentGameState == GameEnvironment.GameStateManager.GetGameState("playingState"))
			position = new Vector2(Camera.Instance.Position.X * 2 + GraphicsDeviceManager.DefaultBackBufferWidth - Width + 10, 10);
	}
}
