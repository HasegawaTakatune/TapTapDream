using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int MAX_LENGTH = 20;

    [SerializeField] private GameObject content = default;
    [SerializeField] private GameObject prefab = default;

    private List<TapPanel> tapPanels = new List<TapPanel>();
    [SerializeField] private int[] random = { 0 };
    private int index = 0;

    private static float _score;
    public static float Score { get { return _score; } set { _score = value; } }

    [SerializeField] private static List<Character> Enemies = new List<Character>();
    private static int selectEnemy = 0;

    private float _seconds = 1;
    private int _bpm;
    public int BPM { set { _bpm = value; _seconds = (60 / (float)_bpm); } }

    private void Start()
    {       
        Score = 0;

        BPM = 120;

        AddTapPanel(1);

        StartCoroutine(GameLoop());
    }

    private void AddTapPanel(int value)
    {
        if (MAX_LENGTH < value) value = MAX_LENGTH;

        for (int i = tapPanels.Count; i < value; i++)
        {
            TapPanel obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, content.transform).GetComponent<TapPanel>();
            tapPanels.Add(obj);
        }
        InitRandomArray();
    }

    private void InitRandomArray()
    {
        random = new int[tapPanels.Count];

        for (int i = 0; i < random.Length; i++)
            random[i] = i;

        random = random.Shuffle().ToArray();
    }

    private IEnumerator GameLoop()
    {
        float startFrame = Time.time;
        while (true)
        {
            yield return new WaitForSeconds(_seconds);

            tapPanels[random[index]].Active();
            index++;
            if (random.Length - 1 < index)
            {
                random = random.Shuffle().ToArray();
                index = 0;
            }
        }
    }

    public static void Tap()
    {

    }
}

public static class IEnumerableExtension
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(i => Guid.NewGuid());
    }
}
