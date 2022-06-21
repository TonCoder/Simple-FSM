using System;

namespace Example.Scripts.Brokers
{
    public class Health_Broker
    {
        // Delegates
        public static event Action<float> onAddHealth;

        public static event Action<float> onRemoveHealth;

        // Invokers
        public static void AddHealth(float val)
        {
            onAddHealth?.Invoke(val);
        }

        public static void RemoveHealth(float val)
        {
            onRemoveHealth?.Invoke(val);
        }
    }
}