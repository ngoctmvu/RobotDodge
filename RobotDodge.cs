using System;
using SplashKitSDK;

public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private Robot _TestRobot;
    
    public bool Quit{
        get
        {
            return _Player.Quit;
        }
    }
     public RobotDodge(Window window)
    {
        _GameWindow = window;
        RandomBot();
        _Player = new Player(window);
        
    }
     public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
    }
     public void Draw()
    {
        _GameWindow.Clear(Color.White);
        _TestRobot.Draw();
        _Player.Draw();
    }
    public void Update()
    {
       
        if (_Player.CollidedWith(_TestRobot))
        {
           RandomBot();
        }
         
    }
    public void RandomBot()
    {
        _TestRobot = new Robot(_GameWindow, _Player);
    }
    
}