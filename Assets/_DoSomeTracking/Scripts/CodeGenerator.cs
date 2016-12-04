using UnityEngine;
using System.Collections;

public delegate void VoidDelegate();
public delegate void BooldDelegate(bool isValid);
public delegate void IntDelegate(int code);
public delegate void StringDelegate(string msg);

public class CodeGenerator : MonoBehaviour {
    public static event IntDelegate EventSendNewCode;
    public static event IntDelegate EventGotNewCode;
    public static event StringDelegate EventSendMessage;
    public static event VoidDelegate EventPuzzleSolved;

    public string message = "Access granted! Go to the ...";
    public float frequency = .5f;
    public static float validDuration;

    private int _okGoal = 3;
    private int _okCounter = 0;
    private AudioSource _audioSource;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
        InvokeRepeating("GenerateCode", 0, frequency);
        NW_Player.EventCodeOK += OnCodeOK;

        validDuration = frequency;
    }

    void OnDestroy() {
        NW_Player.EventCodeOK -= OnCodeOK;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnCodeOK(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnCodeOK(false);
        }
    }

    private void OnCodeOK(bool isValid) {
        // puzzle soved - ignore
        if (_okCounter >= _okGoal)
            return;

        if (isValid) {
            _okCounter++;

            if (_okCounter >= _okGoal) {
                CancelInvoke("GenerateCode");
                StartCoroutine(SoundPlayer(1.3f, 0.1f, 5));

                if (EventPuzzleSolved != null)
                    EventPuzzleSolved();

                if (EventSendMessage != null)
                    EventSendMessage(message);
            }
            else {
                CancelInvoke("GenerateCode");
                InvokeRepeating("GenerateCode", 0, frequency);
                StartCoroutine(SoundPlayer(1.3f, 0.1f, 2));
            }
        }
        else {
            _okCounter = 0;
            StartCoroutine(SoundPlayer(0.37f, 0.15f, 2));
        }

        if (EventGotNewCode != null) {
            EventGotNewCode(_okCounter);
        }
    }

    private void GenerateCode() {
        int code = Random.Range(1000, 9999);
        if (EventSendNewCode != null) {
            EventSendNewCode(code);
        }
    }

    IEnumerator SoundPlayer(float pitch, float breakDuration, int count) {
        _audioSource.pitch = pitch;
        for (int i = 0; i < count; i++) {
            _audioSource.Play();
            yield return new WaitForSeconds(breakDuration);
        }
    }
}