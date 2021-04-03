using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : Listner
{

    public CaptionController CaptionController;

    public CameraFade CameraFader;

    public AudioSource AmbiantAudioSource;

    public bool IsTransitioning;
    public int ActualCaptionLine = 0;
    public float TimePassed = 0;

    public override void OnGameObjectEvent(object sender, GameBojectEventArgs e)
    {

        IsTransitioning = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsTransitioning)
            return;

        TimePassed += Time.deltaTime;

        if (ActualCaptionLine == 0 && TimePassed > 0)
        {
            CaptionController.ShowCaption("- You : \"I've arrived at the ship...", Color.white, 5, TextAnchor.MiddleLeft);
            ActualCaptionLine++;

        }

        if (ActualCaptionLine == 1 && TimePassed > 6)
        {
            CameraFader.speedScale = 0.2f;
            CameraFader.FadeOut();
            ActualCaptionLine++;
        }

        if( TimePassed > 6)
        {
            AmbiantAudioSource.volume -= Time.deltaTime/8f;
        }

        if( TimePassed >= 12)
            SceneManager.LoadScene("SC_EscapeCutscene");
    }
}
