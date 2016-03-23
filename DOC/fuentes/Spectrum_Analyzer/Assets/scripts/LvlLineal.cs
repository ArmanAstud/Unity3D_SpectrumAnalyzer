using UnityEngine;
using System.Collections;

public class LvlLineal : MonoBehaviour {

	public bool inicio =true;
	public bool pause =false;
	public float Ax;
	private float posX=0f;

    AudioSource audio;
    public AudioClip [] clip;

    public GameObject cube;
    public int ncubes = 1024;

    float[] spectrum;
    GameObject[] cubes;

    int i, j, size;
	public int cancion=0;

    public int r, g, b, eleccion;
    public bool play, act_lineal,lineal=false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0.0F;
        InvokeRepeating("musica", 0.0F, 0.5F);
        audio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("escape")) { Application.LoadLevel("main_scene"); }
		Ax = 10f/ncubes;


        spectrum = AudioListener.GetSpectrumData(ncubes, 0, FFTWindow.BlackmanHarris);

        if (play && lineal)
        {

            Time.timeScale = 1.0F;
            audio.mute = false;

            //Escalar objetos en funcion de su espectro
            for (i = 0; i < cubes.Length; i++)
            {
                Vector3 previousScale = cubes[i].transform.localScale;

                	previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * size, Time.deltaTime * 60);
                cubes[i].transform.localScale = previousScale;
            }

        }
        if (act_lineal)
        {

			 

            //Instanciar objetos
            for (i = 1; i < ncubes; i++)
            {

				Vector3 pos = new Vector3(5,0,0);
                size = 60;
				pos = new Vector3((Mathf.Log(i)-2), 0, 2);
				


                if (eleccion == 0)
                {
                    Instantiate(cube, pos, Quaternion.identity);
                    cubes = GameObject.FindGameObjectsWithTag("Cube");
                }

            }
            act_lineal = false;
            play = true;
            lineal = true;

        }
    }
    void musica()
    {
        if (Time.timeScale == 1.0F && audio.isPlaying == false && inicio)
        { audio.PlayOneShot(clip[cancion], 1.0F); 
			inicio=false;
		}
    }

    void OnGUI()
    {
		GUI.Label (new Rect (Screen.width / 2, 20, Screen.width / 2, 30), "track: " + (cancion+1));

        if (GUI.Button(new Rect(10, 10, 80, 80), "Play"))
        {

			if(inicio){
            	act_lineal = true;
			}
			else if(!audio.isPlaying)
			{
				pause=false;
				audio.Play();
				Debug.Log("playing sound");
			}

        }
		if (GUI.Button (new Rect (10, 100, 80, 80), "STOP")&& !inicio) 
		{
			pause=true;
			audio.Stop();
			audio.clip=clip[cancion];
			Debug.Log("stoping sound");
		}
		if (GUI.Button (new Rect (Screen.width-60, 10, 40, 40), "1")) 
		{
			cancion=0;
			audio.clip=clip[cancion];
		}
		if (GUI.Button (new Rect (Screen.width-60, 50, 40, 40), "2")) 
		{
			cancion=1;
			audio.clip=clip[cancion];
		}
		if (GUI.Button (new Rect (Screen.width-60, 90, 40, 40), "3")) 
		{
			cancion=2;
			audio.clip=clip[cancion];
		}
		if (GUI.Button (new Rect (Screen.width-60, 130, 40, 40), "4")) 
		{
			cancion=3;
			audio.clip=clip[cancion];
		}
		if (GUI.Button (new Rect (Screen.width-60, 170, 40, 40), "5")) 
		{
			cancion=4;
			audio.clip=clip[cancion];
		}
		if (GUI.Button (new Rect (Screen.width-60, 210, 40, 40), "6")) 
		{
			cancion=5;
			audio.clip=clip[cancion];
		}

    }
}
