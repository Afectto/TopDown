using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour, IListener
{
    [SerializeField] private Button button;

    public static Action OnClickShootButtonAction;

    public void Start()
    {
        AddAllListeners();
    }

    public void AddAllListeners()
    {
        button.onClick.AddListener(OnClickShootButton);
    }

    public void RemoveAllListeners()
    {
        button.onClick.RemoveListener(OnClickShootButton);
    }

    private void OnClickShootButton()
    {
        OnClickShootButtonAction?.Invoke();
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
