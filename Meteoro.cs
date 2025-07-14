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

    bool activado;

    public Meteoro(float posicionInicialX, float posicionInicialY, float velocidad)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
        posicionInicial = posicion;
        activado = true;
        this.velocidad = velocidad;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Meteoro.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
        margen = sprite.Height / 2f;
    }

    public void Mover(float deltaTime)
    {
        if (!activado) return;

        if (posicion.Y < 480)
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
    }

    public bool VerActivado()
    {
        return activado;
    }
}