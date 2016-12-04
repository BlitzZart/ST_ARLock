using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UI_Bar : MonoBehaviour {

    private RectTransform bar;
    private float elapsedTime;

	void Start () {
        bar = GetComponent<RectTransform>();
        CodeGenerator.EventSendNewCode += OnNewCode;
        CodeGenerator.EventPuzzleSolved += OnPuzzleSolved;
    }
    void Update() {
        if (elapsedTime < CodeGenerator.validDuration) {
            elapsedTime += Time.deltaTime;
        }
        bar.localScale = new Vector2(elapsedTime / CodeGenerator.validDuration, 1);
    }
    void OnDestroy() {
        CodeGenerator.EventSendNewCode -= OnNewCode;
        CodeGenerator.EventPuzzleSolved -= OnPuzzleSolved;
    }

    private void OnPuzzleSolved() {
        Destroy(this.gameObject);
    }

    private void OnNewCode(int code) {
        elapsedTime = 0;
    }
}