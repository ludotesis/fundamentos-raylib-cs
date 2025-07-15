using Raylib_cs;
using System.Numerics;

class Jugador
{
    Vector2 posicion;
    Texture2D sprite;
    Rectangle hitbox;

    float velocidad;
    float maximoX;

    int vidas = 3;

    bool activado;

    public Jugador(float posicionInicialX, float posicionInicialY, float velocidad)
    {
        posicion.X = posicionInicialX;
        posicion.Y = posicionInicialY;
        activado = true;
        this.velocidad = velocidad;
    }

    public void CargarSprite()
    {
        sprite = Raylib.LoadTexture("Jugador.png");
        hitbox = new Rectangle(posicion, sprite.Width, sprite.Height);
        maximoX = Program.ANCHO_VENTANA - sprite.Width;
    }

    public void Mover(float deltaTime)
    {
        if (!activado) return;

        if (Raylib.IsKeyDown(KeyboardKey.D) && (posicion.X < maximoX))
        {
            posicion.X = posicion.X + velocidad * deltaTime;
        }

        if (Raylib.IsKeyDown(KeyboardKey.A) && (posicion.X > 0f))
        {
            posicion.X = posicion.X - velocidad * deltaTime;
        }

        hitbox.X = posicion.X;
        hitbox.Y = posicion.Y;
    }

    public void Disparar(Proyectil proyectil)
    {
        if (!activado) return;

        if (Raylib.IsKeyPressed(KeyboardKey.Space) && !proyectil.VerActivado())
        {
            Console.WriteLine("GENERAR DISPARO");
            proyectil.IniciarProyectil(posicion.X, posicion.Y);
        }
    }

    public bool CollisionJugador(Rectangle otroHitbox)
    {
        if (!activado) return false;

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
