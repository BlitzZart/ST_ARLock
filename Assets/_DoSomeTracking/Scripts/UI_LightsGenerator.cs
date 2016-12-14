using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UI_LightsGenerator : MonoBehaviour {

    public Color doneColor;
    public Image[] lights;

	void Start () {
        CodeGenerator.EventPuzzleSolved += OnPuzzleSolved;
	}
	
	void OnDestroy () {
        CodeGenerator.EventPuzzleSolved -= OnPuzzleSolved;
    }

    private void OnPuzzleSolved() {
        foreach (Image item in lights)
            item.color = doneColor;
    }
}
