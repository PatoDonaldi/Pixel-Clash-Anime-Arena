using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string nomePersonagem;
    [SerializeField] private int vida;
    [SerializeField] private int ataque;
    [SerializeField] private int defesa;
    [SerializeField] private int especial;
    [SerializeField] private bool estahVivo = true;
    [SerializeField] private DiretorBatalha dB;
    [SerializeField] private Sprite spriteDerrota;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public string GetNomePersonagem()
    {
        return nomePersonagem;
    }

    public int GetVida()
    {
        return vida;
    }

    public bool VerificaVida() //retorna true se o jogador esta vivo e false se esta morto
    {
        return estahVivo;
    }

    public bool VerificaEspecial() //retorna true se o jogador tem especial e false se nao tem
    {
        if (especial >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public int Ataque()
    {
        int valorAtaque = Random.Range(0,ataque);

        especial++;


        if (valorAtaque > 0)
        {
            dB.RecebeTexto("ARgh! Sinta Minha Furia!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorAtaque}");
        }
        else
        {
            dB.RecebeTexto($"{nomePersonagem} erra o ataque.");
        }


        return valorAtaque;
    }

    public int Defesa()
    {
        int valorDefesa = Random.Range(0, defesa);

        especial++;

        if(valorDefesa > 0)
        {
            dB.RecebeTexto($"{nomePersonagem} defende com {valorDefesa}");
        }
        else
        {
            dB.RecebeTexto($"{nomePersonagem} nao consegue defender.");
        }
        

        return valorDefesa;
    }

    public int Especial()
    {
        int valorEspecial = Random.Range(20, ataque);
        int chanceDeDobrar = Random.Range(0, 100);

        if (chanceDeDobrar >= 90 && especial >= 3)
        {
            int valorEspecialDobrado = valorEspecial * 2;
            dB.RecebeTexto("ARgh! Sede de Vinguança!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecialDobrado}");
            especial = 0;
            return valorEspecialDobrado;
        }
        else if (chanceDeDobrar < 90 && especial >= 3)
        {
            dB.RecebeTexto("ARgh! Vou te esmagar!");
            dB.RecebeTexto($"{nomePersonagem} ataca com {valorEspecial}");
            especial = 0;
            return valorEspecial;
        }
        else
        {
            dB.RecebeTexto("Seu especial nao esta carregado!");
            return 0;
        }
    }

    public void LevarDano(int dano)
    {
        int danoFinal = dano - Defesa();

        if (danoFinal <= 0)
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} consegue se defender!");
            anim.SetTrigger("Defesa");
        }
        else if (danoFinal <= 25)
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} leva dano de {danoFinal}.");
            anim.SetTrigger("Dano");
            vida -= danoFinal; //vida = vida - danoFinal;
        }
        else
        {
            Debug.Log("");
            dB.RecebeTexto($"{nomePersonagem} toma uma porrada de {danoFinal}.");
            anim.SetTrigger("Dano");
            vida -= danoFinal;
        }

        DefineVida();

        if (estahVivo)
        {
            Debug.Log("");
            Debug.Log($"{nomePersonagem}, vida: {vida}");
        }
        else
        {
            dB.RecebeTexto($"{nomePersonagem}, morreu!");
        }

    }
    private void DefineVida() //Verifica o valor da vida e define como morto
    {
        if (vida <= 0)
        {
            spriteRenderer.sprite = spriteDerrota;
            estahVivo = false; //Ta morto
        }
    }    
}