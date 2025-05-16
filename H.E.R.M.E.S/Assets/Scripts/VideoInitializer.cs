using UnityEngine;
using UnityEngine.Video;

public class VideoInitializer : MonoBehaviour
{
    public RenderTexture videoTexture;

    void Start()
    {
        var player = gameObject.AddComponent<VideoPlayer>();
        player.source = VideoSource.Url;
        player.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Block in 10001-2450.mp4");
        player.renderMode = VideoRenderMode.RenderTexture;
        player.targetTexture = videoTexture;
        player.playOnAwake = true;
        player.isLooping = false;
        player.audioOutputMode = VideoAudioOutputMode.AudioSource;

        player.Play();
    }
}
