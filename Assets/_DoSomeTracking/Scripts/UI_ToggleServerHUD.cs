using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UI_ToggleServerHUD : MonoBehaviour {

    private int neededClicks = 5;
    private int currentClicks = 0;

    private float coolTime = 0.5f;
    private float currentCoolTime = 0;

	public void Click () {
        currentClicks += 1;

        currentCoolTime = 0;
        if (currentClicks >= neededClicks) {
            NWM_HUD hud = FindObjectOfType<NWM_HUD>();
            hud.showGUI = !hud.showGUI;
            currentClicks = 0;
        }
	}

	void Update () {
	    if (currentCoolTime <= coolTime) {
            currentCoolTime += Time.deltaTime;
        } else if (neededClicks > 0) {
            currentClicks = 0;
        }
	}
}