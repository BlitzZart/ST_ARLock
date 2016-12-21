using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UI_ShowCode : MonoBehaviour {

    private Text text;
    private int initFontSize;

    public Color enterColor, okColor, nokColor;

	void Start () {
        text = GetComponent<Text>();
        CodeGenerator.EventSendNewCode += OnNewCode;
        CodeGenerator.EventSendMessage += OnSendMessage;
        CodeLock.EventNewCode += OnNewCode;
        CodeLock.EventSubmitCode += OnSubmitedCode;

        initFontSize = text.fontSize;
	}

	void OnDestroy () {
        CodeGenerator.EventSendNewCode -= OnNewCode;
        CodeGenerator.EventSendMessage -= OnSendMessage;
        CodeLock.EventNewCode -= OnNewCode;
        CodeLock.EventSubmitCode -= OnSubmitedCode;
    }

    private void OnSendMessage(string msg) {
        text.color = okColor;
        text.fontSize = initFontSize / 2;
        text.text = msg;
    }

    private void OnSubmitedCode(bool isValid) {
        text.fontSize = initFontSize;
        if (isValid) {
            text.text = "CORRECT";
            text.color = okColor;
        } else {
            text.text = "WRONG";
            text.color = nokColor;
        }
    }

    private void OnNewCode(int code) {
        if (code == 0) {
            text.color = new Color(1, 1, 1, 0);
        } else {
            text.color = new Color(1, 1, 1, 1);
        }
        text.fontSize = initFontSize;
        text.text = code.ToString();
        text.color = enterColor;
    }
}
