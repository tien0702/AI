using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickButton : JoystickController
{
    [SerializeField] Image _avatar;
    [SerializeField] CooldownOverlay _cooldownOverlay;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        joystick.gameObject.SetActive(true);
        base.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        joystick.gameObject.SetActive(false);
        base.OnEndDrag(eventData);
    }
}
