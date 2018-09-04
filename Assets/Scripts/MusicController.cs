using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public enum TipusMusica
{
    MusicaDePor,
    MusicaAlegre,
    MusicaTrista,
    MusicaTensa
}

public class MusicController : MonoBehaviour {

    public float velocitatMusica = 0.1f, velocitatMaxima = 0.06f, velocitatMinima = 0.12f;
    public GameObject destination;

    private TipusMusica tipusDeMusica = TipusMusica.MusicaTrista;
    private int frequenciaMusicaDePor = 2, tonalitat = 0;
    private bool melodiaActivada = false, musicaPausada = true;

    private string[] text = new string[7];
    private float distancia, volumGeneral = 1;
    // Use this for initialization
    void Start () {
        //Debug.Log(System.IO.Directory.GetCurrentDirectory());
        //System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory()+"\\HOLA");
        //System.IO.File.Open()
        text[0] = velocitatMusica.ToString();
        System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
        if (SceneManager.GetActiveScene().name.Equals("Night")) tipusDeMusica = TipusMusica.MusicaDePor;
        else if (SceneManager.GetActiveScene().name.Equals("Castell")) tipusDeMusica = TipusMusica.MusicaTrista;
    }
	
	// Update is called once per frame
	void Update () {
        distancia = (transform.position - destination.transform.position).magnitude;
        
        if ((transform.position-destination.transform.position).magnitude > 50)
        {
            velocitatMusica = velocitatMinima;
        }else if ((transform.position - destination.transform.position).magnitude < 1){
            velocitatMusica = velocitatMaxima;
        }
        else
        {
            velocitatMusica = velocitatMaxima + (((distancia-1) / 49 * (velocitatMinima-velocitatMaxima)) );
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            melodiaActivada = !melodiaActivada;
        }
        Debug.Log(velocitatMusica+ " " +  distancia);
        //velocitatMusica = 0.08f;
        text[0] = "1 " + velocitatMusica.ToString();
        text[1] = "2 " + tipusDeMusica.ToString();
        text[2] = "0 " + frequenciaMusicaDePor.ToString();
        text[3] = "3 " + melodiaActivada.ToString();
        text[4] = "0 " + tonalitat.ToString();
        text[5] = "1 " + volumGeneral.ToString();
        text[6] = "3 " + musicaPausada.ToString();
        //text[3] = "2 " + frequenciaMusicaDePor.ToString();
        System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
    }

    public void SetFrequenciaMusicaDePor(int frequenciaMusicaDePor)
    {
        this.frequenciaMusicaDePor = frequenciaMusicaDePor;
    }

    public void SetMusicaPausada(bool musicaPausada)
    {
        this.musicaPausada = musicaPausada;
    }

}
