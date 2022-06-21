using System;
using UnityEngine;

namespace Example.Scripts.Brokers
{
    public class Effects_Broker
    {
        // Delegates

        // plays hit effect on the passed position
        public static event Action<Vector3> onPlayHitFx;
        public static event Action<Vector3> onPlayRestoreFx;


        // Invokers
        public static void PlayHitEffect(Vector3 pos)
        {
            onPlayHitFx?.Invoke(pos);
        }

        public static void PlayRestoreEffect(Vector3 pos)
        {
            onPlayRestoreFx?.Invoke(pos);
        }
    }
}