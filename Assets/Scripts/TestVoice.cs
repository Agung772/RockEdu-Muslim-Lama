using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class TestVoice : MonoBehaviour
{
    public KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private void Start()
    {
        keywordActions.Add("one", Command);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecongnized;
        keywordRecognizer.Start();

    }

    void OnKeywordsRecongnized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword : " + args.text);
        keywordActions[args.text].Invoke();
    }

    public void Command()
    {
        print("One");
    }
}
