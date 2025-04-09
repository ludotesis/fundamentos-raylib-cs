﻿using Raylib_cs;

Raylib.InitWindow(800, 480, "Hello World");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();