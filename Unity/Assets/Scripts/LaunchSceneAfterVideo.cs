using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LaunchSceneAfterVideo : MonoBehaviour
{
    public Scene SceneName;
    private VideoPlayer Video;

    private void Start()
    {
        Video = GetComponent<VideoPlayer>();
        Video.loopPointReached += LoadScene;
    }

    private void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}