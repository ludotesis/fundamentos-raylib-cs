using Raylib_cs;
using System.Numerics;

class Program
{
    public static void Main()
    {

        Vector2 posicionJugador  = new Vector2(400, 240);
        Vector2 posicionMeteoro  = new Vector2(600, 240);

        Rectangle hitboxJugador;       
        Rectangle hitboxMeteoro;  

        float deltaTime = 0f;

        Texture2D spriteJugador;
        Texture2D spriteMeteoro;

        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");

        spriteJugador = Raylib.LoadTexture("Jugador.png");
        spriteMeteoro = Raylib.LoadTexture("Meteoro.png");
        
        hitboxJugador = new Rectangle(posicionJugador, spriteJugador.Width, spriteJugador.Height);
        hitboxMeteoro = new Rectangle(posicionMeteoro, spriteMeteoro.Width, spriteMeteoro.Height);

        bool choqueJugadorMeteoro = false;

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

            hitboxJugador.X = posicionJugador.X;
            hitboxJugador.Y = posicionJugador.Y;

            choqueJugadorMeteoro = Raylib.CheckCollisionRecs(hitboxJugador, hitboxMeteoro);

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);

            if (choqueJugadorMeteoro)
            {
                Raylib.DrawText("COLISIÓN", 12, 12, 60, Color.Green);
            }
            else
            {
                Raylib.DrawText("Subscribite", 12, 12, 60, Color.Red);
            }

            if (Raylib.IsKeyDown(KeyboardKey.F10))
            {
                Raylib.DrawRectangleRec(hitboxJugador, Raylib.ColorAlpha(Color.Blue, 0.5f));
                Raylib.DrawRectangleRec(hitboxMeteoro, Raylib.ColorAlpha(Color.Green, 0.5f));
            }
            
            Raylib.DrawTextureV(spriteJugador, posicionJugador, Color.White);
            Raylib.DrawTextureV(spriteMeteoro, posicionMeteoro, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
