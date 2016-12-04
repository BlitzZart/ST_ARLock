using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UI_Indicator : MonoBehaviour {

    private Image[] okLights;

    public Color okColor, nokColor;

	void Start () {
        okLights = GetComponentsInChildren<Image>();

        CodeGenerator.EventGotNewCode += OnGotValidCode;
	}
	
	void OnDestroy () {
        CodeGenerator.EventGotNewCode -= OnGotValidCode;
    }

    private void OnGotValidCode(int code) {
        if (code > okLights.Length)
            return;

        // disable all
        for (int i = 0; i < okLights.Length; i++) {
            okLights[i].color = nokColor;
        }

        // enable 
        for (int i = 0; i < code; i++) {
            okLights[i].color = okColor;
        }
    }
}
