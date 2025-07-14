using Raylib_cs;                  
using System.Numerics;

class Proyectil
{
    Texture2D sprite;
    Vector2 posicion;
    public Rectangle hitbox;

    float velocidad;
    bool activado;

    public Proyectil(float velocidad)
    {
        activado = false;
        this.velocidad = velocidad;
    }

    public void IniciarProyectil(float posicionInicialX, float posicionInicialY)
    {
        posicion.X = posicionInicialX + sprite.Width / 2f;
        posicion.Y = posicionInicialY - sprite.Height / 2f;
        activado = true;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Proyectil.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
    }
    
    public void Dibujar()
    {
        if (!activado) return;

        Raylib.DrawTextureV(sprite, posicion, Color.White);
    }
}