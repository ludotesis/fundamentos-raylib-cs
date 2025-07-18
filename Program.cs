﻿using Raylib_cs;

class Program
{
    public const int ANCHO_VENTANA = 800;
    public const int ALTO_VENTANA  = 600;

    public static void Main()
    {

        Meteoro meteoro1 = new Meteoro(100f, 0f, 100f, 0, 200);
        Meteoro meteoro2 = new Meteoro(330f, 0f, 150f, 250, 430);
        Meteoro meteoro3 = new Meteoro(628f, 0f, 200f, 500, 672);

        Jugador jugador = new Jugador(400, 480, 250f);

        Proyectil proyectil = new Proyectil(400f);

        float deltaTime = 0f;

        Music musicaFondo;
        float volumenMusica = 0.8f;

        Raylib.InitWindow(ANCHO_VENTANA, ALTO_VENTANA, "Introducción Raylib + C#");

        jugador.CargarSprite();
        proyectil.CargarSprite();

        meteoro1.CargarSprite();
        meteoro2.CargarSprite();
        meteoro3.CargarSprite();

        Raylib.InitAudioDevice();

        musicaFondo = Raylib.LoadMusicStream("Music.wav");
        Raylib.SetMusicVolume(musicaFondo, volumenMusica);
        Raylib.PlayMusicStream(musicaFondo);

        proyectil.InicializarSFX();

        while (!Raylib.WindowShouldClose())
        {
            deltaTime = Raylib.GetFrameTime();

            Raylib.UpdateMusicStream(musicaFondo);

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
                proyectil.ColisionSFX();
            }
            else if (meteoro2.VerActivado() && jugador.CollisionJugador(meteoro2.hitbox))
            {
                jugador.Herir();
                meteoro2.Desactivar();
                proyectil.ColisionSFX();
            }
            else if (meteoro3.VerActivado() && jugador.CollisionJugador(meteoro3.hitbox))
            {
                jugador.Herir();
                meteoro3.Desactivar();
                proyectil.ColisionSFX();
            }

            if (proyectil.VerActivado() && meteoro1.VerActivado() && proyectil.CollisionProyectil(meteoro1.hitbox))
            {
                proyectil.Desactivar();
                meteoro1.Desactivar();
            }
            else if (proyectil.VerActivado() && meteoro2.VerActivado() && proyectil.CollisionProyectil(meteoro2.hitbox))
            {
                proyectil.Desactivar();
                meteoro2.Desactivar();
            }
            else if (proyectil.VerActivado() && meteoro3.VerActivado() && proyectil.CollisionProyectil(meteoro3.hitbox))
            {
                proyectil.Desactivar();
                meteoro3.Desactivar();
            }

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Black);

            if (jugador.VerVidas() >= 0)
            {
                Raylib.DrawText("Vidas " + jugador.VerVidas(), 600, 10, 50, Color.DarkPurple);
            }

            if (jugador.VerVidas() == 0)
            {
                Raylib.DrawText("Game Over", 12, 12, 60, Color.Red);
            }
            else
            {
                Raylib.DrawText("Raylib + C# 101", 12, 12, 50, Color.DarkGreen);
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

        Raylib.UnloadMusicStream(musicaFondo);
        proyectil.DeInicializarSFX();
        Raylib.CloseAudioDevice();

        Raylib.CloseWindow();
    }
}
