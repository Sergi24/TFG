using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public enum TipusMusica
{
    MusicaDePor,
    MusicaAlegre,
    MusicaTrista
}

public class MusicController : MonoBehaviour {

    public float velocitatMusica = 0.5f;
    public GameObject destination;

    private TipusMusica tipusDeMusica = TipusMusica.MusicaDePor;
    private int frequenciaMusicaDePor = 2;
    private string[] text = new string[3];
    private float distancia;
    // Use this for initialization
    void Start () {
        //Debug.Log(System.IO.Directory.GetCurrentDirectory());
        //System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory()+"\\HOLA");
        //System.IO.File.Open()
        text[0] = velocitatMusica.ToString();
        System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
    }
	
	// Update is called once per frame
	void Update () {
        distancia = (transform.position - destination.transform.position).magnitude;
        //Debug.Log(distancia);#
        if ((transform.position-destination.transform.position).magnitude > 4)
        {
            velocitatMusica = 1;
        }else if ((transform.position - destination.transform.position).magnitude < 1){
            velocitatMusica = 0.3f;
        }
        else
        {
            velocitatMusica = 0.3f+(((distancia-1)*0.7f)/3);
        }
        text[0] = "1 "+velocitatMusica.ToString();
        text[1] = "2 " + tipusDeMusica.ToString();
        text[2] = "0 " + frequenciaMusicaDePor.ToString();
        System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
    }

    public void SetMusicaDePor(int frequenciaMusicaDePor)
    {
        this.frequenciaMusicaDePor = frequenciaMusicaDePor;
    }
}
