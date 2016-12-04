using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class NW_Player : NetworkBehaviour {
    public static event IntDelegate EventNewValidCode;
    public static event BooldDelegate EventCodeOK;

    public int validCode;

    void Start() {
        CodeGenerator.EventSendNewCode += OnNewCode;
        CodeLock.EventSubmitCode += OnCodeSubmitted;
    }

    void OnDestroy() {
        CodeGenerator.EventSendNewCode -= OnNewCode;
        CodeLock.EventSubmitCode -= OnCodeSubmitted;
    }

    private void OnCodeSubmitted(bool isValid) {
        if (isServer)
            return;

        // tell server
        CmdSendCodeOK(isValid);
    }

    private void OnNewCode(int code) {
        if (isServer) {
            validCode = code;
            RpcSendValidCode(code);
        }
    }

    [ClientRpc]
    private void RpcSendValidCode(int code) {
        if (isServer)
            return;

        validCode = code;
        // tell client / code lock
        if (EventNewValidCode != null)
            EventNewValidCode(code);
    }

    [Command]
    private void CmdSendCodeOK(bool isValid) {
        if (EventCodeOK != null)
            EventCodeOK(isValid);
    }
}
