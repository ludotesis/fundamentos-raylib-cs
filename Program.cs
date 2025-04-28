// Importar Raylib y System.Numerics para usar Vectores
using Raylib_cs;
using System.Numerics;

// Declarar e Inicializar Vector2
Vector2 position = new Vector2(100,400);

// Inicializar ventana y contexto OpenGL
Raylib.InitWindow(800, 600, "Hello World");

// Verificar si la aplicación debe cerrarse (se presionó la tecla ESC o se hizo clic en el ícono de cerrar ventana)
while (!Raylib.WindowShouldClose())
{
    // Establecer el color de fondo
    Raylib.ClearBackground(Color.Gray);

    // Configurar el canvas (framebuffer) para comenzar a dibujar
    Raylib.BeginDrawing();
    
    // Obtener el tiempo en segundos para el último fotograma dibujado (tiempo delta)
    float deltaTime =  Raylib.GetFrameTime();

    if(position.Y < 400)
    {
        position.Y = position.Y + (25f * deltaTime);
    }

    // Verificar si se ha soltado una tecla una vez
    if (Raylib.IsKeyDown(KeyboardKey.Space)) 
    {
        position.Y = position.Y - (200f * deltaTime);
    }
    // Dibujar un círculo relleno de color (versión vectorial)
    Raylib.DrawCircleV(position, 50, Color.Red);
    // Finalizar el dibujo en el Canvas y cambia los búferes (doble búfer)
    Raylib.EndDrawing();
}
// Cerrar ventana y descargar contexto de OpenGL)
Raylib.CloseWindow();