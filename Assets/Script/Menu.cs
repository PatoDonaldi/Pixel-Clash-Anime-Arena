using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour
{
    [SerializeField] private AudioClip som;
    private AudioSource player; 

    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

        public void Jogar()
    {
        

    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void SelecionarFireForce()
    {
        SceneManager.LoadScene("SelecionarFireForce");
    }   
        public void SelecionarDemonSlayer()
    {
        SceneManager.LoadScene("SelecionarDemonSlayer");
    }
    public void SelecionarAnime()
    {
        SceneManager.LoadScene("SelecionarAnime");
    }

    public void ARTHUR()
    {
        SceneManager.LoadScene("ARTHUR");
    }
    public void BENIMARU()
    {
        SceneManager.LoadScene("BENIMARU");
    }
    public void JOKER()
    {
        SceneManager.LoadScene("JOKER");
    }
    public void LEONARD()
    {
        SceneManager.LoadScene("LEONARD");
    }
    public void SHINRA()
    {
        SceneManager.LoadScene("SHINRA");
    }
    public void TocarSom()
    {
        player.PlayOneShot(som);
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Caminho()
    {
        SceneManager.LoadScene("Caminho");
    }
    public void Battle1()
    {
        SceneManager.LoadScene("Battle1");
    }
    public void Battle12()
    {
        SceneManager.LoadScene("Battle12");
    }
    public void Battle13()
    {
        SceneManager.LoadScene("Battle13");
    }
    public void Battle14()
    {
        SceneManager.LoadScene("Battle14 ");
    }
    public void Battle15()
    {
        SceneManager.LoadScene("Battle15");
    }
}
