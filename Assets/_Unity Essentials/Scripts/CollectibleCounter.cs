using UnityEngine;
using TMPro;

public class CollectibleCounter : MonoBehaviour
{

    public int totalCollectibles = 5;   // set this to 5 in the Inspector
    private int collectedCount = 0;

    private TextMeshProUGUI counterText;

    // Drag your confetti prefab here in the Inspector
    [Header("Win Effects")]
    public ParticleSystem confettiInScene;   // drag the confetti PREFAB here
    public AudioClip winSound;          // drag the audio file here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterText = GetComponentInChildren<TextMeshProUGUI>();
        PrepareConfetti();
        UpdateCounterText();
    }

    void PrepareConfetti()
    {
        if (confettiInScene == null) return;

        foreach (ParticleSystem ps in confettiInScene.GetComponentsInChildren<ParticleSystem>())
        {
            var main = ps.main;
            main.playOnAwake = false;
            main.loop = false;
            main.stopAction = ParticleSystemStopAction.None;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    public void CollectItem(Vector3 playerPosition)
    {
        collectedCount++;
        UpdateCounterText();

        if (collectedCount >= totalCollectibles)
        {
            Win(playerPosition);
        }
    }

    void UpdateCounterText()
    {
        int remaining = totalCollectibles - collectedCount;
        counterText.text = "Hearts remaining: " + remaining;
    }

    void Win(Vector3 pos)
    {
        counterText.text = "You win!";

        if (confettiInScene != null)
        {
            confettiInScene.transform.position = pos;
            confettiInScene.Play(true);
        }

        if (winSound != null)
        {
            AudioSource.PlayClipAtPoint(winSound, pos, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
