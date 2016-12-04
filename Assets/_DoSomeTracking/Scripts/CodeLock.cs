using UnityEngine;
using System.Collections;
using System;


public class CodeLock : MonoBehaviour {
    public static event IntDelegate EventNewCode;
    public static event BooldDelegate EventSubmitCode;

    public string entryString = "";
    public int entryNumber;

    public int validCode;

    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        UI_Button.EventButtonPressed += OnPressed;
        NW_Player.EventNewValidCode += OnNewValidCode;
	}

	void OnDestroy () {
        UI_Button.EventButtonPressed -= OnPressed;
        NW_Player.EventNewValidCode -= OnNewValidCode;
    }

    private void OnNewValidCode(int code) {
        validCode = code;
    }

    private void OnPressed(string digit) {
        if (digit == "clear")
            ClearInput();
        else if (digit == "enter")
            SubmitInput();
        else
            AddDigit(digit);


    }

    private void AddDigit(string digit) {
        if (entryString.Length < 4) {
            entryString += digit;
            entryNumber = int.Parse(entryString);
        } else {
            ClearInput();
            entryString = digit;
            entryNumber = int.Parse(entryString);
        }
        if (EventNewCode != null)
            EventNewCode(entryNumber);

        audioSource.pitch = 1;
        audioSource.Play();
    }

    private void ClearInput() {
        entryString = "";
        entryNumber = 0;
        if (EventNewCode != null)
            EventNewCode(entryNumber);

        audioSource.pitch = 0.66f;
        audioSource.Play();
    }


    private void SubmitInput() {
        bool valid = (entryNumber == validCode);


        if (EventSubmitCode != null)
            EventSubmitCode(valid);

        if (valid)
            StartCoroutine(SoundPlayer(1.3f, 0.1f, 5));
        else
            StartCoroutine(SoundPlayer(0.37f, 0.15f, 2));

    }

    IEnumerator SoundPlayer(float pitch, float breakDuration, int count) {
        audioSource.pitch = pitch;
        for (int i = 0; i < count; i++) {
            audioSource.Play();
            yield return new WaitForSeconds(breakDuration);
        }
    }
}
