using SplashKitSDK;
using System;

public class Player
{
    private Bitmap _PlayerBitmap;
    //public Window _gameWindow;

    //auto properties
    public double X { get; private set; }
    public double Y { get; private set; }
    public bool Quit { get; private set; }

    //read only properties
    public int Width
    {
        get { return _PlayerBitmap.Width; }
    }
    
    public int Height
    {
        get { return _PlayerBitmap.Height; }
    }
    
    public Player(Window gameWindow)
    { 
        Quit = false;
        _PlayerBitmap = new Bitmap ("player", "Player.png");
        //Window _gameWindow = gameWindow;
        X = (gameWindow.Width - Width)/2;
        Y = (gameWindow.Height - Height)/2;
    }
    
    public void Draw()
    {
        SplashKit.ProcessEvents();
        SplashKit.DrawBitmap(_PlayerBitmap, X,Y);
        
    }
    
    public void HandleInput()
    {
        const int playerSpeed = 5;

        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y = Y- playerSpeed;
        }
        else if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y = Y + playerSpeed;
        }
         else if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X = X - playerSpeed;
        }
           else if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X = X + playerSpeed;
        }
        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }
    public void StayOnWindow(Window gameWindow)
    {
        const int GAP = 10;

        if (X < GAP)
        {
            X = GAP;
        }
        else if (X > gameWindow.Width - GAP - Width)
        {
            X = gameWindow.Width - GAP - Width;
        }
        else if (Y < GAP)
        {
            Y = GAP;
        }
        else if (Y > gameWindow.Height - GAP - Height)
        {
            Y = gameWindow.Height - GAP - Height;
        }

    }
      public bool CollidedWith(Robot robot)
    {
        return _PlayerBitmap.CircleCollision(X, Y, robot.CollisionCircle);
    }
   
}

