using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class ShowIcons : MonoBehaviour
    {
        private const float FADE_TIME = 3.0f;
        private const float SHOW_TIME = 1.0f;

        [SerializeField] private Image CompanyIcon = default;
        [SerializeField] private Image AppIcon = default;

        [SerializeField] private GameObject NextObj = default;

        private IEnumerator Start()
        {
            yield return StartCoroutine(Fade(CompanyIcon));

            yield return StartCoroutine(Fade(AppIcon));

            gameObject.SetActive(false);
            NextObj.SetActive(true);
        }

        private IEnumerator Fade(Image icon)
        {
            float alpha = 0;
            float timer = Time.deltaTime / FADE_TIME;

            while (alpha <= 1)
            {
                yield return new WaitForSeconds(timer);
                alpha += timer;
                icon.color = new Color(1, 1, 1, alpha);
            }

            yield return new WaitForSeconds(SHOW_TIME);

            while (0 < alpha)
            {
                yield return new WaitForSeconds(timer);
                alpha -= timer;
                icon.color = new Color(1, 1, 1, alpha);
            }
        }
    }
}