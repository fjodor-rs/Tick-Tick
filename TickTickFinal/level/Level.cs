using Microsoft.Xna.Framework;

partial class Level : GameObjectList
{
    protected bool locked, solved;
    protected QuitButton quitButton;
    private SpriteGameObject backgroundSky;
    private TimerGameObject timer;
    private SpriteGameObject timerBackground;

    public Level(int levelIndex)
    {
        // load the backgrounds
        GameObjectList backgrounds = new GameObjectList(0, "backgrounds");
        backgroundSky = new SpriteGameObject("Backgrounds/spr_sky");
        backgroundSky.Position = new Vector2(0, GameEnvironment.Screen.Y - backgroundSky.Height);
        backgrounds.Add(backgroundSky);

   
        Clouds clouds = new Clouds(2);
        backgrounds.Add(clouds);
        Add(backgrounds);

        timerBackground = new SpriteGameObject("Sprites/spr_timer", 100);
        timerBackground.Position = new Vector2(10, 10);
        Add(timerBackground);
        

        quitButton = new QuitButton("Sprites/spr_button_quit", 100);
        Add(quitButton);

        Add(new GameObjectList(1, "waterdrops"));
        Add(new GameObjectList(2, "enemies"));

        LoadTiles("Content/Levels/" + levelIndex + ".txt");
    }

    public bool Completed
    {
        get
        {
            SpriteGameObject exitObj = Find("exit") as SpriteGameObject;
            Player player = Find("player") as Player;
            if (!exitObj.CollidesWith(player))
            {
                return false;
            }
            GameObjectList waterdrops = Find("waterdrops") as GameObjectList;
            foreach (GameObject d in waterdrops.Children)
            {
                if (d.Visible)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public bool GameOver
    {
        get
        {
            TimerGameObject timer = Find("timer") as TimerGameObject;
            Player player = Find("player") as Player;
            return !player.IsAlive || timer.GameOver;
        }
    }

    public bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }

    public bool Solved
    {
        get { return solved; }
        set { solved = value; }
    }

    //---------------------------------------------------------------------------
    public SpriteGameObject Sky
    {
        get { return backgroundSky; }
        set { backgroundSky = value; }
    }

    public SpriteGameObject TimerBackground
    {
        get { return timerBackground; }
        set { timerBackground = value; }
    }

    public TimerGameObject Timer
    {
        get { return timer; }
        set { timer = value; }
    }
}

