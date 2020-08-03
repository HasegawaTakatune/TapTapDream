using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject content = default;
    [SerializeField] private GameObject prefab = default;

    private const int MAX_LENGTH = 20;

    private List<TapPanel> tapPanels = new List<TapPanel>();
    [SerializeField]private int[] random = { 0 };
    private int index;

    private static float _score;
    public static float Score { get { return _score; } set { _score = value; ScoreText.text = "Score " + _score; } }
    private static Text ScoreText;

    private float _seconds = 1;
    private int _bpm;
    public int BPM { set { _bpm = value; _seconds = (60 / (float)_bpm); } }

    private void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Score = 0;

        BPM = 120;

        StartCoroutine(GameLoop());
    }

    private void AddTapPanel()
    {
        if (tapPanels.Count < MAX_LENGTH)
        {
            TapPanel obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, content.transform).GetComponent<TapPanel>();
            tapPanels.Add(obj);

            InitRandomArray();
        }
    }

    private void InitRandomArray()
    {
        random = new int[tapPanels.Count];

        for (int i = 0; i < random.Length; i++)
            random[i] = i;

        random = random.Shuffle().ToArray();
    }   

    IEnumerator GameLoop()
    {
        var startFrame = Time.time;
        while (true)
        {
            yield return new WaitForSeconds(_seconds);
            AddTapPanel();
        }
    }
}

public static class IEnumerableExtension
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(i => Guid.NewGuid());
    }
}
