using System;
using MyrddinsOwl.Core;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : ValidatedMonoBehaviour
{
    [SerializeField] private Button _play;

    public event Action PlayClicked;
    
    protected override void Awake()
    {             
        base.Awake();
        
        SubscribeListeners();
    }

    private void SubscribeListeners()
    {
        _play.onClick.AddListener(OnPlayClicked);
    }

    private void OnPlayClicked()
    {
        PlayClicked?.Invoke();
    }
}
