using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteractions : MonoBehaviour
{
    //public VideoPlayer VideoPlayer;
    //public ParticleSystem VideoParticle;

    public static bool Beenclicked = false;
    public static bool HeadphonesClicked = false;
    private string ColTag;
    private GameObject VideoPrefab;


    AudioSource m_MyAudioSource;
    private Animator HeadphonesAnimator;
    private VideoController VideoController;

    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                // Lots of repetition, but CompareTag is more efficint than a switch case
                if (raycastHit.collider.CompareTag("Letter C"))
                    // official trailer
                    Application.OpenURL("https://youtu.be/3e13UftVEeo");

                if (raycastHit.collider.CompareTag("Letter O"))
                    Application.OpenURL("https://comefromawaylondon.co.uk/tickets/");

                if (raycastHit.collider.CompareTag("Letter M"))
                    // opening song from oliver awards
                    Application.OpenURL("https://youtu.be/WcI1EKE01S0?t=39");

                if (raycastHit.collider.CompareTag("Letter E"))
                    // uk trailer
                    Application.OpenURL("https://youtu.be/gl23ncmmbiI");

                if (raycastHit.collider.CompareTag("Globe"))
                {
                    if (!Beenclicked)
                    {
                        Beenclicked = true;
                        StartCoroutine("Cooldown", 1.0f);
                        VideoController = raycastHit.collider.GetComponent<VideoController>();
                        VideoController.Activate();
                    }
                }

                if (raycastHit.collider.CompareTag("Letter F"))
                {
                    Application.OpenURL("https://www.instagram.com/ComeFromAwayUK/");
                    //TODO launch  share 
                }

                if (raycastHit.collider.CompareTag("Letter R"))
                {
                    Application.OpenURL("https://comefromawaylondon.co.uk/");
                    //TODO launch  share 
                }

                if (raycastHit.collider.CompareTag("Letter A"))
                {
                    Application.OpenURL("https://comefromawaylondon.co.uk/tickets/");
                    //TODO launch  share 
                }

                if (raycastHit.collider.CompareTag("Letter W"))
                {
                    Application.OpenURL("https://youtu.be/_wmcCqAa-AY");
                    //TODO launch  share 
                }

                if (raycastHit.collider.CompareTag("Letter Y"))
                {
                    Application.OpenURL("https://comefromawaylondon.tmstor.es/");
                    //TODO launch  share 
                }


            }

        }
    }


    IEnumerator Cooldown(float delay)
    {


        yield return new WaitForSeconds(delay);
        Beenclicked = false;
        //HeadphonesClicked = false;
    }
}

//if (raycastHit.collider.CompareTag("Headphones"))
//{
//    //HeadphonesAnimator = raycastHit.collider.GetComponent<Animator>();

//    if (HeadphonesClicked)
//    {
//        m_MyAudioSource.Stop();
//        StartCoroutine("Cooldown", 0.5f);
//        HeadphonesAnimator.SetBool("HeadphonesPressed", false);

//    }
//    if (!HeadphonesClicked)
//    {
//        HeadphonesAnimator = raycastHit.collider.GetComponent<Animator>();
//        HeadphonesAnimator.SetBool("HeadphonesPressed", true);
//        m_MyAudioSource.Play();
//        HeadphonesClicked = true;


//    }

