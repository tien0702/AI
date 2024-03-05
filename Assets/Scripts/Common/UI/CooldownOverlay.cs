using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TT;
using System;

public class CooldownOverlay : BaseProcessCanvasController
{
    public Action onComplete;
    [SerializeField] TextMeshProUGUI _cooldownTxt;

    public override float CurrentValue { get => base.CurrentValue;
        set {
            base.CurrentValue = value;
            OnChangeValue(CurrentValue);
        } 
    }

    protected override void Awake()
    {
        base.Awake();
        _fill = GetComponent<Image>();
        _cooldownTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    protected override void OnChangeValue(float value)
    {
        if(value <= 0 && onComplete != null)
        {
            onComplete();
        }
        Display();
    }

    private void Update()
    {
        if(CurrentValue > 0) CurrentValue -= Time.deltaTime;
    }

    protected override void Display()
    {
        base.Display();
        _cooldownTxt.text = (CurrentValue / MaxValue).ToString("0.00");
    }
}
