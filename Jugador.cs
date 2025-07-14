using Raylib_cs;
using System.Numerics;

class Jugador
{
    
    

    Vector2 posicion;
    Vector2 posicionInicial;
    Texture2D sprite;
    Rectangle hitbox;

    float velocidad;
    int vidas = 3;

    bool activado;
    
    public Jugador(float posicionInicialX, float posicionInicialY, float velocidad)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
        posicionInicial = posicion;
        activado = true;
        this.velocidad = velocidad;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Jugador.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
    }

    public void Mover(float deltaTime)
    {
         if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                posicion.X = posicion.X + velocidad * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                posicion.X = posicion.X - velocidad * deltaTime;
            }

            hitbox.X = posicion.X;
            hitbox.Y = posicion.Y;
    }

    public bool CollisionJugador(Rectangle otroHitbox)
    {
        return Raylib.CheckCollisionRecs(hitbox, otroHitbox);
    }

    public void Dibujar()
    {
        if (activado)
        {
            Raylib.DrawTextureV(sprite, posicion, Color.White);
        }
    }

    public void Herir()
    {
        vidas--;
        if (vidas == 0)
        {
            Desactivar();
        }
    }

    public int VerVidas()
    {
        return vidas;
    }

    public Rectangle GetHibox()
    {
        return hitbox;
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
