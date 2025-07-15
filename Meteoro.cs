using Raylib_cs;                        
using System.Numerics;

class Meteoro
{
    Vector2 posicion;
    Vector2 posicionInicial;
    Texture2D sprite;
    public Rectangle hitbox;

    float velocidad;
    float margen;
    float maximoY;

    bool activado;

    int minimoX;
    int maximoX;

    public Meteoro(float posicionInicialX, float posicionInicialY, float velocidad, int minimoX, int maximoX)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
        posicionInicial = posicion;
        activado = true;
        this.velocidad = velocidad;
        this.minimoX = minimoX;
        this.maximoX = maximoX;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Meteoro.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
        margen = sprite.Height / 2f;
        maximoY = Program.ALTO_VENTANA + sprite.Height;
    }

    public void Mover(float deltaTime)
    {
        if (!activado) return;

        if (posicion.Y < maximoY)
        {
            posicion.Y += velocidad * deltaTime;
        }
        else
        {
            Desactivar();
        }

        hitbox.Y = posicion.Y;
    }

    public void Dibujar()
    {
        if (activado)
        {
            Raylib.DrawTextureV(sprite, posicion, Color.White);
        }
    }

    public void Desactivar()
    {
        posicion.Y = posicionInicial.Y - margen;
        posicion.X = Raylib.GetRandomValue(minimoX, maximoX);
        hitbox.Y = posicion.Y;
        hitbox.X = posicion.X;
    }

    public bool VerActivado()
    {
        return activado;
    }
}