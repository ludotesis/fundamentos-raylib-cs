using Raylib_cs;                        
using System.Numerics;

class Meteoro
{
    Vector2 posicion;
    Texture2D sprite;
    public Rectangle hitbox;

    bool activado;

    public Meteoro(float posicionInicialX, float posicionInicialY)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
        activado = true;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Meteoro.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
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
        activado = false;
    }

    public bool VerActivado()
    {
        return activado;
    }
}