using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public abstract class BaseProcessCanvasController : BaseProcess
    {
        [SerializeField] protected Image _fill;
        protected virtual void Awake()
        {
            _fill = GetComponent<Image>();
        }

        protected virtual void Display()
        {
            _fill.fillAmount = currentValue / maxValue;
        }
    }
}
