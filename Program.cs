using Raylib_cs;
using System.Numerics;

class Program
{
    public static void Main()
    {

        Vector2 posicionJugador  = new Vector2(400, 240);
        Vector2 posicionMeteoro  = new Vector2(600, 240);
       

        float deltaTime = 0f;

        Texture2D spriteJugador;
        Texture2D spriteMeteoro;

        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");

        spriteJugador = Raylib.LoadTexture("Jugador.png");
        spriteMeteoro = Raylib.LoadTexture("Meteoro.png");

        while (!Raylib.WindowShouldClose())
        {
            deltaTime = Raylib.GetFrameTime();

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                posicionJugador.X = posicionJugador.X + 100f * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                posicionJugador.X = posicionJugador.X - 100f * deltaTime;
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Subscribite", 12, 12, 60, Color.Red);

            
            Raylib.DrawTextureV(spriteJugador, posicionJugador, Color.White);
            Raylib.DrawTextureV(spriteMeteoro, posicionMeteoro, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
