using Raylib_cs;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Subscribite", 12, 12, 60, Color.Red);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
