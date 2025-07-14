using Raylib_cs;
using System.Numerics;

class Program
{
    public static void Main()
    {

        Vector2 posicion  = new Vector2(400, 240);
        Vector2 dimension = new Vector2(200, 220);

        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");
     
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Subscribite", 12, 12, 60, Color.Red);

            Raylib.DrawRectangleV(posicion, dimension, Color.DarkBrown);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
