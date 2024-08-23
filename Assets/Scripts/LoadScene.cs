using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        if(GUI.Button (new Rect (0,50,50,10),"Load Sceen")){
            SceneManager.LoadScene("Animation");
        }
    }
}
