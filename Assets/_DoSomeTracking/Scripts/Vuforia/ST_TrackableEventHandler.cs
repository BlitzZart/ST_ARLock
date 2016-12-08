using UnityEngine;
using System.Collections;
using Vuforia;

public class ST_TrackableEventHandler : DefaultTrackableEventHandler {

    [Header("GameObjects to activate/deactivate")]
    public GameObject[] gameObjects;

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        foreach (GameObject item in gameObjects)
            item.SetActive(true);
    }
    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        foreach (GameObject item in gameObjects)
            item.SetActive(false);
    }
}
