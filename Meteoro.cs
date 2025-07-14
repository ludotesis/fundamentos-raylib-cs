using Raylib_cs;                        
using System.Numerics;

class Meteoro
{
    Vector2 posicion;
    Texture2D sprite;
    Rectangle hitbox;

    public Meteoro(float posicionInicialX, float posicionInicialY)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Meteoro.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
    }

    public void Dibujar()
    {
        Raylib.DrawTextureV(sprite, posicion, Color.White);
    }
}