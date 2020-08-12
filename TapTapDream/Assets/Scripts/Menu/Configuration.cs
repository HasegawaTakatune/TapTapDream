using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuration : MonoBehaviour
{
    private GameObject ConfigPanel = default;
    private GameObject CreditPanel = default;

    private Slider AudioSlider = default;
    private Slider SESlider = default;

    void Start()
    {
        Transform trns = transform.Find("ConfigPanel");
        AudioSlider = trns.Find("AudioSlider").GetComponent<Slider>();
        SESlider = trns.Find("SESlider").GetComponent<Slider>();

        Button CreditBtn = trns.Find("CreditButton").GetComponent<Button>();
        CreditBtn.onClick.AddListener(OnClickCreditButton);

        Button ReturnBtn = trns.Find("ReturnButton").GetComponent<Button>();
        ReturnBtn.onClick.AddListener(OnClickReturnButton);

        Button CloseBtn = transform.Find("CloseButton").GetComponent<Button>();
        CloseBtn.onClick.AddListener(OnClickCloseButton);
    }

    void Update()
    {

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
