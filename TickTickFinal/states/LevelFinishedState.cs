using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class LevelFinishedState : GameObjectList
{
    protected IGameLoopObject playingState;
	SpriteGameObject overlay;

	public LevelFinishedState()
    {
        playingState = GameEnvironment.GameStateManager.GetGameState("playingState");
        overlay = new SpriteGameObject("Overlays/spr_welldone");
        Add(overlay);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        if (!inputHelper.KeyPressed(Keys.Space))
        {
            return;
        }	
		GameEnvironment.GameStateManager.SwitchTo("playingState");
        (playingState as PlayingState).NextLevel();
		PlayingState playState = GameEnvironment.GameStateManager.GetGameState("playingState") as PlayingState;
		Camera.Instance.LevelWidth = playState.CurrentLevel.Width;
		Camera.Instance.LevelHeight = playState.CurrentLevel.Height;
		Camera.Instance.ResetScreen();
	}

	public override void Update(GameTime gameTime)
    {
        playingState.Update(gameTime);
		overlay.Position = new Vector2(GameEnvironment.Screen.X, GameEnvironment.Screen.Y) / 2 - overlay.Center + Camera.Instance.Position;
	}

	public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        playingState.Draw(gameTime, spriteBatch);
        base.Draw(gameTime, spriteBatch);
    }
}