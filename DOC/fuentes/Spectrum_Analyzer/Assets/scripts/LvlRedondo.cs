using UnityEngine;
using System.Collections;

public class LvlRedondo : MonoBehaviour {



    AudioSource audio;
    public AudioClip clip;
    public GameObject cube, lucesRadial;
    public int ncubes = 10;
    float[] spectrum;
    public float radius;
    GameObject[] cubes;
    int i, j, size;
    public int r, g, b, eleccion;
    public bool play, act_circulo,luces_radial, circulo;


    // Use this for initialization
    void Start () {
        Time.timeScale = 0.0F;
        InvokeRepeating("musica", 0.0F, 0.5F);
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) { Application.LoadLevel("main_scene"); }


        spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);

        if (play&&circulo)
        {

            Time.timeScale = 1.0F;
            audio.mute = false;
            
            //Escalar objetos en funcion de su espectro
                for (i = 0; i < ncubes; i++)
                {
                    Vector3 previousScale = cubes[i].transform.localScale;
                    previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * size, Time.deltaTime * 60);
                    cubes[i].transform.localScale = previousScale;
                }

            }
        if (act_circulo)
        {
            
            
            //Instanciar objetos de forma radial 1vez
            for (i = 0; i < ncubes; i++)
            {
                size = 60;
                float angle = i * Mathf.PI * 2 / ncubes;
                Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                if (eleccion == 0)
                {
                    Instantiate(cube, pos, Quaternion.identity);
                    cubes = GameObject.FindGameObjectsWithTag("Cube");
                    if (luces_radial)
                    {
                        Instantiate(lucesRadial, new Vector3(8.58F, 1.67F, 0.08F), Quaternion.identity);
                        luces_radial = false;
                    }
                }
            }
            act_circulo = false;
            circulo = true;
            play = true;
        }

    }



    void musica()
    {
        if (Time.timeScale == 1.0F && audio.isPlaying == false)
        { audio.PlayOneShot(clip, 1.0F); }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 80, 40), "Play"))
        {
            act_circulo = true;
            luces_radial = true;
            
        }
    }
 }
