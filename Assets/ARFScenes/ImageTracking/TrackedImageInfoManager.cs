using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

/// This component listens for images detected by the <c>XRImageTrackingSubsystem</c>
/// and overlays some information as well as the source Texture2D on top of the
/// detected image.
/// </summary>
[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoManager : MonoBehaviour
{

    [SerializeField]
    private GameObject ARObjectToPlace;

    //[SerializeField]
    //private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    public Animator anim;


    [SerializeField]
    [Tooltip("The camera to set on the world space UI canvas for each instantiated image info.")]
    Camera m_WorldSpaceCanvasCamera;

    /// <summary>
    /// The prefab has a world space UI canvas,
    /// which requires a camera to function properly.
    /// </summary>
    public Camera worldSpaceCanvasCamera
    {
        get { return m_WorldSpaceCanvasCamera; }
        set { m_WorldSpaceCanvasCamera = value; }
    }

    private SmoothLookAtCamera LookScript;

    [SerializeField]
    [Tooltip("If an image is detected but no source texture can be found, this texture is used instead.")]
    Texture2D m_DefaultTexture;

    /// <summary>
    /// If an image is detected but no source texture can be found,
    /// this texture is used instead.
    /// </summary>
    public Texture2D defaultTexture
    {
        get { return m_DefaultTexture; }
        set { m_DefaultTexture = value; }
    }

    ARTrackedImageManager m_TrackedImageManager;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        LookScript.StartPositions();
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        LookScript.StartPositions();
    }

    void UpdateInfo(ARTrackedImage trackedImage)
    {
        
        //cache the Animator component
        //var animate = trackedImage.GetComponentInChildren<Animator>();
        
        anim = trackedImage.GetComponentInChildren<Animator>();
        LookScript = trackedImage.GetComponentInChildren<SmoothLookAtCamera>();

     



        // Disable the visual plane if it is not being tracked
        if (trackedImage.trackingState == TrackingState.Tracking)
        {

          
            LookScript.TargetTransform = worldSpaceCanvasCamera.transform;
           
            trackedImage.gameObject.SetActive(true);


            //PlaceGameObject(trackedImage.transform.position);


            // The image extents is only valid when the image is being tracked
            // the images x and y scale are changed, but z is not
            //trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1.0f, trackedImage.size.y);

            // Set the texture of the plane to the reference image's texture
            // var material = planeGo.GetComponentInChildren<MeshRenderer>().material;
            // material.mainTexture = (trackedImage.referenceImage.texture == null) ? defaultTexture : trackedImage.referenceImage.texture;
            //animate.SetBool("TweenForward", true);
            
            anim.SetTrigger("ComeForward");
        }
        else
        {
            trackedImage.gameObject.SetActive(false);
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
           //trackedImage.transform.localScale = new Vector3(1.0f , 1.0f, 1.0f);

            UpdateInfo(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
            UpdateInfo(trackedImage);
    }

}

