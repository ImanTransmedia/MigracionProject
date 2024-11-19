using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class WebVideo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private string videoFileName;
    void Start()
    {
        PlayWebVideo();
    }

    public void PlayWebVideo()
    {
        VideoPlayer VP = GetComponent<VideoPlayer>();

        if (VP)
        {
            string VPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(VPath);
            VP.url = VPath;
            //VP.url = videoFileName;
            VP.Play();

        }
    }
}
