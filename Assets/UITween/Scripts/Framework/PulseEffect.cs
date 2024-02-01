using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UITween.Internal
{
    public class PulseEffect : ITweenEffect
    {
        RectTransform transform;
        float duration;
        float pulseDuration;
        Vector3 initialScale;
        Vector3 targetScale;
        float timeElapsed;
        float pulseTimeElapsed;
        float speed;

        public PulseEffect(RectTransform transform, Vector3 targetScale, float pulseDuration, float duration,float speed)
        {
            this.transform = transform;
            this.duration = duration;
            this.targetScale = targetScale;
            this.initialScale = transform.localScale;
            this.speed = speed;
            this.pulseDuration = pulseDuration;
        }

        public bool DoTween(float deltaTime)
        {
            if (timeElapsed < duration)
            {
                float progress = (Mathf.Sin(pulseTimeElapsed / pulseDuration * 2* speed * Mathf.PI) + 1) / 2;
                Vector3 currentScale = Vector3.LerpUnclamped(initialScale, targetScale, progress);

                transform.localScale = currentScale;

                pulseTimeElapsed += deltaTime;
                timeElapsed += deltaTime;

                if (pulseTimeElapsed >= pulseDuration)
                {
                    pulseTimeElapsed = 0f;
                }

                return false;
            }
            else
            {
                transform.localScale = initialScale;
                return true;
            }
        }
    }
}
