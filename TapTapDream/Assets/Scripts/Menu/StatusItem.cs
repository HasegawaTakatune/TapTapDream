using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusItem : MonoBehaviour
{
    private int maxParam = 20;

    private Text paramText = default;

    private int param = 0;

    [SerializeField] private string label;

    public void Init(int param, int maxParam)
    {
        this.param = param;
        this.maxParam = maxParam;
    }

    private void Start()
    {
        Text labelTxt = transform.Find("ParamPanel").Find("Label").GetComponent<Text>();
        labelTxt.text = label;

        paramText = transform.Find("ParamPanel").Find("Param").GetComponent<Text>();

        Button addBtn = transform.Find("AddButton").GetComponent<Button>();
        Button subBtn = transform.Find("SubButton").GetComponent<Button>();

        addBtn.onClick.AddListener(OnClickAddParamButton);
        subBtn.onClick.AddListener(OnClickSubParamButton);
    }

    public void OnClickAddParamButton()
    {
        if (param < maxParam)
            param++;

        paramText.text = param.ToString();
    }

    public void OnClickSubParamButton()
    {
        if (0 < param)
            param--;

        paramText.text = param.ToString();
    }

    public int GetParam() { return param; }
}
