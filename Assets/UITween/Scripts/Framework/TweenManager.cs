using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UITween.Internal
{
    public class TweenManager : MonoBehaviour
    {
        public static TweenManager instance { get; private set; }


        List<ITweenEffect> Effects = new List<ITweenEffect>();


        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        internal void Move(RectTransform rectTransform, Vector3 targetPosition, float duration, Space space, bool isSlerp)
        {
            Effects.Add(new TranslateEffect(rectTransform, targetPosition, duration,Space.Self, isSlerp));
        }
        internal void Shake(RectTransform rectTransform, float duration, float intensity)
        {
            Effects.Add(new ShakeEffect(rectTransform, duration, intensity));
        }
        internal void Pop(RectTransform rectTransform, Vector3 targetScale, float duration)
        {
            Effects.Add(new PopEffect(rectTransform, targetScale, duration));
        }
        internal void Scale(RectTransform rectTransform, Vector3 targetScale, float duration)
        {
            Effects.Add(new ScaleEffect(rectTransform, targetScale, duration));
        }
        internal void Rotate(RectTransform rectTransform, Quaternion targetRotation, float duration, Space space, bool isSlerp)
        {
            Effects.Add(new RotationEffect(rectTransform, targetRotation, duration, space, isSlerp));
        }
        internal void Bounce(RectTransform rectTransform, Vector3 targetPosition, float duration, AnimationCurve bounceCurve = null)
        {
            Effects.Add(new BounceEffect(rectTransform, targetPosition, duration, bounceCurve));
        } 
        internal void Pulse(RectTransform rectTransform, Vector3 targetScale, float pulseDuration, float duration, float speed)
        {
            Effects.Add(new PulseEffect(rectTransform, targetScale,pulseDuration, duration, speed));
        }
        internal void Spring(RectTransform rectTransform, Vector3 targetPosition, float duration, AnimationCurve springCurve)
        {
            Effects.Add(new SpringEffect(rectTransform, targetPosition, duration, springCurve));
        }

        void Update()
        {
            foreach (var effect in Effects)
            {
                if(effect.DoTween(Time.deltaTime))
                {
                    Effects.Remove(effect);
                    break;
                }
            }
        }

      
    }

    public class DoEffect
    {
        public float duration;

    }
}
