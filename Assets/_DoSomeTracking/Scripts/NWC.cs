using UnityEngine;
using System.Collections;

public class NWC : MonoBehaviour {
    private static NW_Player player;
    public static NW_Player Player
    {
        get
        {
            if (player != null)
                return player;
            else
                player = GetPlayer();
            return player;
        }
    }

    static NW_Player GetPlayer() {
        NW_Player[] nwp = FindObjectsOfType<NW_Player>();
        foreach (NW_Player item in nwp) {
            if (item.hasAuthority) {
                return item;
            }
        }
        return null;
    }

    void Awake() {
        GetPlayer();
    }
}
