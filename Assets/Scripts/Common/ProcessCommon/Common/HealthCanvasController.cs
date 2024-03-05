using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TT
{
    public class HealthCanvasController : HealthController
    {
        [SerializeField] protected Image healthProcess;
        [SerializeField] protected TextMeshProUGUI healthText;

        private void Awake()
        {
            healthProcess = GetComponent<Image>();
        }

        protected override void Display()
        {
            healthProcess.fillAmount = currentValue / maxValue;
            if(healthText != null)
            {
                healthText.text = currentValue.ToString() + " / " + maxValue.ToString();
            }
        }
    }
}