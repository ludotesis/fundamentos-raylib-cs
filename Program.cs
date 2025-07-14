using Raylib_cs;
using System.Numerics;

class Program
{
    public static void Main()
    {

        Vector2 posicionJugador  = new Vector2(400, 240);
        int vidas = 3;
  
        Meteoro meteoro1 = new Meteoro(600, 240);
        Meteoro meteoro2 = new Meteoro(0, 240);
        Meteoro meteoro3 = new Meteoro(200, 200);

        Rectangle hitboxJugador;       

        float deltaTime = 0f;

        Texture2D spriteJugador;


        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");

        spriteJugador = Raylib.LoadTexture("Jugador.png");

        meteoro1.CargarSprite();
        meteoro2.CargarSprite();
        meteoro3.CargarSprite();
        
        hitboxJugador = new Rectangle(posicionJugador, spriteJugador.Width, spriteJugador.Height);
       

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

            if (meteoro1.VerActivado() && Raylib.CheckCollisionRecs(hitboxJugador, meteoro1.hitbox))
            {
                choqueJugadorMeteoro = true;
                vidas--;
                meteoro1.Desactivar();
            }
            else if (meteoro2.VerActivado() && Raylib.CheckCollisionRecs(hitboxJugador, meteoro2.hitbox))
            {
                choqueJugadorMeteoro = true;
                vidas--;
                meteoro2.Desactivar();
            }
            else if (meteoro3.VerActivado() && Raylib.CheckCollisionRecs(hitboxJugador, meteoro3.hitbox))
            {
                choqueJugadorMeteoro = true;
                vidas--;
                meteoro3.Desactivar();
            }
            /*
            if (Raylib.CheckCollisionRecs(hitboxJugador, meteoro1.hitbox) ||
                Raylib.CheckCollisionRecs(hitboxJugador, meteoro2.hitbox) ||
                Raylib.CheckCollisionRecs(hitboxJugador, meteoro3.hitbox))
            {
                choqueJugadorMeteoro = true;
                vidas--;
                meteoro1.Desactivar();
            }
            else
            {
                choqueJugadorMeteoro = false;
            }
            */

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

            if (vidas >= 0)
            {
                Raylib.DrawText("Vidas "+vidas, 500, 10, 50, Color.DarkPurple);    
            }
            

            if (Raylib.IsKeyDown(KeyboardKey.F10))
            {
                Raylib.DrawRectangleRec(hitboxJugador, Raylib.ColorAlpha(Color.Blue, 0.5f));
                Raylib.DrawRectangleRec(meteoro1.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
                Raylib.DrawRectangleRec(meteoro2.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
                Raylib.DrawRectangleRec(meteoro3.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
            }
            
            Raylib.DrawTextureV(spriteJugador, posicionJugador, Color.White);

            meteoro1.Dibujar();
            meteoro2.Dibujar();
            meteoro3.Dibujar();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
