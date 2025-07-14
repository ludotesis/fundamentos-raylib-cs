using Raylib_cs;
using System.Numerics;

class Jugador
{
     Vector2 posicion;
    Vector2 posicionInicial;
    Texture2D sprite;
    public Rectangle hitbox;

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
