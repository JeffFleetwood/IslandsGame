using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    [Tooltip("used to add a delay of when a image will be faded in or out")]
    public float fadeDelay;
    [Range(0, .1f)]
    public float fadeInRate;
    [Range(0, .1f)]
    public float fadeOutRate;
    public Image image;
    public Sprite[] logoImages;

    private int num;

    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(1, 1, 1, 0);
        num = 0;
        StartCoroutine(ChangeImage());
    }

    private IEnumerator ChangeImage()
    {
        yield return null;
        image.sprite = logoImages[num];
        num++;

        if (num > logoImages.Length - 1)
        {
            num = 0;
        }

        StartCoroutine(ImageFadeIn());
    }

    private IEnumerator ImageFadeIn()
    {
        yield return new WaitForSeconds(fadeDelay);

        for (float i = 0; i < 1.2; i += fadeInRate)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

        StartCoroutine(ImageFadeOut());
    }

    private IEnumerator ImageFadeOut()
    {
        yield return new WaitForSeconds(fadeDelay);

        for (float i = 1; i > -.2; i -= fadeOutRate)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

        StartCoroutine(ChangeImage());
    }
}
