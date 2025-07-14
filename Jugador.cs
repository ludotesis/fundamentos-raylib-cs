using Raylib_cs;
using System.Numerics;

class Jugador
{
    public Rectangle hitbox;
    public int vidas = 3;

    Vector2 posicion;
    Vector2 posicionInicial;
    Texture2D sprite;
    
    float velocidad;
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
