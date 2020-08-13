using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuItems : MonoBehaviour
    {
        GameObject SelectMap = default;
        GameObject Status = default;
        GameObject Configuration = default;
        GameObject ReturnButton = default;

        private void Start()
        {
            Transform Cnvs = transform.Find("Canvas");

            SelectMap = Cnvs.Find("SelectMap").gameObject;
            Status = Cnvs.Find("Status").gameObject;
            Configuration = Cnvs.Find("Configuration").gameObject;
            ReturnButton = Cnvs.Find("ReturnButton").gameObject;

            Button storyBtn = Cnvs.Find("StoryButton").GetComponent<Button>();
            storyBtn.onClick.AddListener(OnClickStoryButton);

            Button statusBtn = Cnvs.Find("StatusButton").GetComponent<Button>();
            statusBtn.onClick.AddListener(OnClickStatusButton);

            Button configBtn = Cnvs.Find("ConfigButton").GetComponent<Button>();
            configBtn.onClick.AddListener(OnClickConfigButton);

            Button returnBtn = ReturnButton.GetComponent<Button>();
            returnBtn.onClick.AddListener(OnClickReturnButton);
        }

        public void OnClickStoryButton()
        {
            SelectMap.SetActive(true);
            ReturnButton.SetActive(true);
        }

        public void OnClickStatusButton()
        {
            Status.SetActive(true);
            ReturnButton.SetActive(true);
        }

        public void OnClickConfigButton()
        {
            bool flg = Configuration.activeSelf;
            Configuration.SetActive(!flg);
        }

        public void OnClickReturnButton()
        {
            SelectMap.SetActive(false);
            Status.SetActive(false);
            ReturnButton.SetActive(false);
        }
    }
}