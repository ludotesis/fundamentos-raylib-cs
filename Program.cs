using Raylib_cs;
using System.Numerics;

class Program
{
    public static void Main()
    {

        Vector2 posicion  = new Vector2(400, 240);
        Vector2 dimension = new Vector2(200, 220);

        float deltaTime = 0f;

        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");
     
        while (!Raylib.WindowShouldClose())
        {
            deltaTime = Raylib.GetFrameTime();

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                posicion.X = posicion.X + 100f * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                posicion.X = posicion.X - 100f * deltaTime;
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Subscribite", 12, 12, 60, Color.Red);

            Raylib.DrawRectangleV(posicion, dimension, Color.DarkBrown);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
