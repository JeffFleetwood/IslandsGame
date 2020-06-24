using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public VideoPlayer player;
    public GameObject credits;
    public UnityEvent videoEnd;
    bool start;

    private void Start()
    {
        player.Play();
    }

    void OnEnable()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1100, 0);
        start = false;
        player.Stop();
        player.Play();
    }

    void Update()
    {
        transform.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
        
        if (player.isPlaying)
        {
            start = true;
        }

        if (!player.isPlaying && start)
        {
            videoEnd?.Invoke();
        }
    }
}
