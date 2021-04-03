using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCaptionListner : Listner
{
    public bool IsSingleActivation = true;
    public string CaptionText = "Lorem Ipsum.";
    public Color CaptionColor = Color.yellow;
    public float CaptionDuration = 5.0f;
    public TextAnchor TextAnchor;

    public CaptionController captionController;

    public AudioClip AudioClip;

    public int PlayedCount;

    public override void OnGameObjectEvent(object sender, GameBojectEventArgs e)
    {
        if (PlayedCount > 0 && IsSingleActivation)
            return;

        PlayedCount++;
        captionController.ShowCaption(CaptionText, CaptionColor, CaptionDuration, TextAnchor, AudioClip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
