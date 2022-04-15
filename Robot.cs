using System;
using SplashKitSDK;

public class Robot
{
    public double X { get; set; }
    public double Y { get; set; }
    public Color MainColor { get; set; }
    private Vector2D Velocity { get; set; }

    public int Width
    {
        get { return 50; }
    }
    //read only property
    public int Height
    {
        get { return 50; }
    }
    public Circle CollisionCircle
    {
        get { return SplashKit.CircleAt(X, Y, 20); }
    }



    public Robot (Window gameWindow, Player _Player)
    {
        X = SplashKit.Rnd(gameWindow.Width - Width);
        Y = SplashKit.Rnd(gameWindow.Height - Height); 
        MainColor = Color.RandomRGB(200);
        
        const int SPEED = 4;
        //if (SplashKit.KeyDown(KeyCode.SpaceKey))
        //{
        //    speed += 7;
        //}


        //get a point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X, Y = Y
        };

        //point for the player so robot can move towards the player one time
        //will not always update so robot will just move straight
        Point2D toPt = new Point2D()
        {
            X = _Player.X,
            Y = _Player.Y
        };

        // Calculate the direction to head
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, SPEED);
        
        
    }
    public void Draw()
    {
        SplashKit.ProcessEvents();
        
        double leftX =  X + 12;
        double rightX = X + 27;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        SplashKit.FillRectangle(Color.Gray, X, Y, 50, 50);
        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
    }
    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }
}