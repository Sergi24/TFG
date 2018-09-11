using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public enum TipusMusica
{
    MusicaDePor,
    MusicaAlegre,
    MusicaTrista,
    MusicaMenu
}

public class MusicController : MonoBehaviour {

    public float velocitatMusica, velocitatMaxima, velocitatMinima;
    public GameObject destination;
    public bool melodiaActivada;

    private TipusMusica tipusDeMusica = TipusMusica.MusicaMenu;
    private int frequenciaMusicaDePor = 2, tonalitat = 0, ultimaTonalitat = 0;
    private bool musicaPausada = false, thundersActived = false;
    private string[] text = new string[7];
    private float distancia, volumGeneral = 1;
    private int lastNumCompas, lastMetronom;
    // Use this for initialization
    void Start () {
        // text[0] = velocitatMusica.ToString();
        //System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
        if (SceneManager.GetActiveScene().name.Equals("Demo"))
        {
            tipusDeMusica = TipusMusica.MusicaAlegre;
            melodiaActivada = true;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Night"))
        {
            tipusDeMusica = TipusMusica.MusicaDePor;
            frequenciaMusicaDePor = 6;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Castell"))
        {
            tipusDeMusica = TipusMusica.MusicaTrista;
            musicaPausada = true;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Portals")) tipusDeMusica = TipusMusica.MusicaMenu;
        else if (SceneManager.GetActiveScene().name.Equals("Recta Final"))
        {
            tipusDeMusica = TipusMusica.MusicaAlegre;
            melodiaActivada = true;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Credits"))
        {
            tipusDeMusica = TipusMusica.MusicaAlegre;
            melodiaActivada = true;
        }
    }

    // Update is called once per frame
    void Update() {
        distancia = (transform.position - destination.transform.position).magnitude;

        if ((transform.position - destination.transform.position).magnitude > 20)
        {
            velocitatMusica = velocitatMinima;
        } else if ((transform.position - destination.transform.position).magnitude < 5) {
            velocitatMusica = velocitatMaxima;
        }
        else
        {
            velocitatMusica = velocitatMaxima + (((distancia-5) / 15 * (velocitatMinima - velocitatMaxima)));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            melodiaActivada = !melodiaActivada;
        }
        //Debug.Log(velocitatMusica+ " " +  distancia);
        //velocitatMusica = 0.12f;
        text[0] = "1 " + velocitatMusica.ToString();
        text[1] = "2 " + tipusDeMusica.ToString();
        text[2] = "0 " + frequenciaMusicaDePor.ToString();
        text[3] = "3 " + melodiaActivada.ToString();
        text[4] = "0 " + ultimaTonalitat.ToString();
        text[5] = "1 " + volumGeneral.ToString();
        text[6] = "3 " + musicaPausada.ToString();
        try
        {

            string[] linies = File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\escritPerSonicPi.txt");
            int numCompas = int.Parse(linies[0]);
            int numMetronom = int.Parse(linies[1]);
            int numBaseDelCompas = int.Parse(linies[2]);

            if (tipusDeMusica.Equals(TipusMusica.MusicaTrista) && distancia <= 25)
            {
                if (lastNumCompas != numCompas)
                {
                    lastNumCompas = numCompas;
                    thundersActived = false;
                    Invoke("ActivatePlasmaExplosion", 0.91f);
                }
                if (!thundersActived && numBaseDelCompas == numMetronom)
                {
                    thundersActived = true;
                    Invoke("ActivateThunders", 0.7f);
                }
            }
            if (SceneManager.GetActiveScene().name == "Portals")
            {
                string actiu, inactiu;
                if (numBaseDelCompas == 3)
                {
                    actiu = "Compas3";
                    inactiu = "Compas4";
                }
                else
                {
                    actiu = "Compas4";
                    inactiu = "Compas3";
                }
                foreach (MeshRenderer renderer in GameObject.Find(actiu).GetComponentsInChildren<MeshRenderer>())
                {
                    renderer.enabled = true;
                }
                foreach (MeshRenderer renderer in GameObject.Find(inactiu).GetComponentsInChildren<MeshRenderer>())
                {
                    renderer.enabled = false;
                }
            }
            Debug.Log(numCompas % 4 +"  "+ numMetronom);
            if (numCompas % 4 == 0 && numMetronom == 0)
            {
                Debug.Log("AQUI");
                ultimaTonalitat = tonalitat;
                text[4] = "0 " + ultimaTonalitat.ToString();
            }
            File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "\\HOLA\\HOLA.txt", text);
        }
        catch (IOException) { };
    }

    public void ActivatePlasmaExplosion()
    {
        foreach (GameObject pe in GameObject.FindGameObjectsWithTag("PlasmaExplosion"))
        {
            if (pe.GetComponent<AudioSource>() != null)
            {
                pe.GetComponent<AudioSource>().Play();
            }
            foreach (ParticleSystem ps in pe.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Emit(10);
            }
        }
    }

    public void ActivateThunders()
    {
        GameObject thunders = GameObject.Find("Thunders");
        thunders.GetComponent<AudioSource>().Play();
        thunders.GetComponent<ParticleSystem>().Emit(12);
    }

    public void SetFrequenciaMusicaDePor(int frequenciaMusicaDePor)
    {
        this.frequenciaMusicaDePor = frequenciaMusicaDePor;
    }

    public void SetMusicaPausada(bool musicaPausada)
    {
        this.musicaPausada = musicaPausada;
    }

    public void SetTonalitat(int tonalitat)
    {
        this.tonalitat = tonalitat;
    }
}
