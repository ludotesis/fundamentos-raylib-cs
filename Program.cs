using Raylib_cs;

class Program
{
    public static void Main()
    {

        Meteoro meteoro1 = new Meteoro(600, 0, 100f);
        Meteoro meteoro2 = new Meteoro(0, 0, 150f);
        Meteoro meteoro3 = new Meteoro(200, 0, 200f);

        Jugador jugador = new Jugador(400, 240, 250f);

        Proyectil proyectil = new Proyectil(250f);
  
        float deltaTime = 0f;

        Raylib.InitWindow(800, 480, "Introducción Raylib + C#");

        jugador.CargarSprite();
        proyectil.CargarSprite();
        
        meteoro1.CargarSprite();
        meteoro2.CargarSprite();
        meteoro3.CargarSprite();
        
        while (!Raylib.WindowShouldClose())
        {
            deltaTime = Raylib.GetFrameTime();

            jugador.Mover(deltaTime);
            meteoro1.Mover(deltaTime);
            meteoro2.Mover(deltaTime);
            meteoro3.Mover(deltaTime);

            jugador.Disparar(proyectil);
            proyectil.Mover(deltaTime);

            if (meteoro1.VerActivado() && jugador.CollisionJugador(meteoro1.hitbox))
            {
                jugador.Herir();
                meteoro1.Desactivar();
            }
            else if (meteoro2.VerActivado() && jugador.CollisionJugador(meteoro2.hitbox))
            {
                jugador.Herir();
                meteoro2.Desactivar();
            }
            else if (meteoro3.VerActivado() && jugador.CollisionJugador(meteoro3.hitbox))
            {
                jugador.Herir();
                meteoro3.Desactivar();
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.White);

            if (jugador.VerVidas() >= 0)
            {
                Raylib.DrawText("Vidas " + jugador.VerVidas(), 500, 10, 50, Color.DarkPurple);
            }

            if (jugador.VerVidas() == 0)
            {
                Raylib.DrawText("Game Over", 12, 12, 60, Color.Red);
            }
            else
            {
                Raylib.DrawText("Subscribite", 12, 12, 60, Color.DarkGreen);
            }

            if (Raylib.IsKeyDown(KeyboardKey.F10))
            {
                Raylib.DrawRectangleRec(jugador.GetHibox(), Raylib.ColorAlpha(Color.Blue, 0.5f));
                Raylib.DrawRectangleRec(proyectil.hitbox, Raylib.ColorAlpha(Color.Yellow, 0.5f));
                Raylib.DrawRectangleRec(meteoro1.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
                Raylib.DrawRectangleRec(meteoro2.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
                Raylib.DrawRectangleRec(meteoro3.hitbox, Raylib.ColorAlpha(Color.Green, 0.5f));
            }

            jugador.Dibujar();
            proyectil.Dibujar();

            meteoro1.Dibujar();
            meteoro2.Dibujar();
            meteoro3.Dibujar();

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
