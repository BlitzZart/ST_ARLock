using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UI_TerminalLocked : MonoBehaviour {

    private Text text;
    private int initFontSize;

    public Color okColor, nokColor;

	void Start () {
        text = GetComponent<Text>();
        CodeGenerator.EventPuzzleSolved += OnPuzzleSolved;

        initFontSize = text.fontSize;
	}

	void OnDestroy () {
        CodeGenerator.EventPuzzleSolved -= OnPuzzleSolved;
    }

    private void OnPuzzleSolved() {
        text.color = okColor;
        text.text = "Terminal unlocked";
    }
}
