using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image FadeImage;
    public Text FadeText;
    private float FadeAlpha = 1f;

    private AudioSource BackGroundSourse;

    void Start()
    {
        BackGroundSourse = GetComponent<AudioSource>();
        FadeImage.gameObject.SetActive(true);
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (FadeAlpha >= 0f)
        {
            FadeAlpha -= 0.01f;

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, FadeAlpha);
            FadeText.color = new Color(FadeText.color.r, FadeText.color.g, FadeText.color.b, FadeAlpha);

            yield return new WaitForSeconds(0.02f);
        }

        BackGroundSourse.Play();
    }
}

