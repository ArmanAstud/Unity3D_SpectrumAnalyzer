using UnityEngine;
using System.Collections;

public class LvlScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape")) { Application.Quit(); }
	
	}


    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 60, 80, 40), "Circular"))
        {
            Application.LoadLevel("Circular");
        }
        if (GUI.Button(new Rect(10, 110, 80, 40), "Lineal"))
        {

            Application.LoadLevel("Lineal");
        }
    }





}
