using Example.Scripts.Brokers;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts.Controllers
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] Slider slider;

        private void Start()
        {
            slider ??= GetComponent<Slider>();
        }

        private void OnEnable()
        {
            Health_Broker.onAddHealth += HealthUpdate;
            Health_Broker.onRemoveHealth += HealthUpdate;
        }

        private void OnDisable()
        {
            Health_Broker.onAddHealth -= HealthUpdate;
            Health_Broker.onRemoveHealth -= HealthUpdate;
        }

        private void HealthUpdate(float val)
        {
            slider.value += val;
            if (slider.value <= 0)
            {
                slider.value = 0;
            }
        }
    }
}