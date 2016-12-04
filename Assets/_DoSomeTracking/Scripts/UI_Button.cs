using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour {
    public static event StringDelegate EventButtonPressed;

    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => Pressed());
    }

    public void Pressed() {
        if (EventButtonPressed != null) {
            EventButtonPressed(this.name);
        }
    }
}
