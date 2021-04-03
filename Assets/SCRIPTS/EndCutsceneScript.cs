using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneScript : MonoBehaviour
{

    public CameraFade CameraFader;
    public CaptionController CaptionController;

    public float TimePassed;

    public float CaptionLine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        TimePassed += Time.deltaTime;

        if(TimePassed >= 2 && CaptionLine == 0)
        {

            CameraFader.FadeIn();
            CaptionLine++;
            CaptionController.ShowCaption("Well played, You've successfully escaped the ship...", Color.white, 8, TextAnchor.MiddleCenter);

        }
        if (TimePassed >= 12 && CaptionLine == 1)
        {

            CaptionLine++;
            CaptionController.ShowCaption("After a long trip you arrived at the main Spacio port to report the accident", Color.white, 11, TextAnchor.MiddleCenter);

        }
        if (TimePassed >= 25 && CaptionLine == 2)
        {

            CaptionLine++;
            CaptionController.ShowCaption("You explained that while the rest of the crew was outside for mission,", Color.white, 6, TextAnchor.MiddleCenter);

        }
        if (TimePassed >= 31 && CaptionLine == 3)
        {

            CaptionLine++;
            CaptionController.ShowCaption("one of the propellant failed and caused the ship to become unstable,", Color.white, 6, TextAnchor.MiddleCenter);

        }
        if (TimePassed >= 38 && CaptionLine == 4)
        {

            CaptionLine++;
            CaptionController.ShowCaption("Leaving the crew behind...", Color.white, 4, TextAnchor.MiddleCenter);

        }
        if (TimePassed >= 45 && CaptionLine == 5)
        {
            CaptionLine++;
            CaptionController.ShowCaption("the crew joined you at the spacioport shortly after with their mission pod ships.", Color.white, 16, TextAnchor.MiddleCenter);

        }

        if (TimePassed >= 53 && CaptionLine == 6)
        {
            CaptionLine++;
            CameraFader.FadeOut();

        }

        if (TimePassed >= 62 && CaptionLine == 7)
        {
            CameraFader.FadeIn();
            CaptionController.ClearCaption();
            CaptionController.ShowCaption("Thank you for playing.", Color.white, 16, TextAnchor.MiddleCenter);
            CaptionLine++;

        }
        if (TimePassed >= 70 && CaptionLine == 8)
        {

            CaptionLine++;
            CameraFader.FadeOut();

        }

        if (TimePassed >= 76)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("SC_MainMenu");
        }
    }
}
