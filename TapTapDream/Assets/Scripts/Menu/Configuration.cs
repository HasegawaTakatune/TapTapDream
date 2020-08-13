using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class Configuration : MonoBehaviour
    {
        private GameObject ConfigPanel = default;
        private GameObject CreditPanel = default;

        private Slider AudioSlider = default;
        private Slider SESlider = default;

        void Start()
        {
            ConfigPanel = transform.Find("ConfigPanel").gameObject;
            CreditPanel = transform.Find("CreditPanel").gameObject;

            Button backgroundBtn = GameObject.Find("Background").GetComponent<Button>();
            backgroundBtn.onClick.AddListener(OnClickBackgroundPanel);

            Transform trns = transform.Find("ConfigPanel");
            AudioSlider = trns.Find("AudioSlider").GetComponent<Slider>();
            SESlider = trns.Find("SESlider").GetComponent<Slider>();

            Button CreditBtn = trns.Find("CreditButton").GetComponent<Button>();
            CreditBtn.onClick.AddListener(OnClickCreditButton);

            Button ReturnBtn = transform.Find("CreditPanel").Find("ReturnButton").GetComponent<Button>();
            ReturnBtn.onClick.AddListener(OnClickReturnButton);

            Button CloseBtn = transform.Find("CloseButton").GetComponent<Button>();
            CloseBtn.onClick.AddListener(OnClickCloseButton);
        }

        public void OnClickBackgroundPanel()
        {
            ConfigPanel.SetActive(true);
            CreditPanel.SetActive(false);
            gameObject.SetActive(false);
        }

        public void OnClickCreditButton()
        {
            ConfigPanel.SetActive(false);
            CreditPanel.SetActive(true);
        }

        public void OnClickReturnButton()
        {
            ConfigPanel.SetActive(true);
            CreditPanel.SetActive(false);
        }

        public void OnClickCloseButton()
        {
            ConfigPanel.SetActive(true);
            CreditPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}