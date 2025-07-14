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
        hitbox.Y = posicion.Y;
        hitbox.X = posicion.X;
        activado = true;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Proyectil.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
    }

    public void Mover(float deltaTime)
    {
        if (!activado) return;

        if (posicion.Y > 0)
        {
            posicion.Y -= velocidad * deltaTime;
        }
        else
        {
            activado = false;
        }

        hitbox.Y = posicion.Y;
        hitbox.X = posicion.X;
    }

    public bool CollisionProyectil(Rectangle otroHitbox)
    {
        return Raylib.CheckCollisionRecs(hitbox, otroHitbox);
    }

    public void Dibujar()
    {
        if (!activado) return;

        Raylib.DrawTextureV(sprite, posicion, Color.White);
    }

    public bool VerActivado()
    {
        return activado;
    }
    
    public void Desactivar()
    {
        activado = false;
    }
}