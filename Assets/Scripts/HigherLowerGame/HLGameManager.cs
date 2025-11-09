using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaliberGameManager : MonoBehaviour
{
    [Header("Calibers")]
    public List<CaliberData> calibers = new List<CaliberData>();

    [Header("UI")]
    public TextMeshProUGUI currentCaliberText;
    public TextMeshProUGUI nextCaliberText; // revealed after guess
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI messageText;
    public Image caliberImage;

    [Header("Buttons")]
    public Button higherButton;
    public Button lowerButton;

    [Header("Settings")]
    public float revealDelay = 0.8f;
    public bool preventSameAsCurrent = true;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    private int currentIndex = 0;
    private int score = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (calibers.Count == 0)
        {
            Debug.LogError("No calibers assigned in CaliberGameManager.");
            return;
        }

        higherButton.onClick.AddListener(() => OnGuess(true));
        lowerButton.onClick.AddListener(() => OnGuess(false));

        currentIndex = Random.Range(0, calibers.Count);
        UpdateUIInitial();
    }

    void UpdateUIInitial()
    {
        var c = calibers[currentIndex];
        if (currentCaliberText != null) currentCaliberText.text = c.displayName;
        if (nextCaliberText != null) nextCaliberText.text = "";
        if (messageText != null) messageText.text = "";
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (caliberImage != null) caliberImage.sprite = c.sprite;
    }

    public void OnGuess(bool guessHigher)
    {
        SetButtonsInteractable(false);
        StartCoroutine(HandleGuessCoroutine(guessHigher));
    }

    IEnumerator HandleGuessCoroutine(bool guessHigher)
    {
        int nextIndex = GetRandomNextIndex();
        var current = calibers[currentIndex];
        var next = calibers[nextIndex];

        if (messageText != null) messageText.text = "Prikazujem...";
        yield return new WaitForSeconds(revealDelay);

        if (nextCaliberText != null) nextCaliberText.text = next.displayName;
        if (caliberImage != null) caliberImage.sprite = next.sprite;

        bool correct = false;
        if (guessHigher) correct = next.sizeValue > current.sizeValue;
        else correct = next.sizeValue < current.sizeValue;

        if (correct)
        {
            score++;
            if (messageText != null) messageText.text = "✅ Tačno!";
            if (audioSource != null && correctSound != null) audioSource.PlayOneShot(correctSound);
        }
        else
        {
            if (messageText != null) messageText.text = "❌ Pogrešno!";
            if (audioSource != null && wrongSound != null) audioSource.PlayOneShot(wrongSound);
            score = 0;
        }

        if (scoreText != null) scoreText.text = "Score: " + score;

        currentIndex = nextIndex;

        yield return new WaitForSeconds(0.7f);
        UpdateUIInitial();
        SetButtonsInteractable(true);
    }

    int GetRandomNextIndex()
    {
        if (calibers.Count == 1) return 0;

        int idx = Random.Range(0, calibers.Count);
        if (preventSameAsCurrent)
        {
            int guard = 0;
            while (idx == currentIndex && guard < 20)
            {
                idx = Random.Range(0, calibers.Count);
                guard++;
            }
            if (idx == currentIndex)
            {
                idx = (currentIndex + 1) % calibers.Count;
            }
        }
        return idx;
    }

    void SetButtonsInteractable(bool v)
    {
        if (higherButton != null) higherButton.interactable = v;
        if (lowerButton != null) lowerButton.interactable = v;
    }
}
