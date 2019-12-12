using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private bool playing;

    public GameObject VideoObject;
    public VideoPlayer vp;

    public void Activate()
    {
        if (playing)
        {
            vp.Stop();
            VideoObject.SetActive(false);
            playing = false;
            // stop playing 
        } else
        {
            VideoObject.SetActive(true);//TODO  activate and play video texture in scene - set layer sorting to play video infront of everything 
            vp.Play();
            playing = true;
        }
        
    } 
}
