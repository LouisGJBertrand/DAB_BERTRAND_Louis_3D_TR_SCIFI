using UnityEngine;
using UnityEngine.UI;

public class CaptionController : MonoBehaviour
{

    /// <summary>
    /// The caption ui object to be used
    /// </summary>
    public Text CaptionUIObject;
    
    /// <summary>
    /// String actually Displayed (null for not shown)
    /// </summary>
    public string ReadOnlyActualTextDisplayed = "";
    private string DisplayedString = "";

    /// <summary>
    /// String actually Displayed (null for not shown)
    /// </summary>
    public Color ReadOnlyActualTextDisplayedColor = Color.yellow;
    private Color DisplayedStringColor = Color.yellow;

    /// <summary>
    /// Time left in seconds
    /// </summary>
    public float ReadOnlyCaptionTimeLeft;
    private float CaptionDisplayTimeLeft = 0;

    public bool ReadOnlyShouldDisplayCaption;
    private bool DisplayCaption = false;

    /// <summary>
    /// The audio source that will read the audio clip given when starting the caption caption
    /// </summary>
    public AudioSource AudioSource;
    public float AudioSourceVolume;

    public void ClearCaption()
    {
        DisplayedString = "";
        DisplayCaption = false;
        CaptionDisplayTimeLeft = 0;
        AudioSource.Stop();
        CaptionUIObject.color = DisplayedStringColor;
        CaptionUIObject.text = DisplayedString;
    }


    public void ShowCaption(string CaptionText, Color CaptionColor, float Duration, TextAnchor textAlignment, AudioClip CaptionAudioClip = null)
    {

        ClearCaption();

        DisplayedString = CaptionText;
        DisplayedStringColor = CaptionColor;
        DisplayCaption = true;
        CaptionUIObject.alignment = textAlignment;
        CaptionDisplayTimeLeft = CaptionAudioClip != null ? CaptionAudioClip.length + 0.5f : Duration;

        if(CaptionAudioClip != null)
        {
            AudioSource.PlayOneShot(CaptionAudioClip, AudioSourceVolume);
        }

    }

    public void Update()
    {
        
        CaptionDisplayTimeLeft -= Time.deltaTime;

        if(CaptionDisplayTimeLeft < 0)
        {
            CaptionDisplayTimeLeft = 0;
            ClearCaption();
        }

        if(DisplayCaption)
        {

            CaptionUIObject.color = DisplayedStringColor;
            CaptionUIObject.text = DisplayedString;

        }

        ReadOnlyActualTextDisplayed = DisplayedString;
        ReadOnlyActualTextDisplayedColor = DisplayedStringColor;
        ReadOnlyCaptionTimeLeft = CaptionDisplayTimeLeft;
        ReadOnlyShouldDisplayCaption = DisplayCaption;

    }

}