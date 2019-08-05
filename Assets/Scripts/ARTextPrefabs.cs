using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ARTextPrefabs : MonoBehaviour
{
    /// <summary>
    /// The first-person camera being used to render the passthrough camera image (i.e. AR
    /// background).
    /// </summary>
    public Camera FirstPersonCamera;


    public GameObject Textcube;

    /// <summary>
    /// A prefab for tracking and visualizing detected planes.
    /// </summary>
   // public GameObject DetectedPlanePrefab;

    /// <summary>
    /// A model to place when a raycast from a user touch hits a plane.
    /// </summary>
    public GameObject AndyPlanePrefab;

    /// <summary>
    /// A model to place when a raycast from a user touch hits a feature point.
    /// </summary>
    public GameObject AndyPointPrefab;

    /// <summary>
    /// The rotation in degrees need to apply to model when the Andy model is placed.
    /// </summary>
    private const float k_ModelRotation = 180.0f;

    /// <summary>
    /// True if the app is in the process of quitting due to an ARCore connection error,
    /// otherwise false.
    /// </summary>
    private bool m_IsQuitting = false;

    private int id = 0;

    /// <summary>
    /// The Unity Update() method.
    /// </summary>
    public void Update()
    {
       // _UpdateApplicationLifecycle();

        // If the player has not touched the screen, we are done with this update.
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Should not handle input if the player is pointing on UI.
        //if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //{
        //    return;
        //}

        // Raycast against the location the player touched to search for planes.
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if (false )
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            //if ((hit.Trackable is DetectedPlane) &&
            //    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
            //        hit.Pose.rotation * Vector3.up) < 0)
            //{
            //    Debug.Log("Hit at back of the current DetectedPlane");
            //}
            else
            {
                GameObject prefab;
                if (Input.touchCount > 1)
                {
                    if (Input.touchCount == 2)
                    {
                        prefab = AndyPointPrefab;
                    }
                    else
                    {
                        prefab = AndyPlanePrefab;
                    }

                    //为被击中的跟踪设备选择Andy型号。

                    //if (hit.Trackable is FeaturePoint)
                    //{

                    //}
                    //else
                    //{
                    //    prefab = AndyPlanePrefab;
                    //}
                    //位置
                    var andyObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                    //补偿背向光线投射的Hitpose旋转（即旋转180 摄像机）。
                    andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                    //创建一个锚，允许arcore跟踪作为理解
                    andyObject.name = prefab.name + id;
                    id++;

                    //物质世界在进化。
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    //让安迪做锚的孩子。
                    andyObject.transform.parent = Textcube.transform;
                }
            }
        }
    }

    /// <summary>
    /// Check and update the application lifecycle.
    /// </summary>
    private void _UpdateApplicationLifecycle()
    {
        // Exit the app when the 'back' button is pressed.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Only allow the screen to sleep when not tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (m_IsQuitting)
        {
            return;
        }

        // Quit if ARCore was unable to connect and give Unity some time for the toast to
        // appear.
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage(
                "ARCore encountered a problem connecting.  Please start the app again.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
    }

    /// <summary>
    /// Actually quit the application.
    /// </summary>
    private void _DoQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

}
