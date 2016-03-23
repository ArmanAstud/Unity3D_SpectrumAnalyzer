using UnityEngine;
using System.Collections;

public class analizer_unity : MonoBehaviour {

	AudioSource audio;
    Color linea;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		float[] spectrum = audio.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);
		int i = 1;
		while (i <1023) {

			//if (i < 170) { linea = Color.green; }
            //else if (i >= 170 && i < 341) { linea = Color.cyan; }
           // else if (i >= 341 && i < 682) { linea = Color.yellow; }
           // else { linea = Color.red; } 
			Debug.DrawLine (new Vector3 (Mathf.Log(i), 0, 0), new Vector3 (Mathf.Log(i), Mathf.Log (spectrum [i]) + 10, 0), linea);


			i++;

		}
	}
}
