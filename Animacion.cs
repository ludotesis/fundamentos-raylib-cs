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
        frame = new Rectangle(0, 0, spritesheet.Width / columnas, spritesheet.Height / filas);
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

            frame.X = x * frame.Width;
            frame.Y = y * frame.Height;
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