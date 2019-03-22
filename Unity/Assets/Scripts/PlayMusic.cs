using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<PlayMusic>().PlayMus();
    }

    public void PlayMus()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMus()
    {
        _audioSource.Stop();
    }
}