using Raylib_cs;                  
using System.Numerics;

class Proyectil
{
    Texture2D sprite;
    Vector2 posicion;
    public Rectangle hitbox;

    float velocidad;
    float margen;

    bool activado;

    Sound sonidoColision;
    Sound sonidoDisparo;

    public Proyectil(float velocidad)
    {
        activado = false;
        this.velocidad = velocidad;
    }

    public void IniciarProyectil(float posicionInicialX, float posicionInicialY)
    {
        posicion.X = posicionInicialX + margen;
        posicion.Y = posicionInicialY - margen;
        hitbox.Y = posicion.Y;
        hitbox.X = posicion.X;
        activado = true;
        DisparoSFX();
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Proyectil.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
        margen = sprite.Height / 2f;
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
        ColisionSFX();
    }

    public void InicializarSFX()
    {
        sonidoColision = Raylib.LoadSound("Impact.mp3");
        sonidoDisparo = Raylib.LoadSound("Shoot.mp3");
    }

    void DisparoSFX()
    {
        if (!Raylib.IsSoundPlaying(sonidoDisparo))
        {
            Raylib.PlaySound(sonidoDisparo);
        }
    }

    public void ColisionSFX()
    {
        if (!Raylib.IsSoundPlaying(sonidoColision))
        {
            Raylib.PlaySound(sonidoColision);
        }
    }
    
    public void DeInicializarSFX()
    {
        Raylib.UnloadSound(sonidoColision);
        Raylib.UnloadSound(sonidoDisparo);
    }
}