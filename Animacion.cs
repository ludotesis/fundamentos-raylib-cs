using System.Numerics;
using Raylib_cs;

class Animacion
{
    float duracion;
    float tiempoActual = 0f;
    int frameActual = 0;

    int totalFrames;
    int columnas;
    int filas;
    int frameAncho;
    int frameAlto;

    Texture2D spritesheet;
    Rectangle frame;

    public bool Finalizada;

    public Animacion(int columnas, int filas, float duracion)
    {
        this.columnas = columnas;
        this.filas = filas;
        this.duracion = duracion;

        totalFrames = columnas * filas;
    }

    public void CargarSpritesheet(string ruta)
    {
        spritesheet = Raylib.LoadTexture(ruta);

        frameAncho = spritesheet.Width / columnas;
        frameAlto = spritesheet.Height / filas;

        Console.WriteLine(frameAncho);
        Console.WriteLine(frameAlto);

        frame = new Rectangle(0, 0, frameAncho, frameAlto);
    }

    public void Actualizar(float delta)
    {
        if (Finalizada) return;

        tiempoActual += delta;

        if (tiempoActual >= duracion / totalFrames)
        {
            tiempoActual = 0f;
            frameActual++;

            if (frameActual >= totalFrames)
            {
                frameActual = totalFrames - 1;
                Finalizada = true; 
            }

            int x = frameActual % columnas;
            int y = frameActual / columnas;

            frame.X = x * frameAncho;
            frame.Y = y * frameAlto;
        }
    }

    public void Dibujar(Vector2 posicion, Color color)
    {
        Raylib.DrawTextureRec(spritesheet, frame, posicion, color);
    }

    public void Reiniciar()
    {
        frameActual = 0;
        tiempoActual = 0f;
        Finalizada = false;
    }

}