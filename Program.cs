using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
       Window gameWindow = new Window ("Robot Dodge",800,600);
       RobotDodge game = new RobotDodge(gameWindow);
       
       
       while (!gameWindow.CloseRequested && !game.Quit)
       {
       SplashKit.ProcessEvents();
       game.HandleInput();
       gameWindow.Refresh(60);
       //gameWindow.Clear(Color.White);
       //game.StayOnWindow(gameWindow);
       game.Update();
       game.Draw();
       }
       
    }
    
}
