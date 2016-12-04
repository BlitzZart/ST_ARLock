using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UI_ScaleNWHUD : MonoBehaviour {
    NetworkManagerHUD hud;
	// Use this for initialization
	void Start () {
        hud = FindObjectOfType<NetworkManagerHUD>();

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
