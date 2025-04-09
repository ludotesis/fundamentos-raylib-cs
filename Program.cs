using Raylib_cs;
using System.Numerics;

Vector2 position = new Vector2(100,500);

Raylib.InitWindow(800, 480, "Hello World");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
    if (Raylib.IsKeyDown(KeyboardKey.Space)) position.Y -= 3;
    Raylib.DrawCircle((int)position.X,(int)position.Y, 50, Color.Blue);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();