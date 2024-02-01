using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UITween.Internal
{
    public class BounceEffect : ITweenEffect
    {
        RectTransform transform;
        Vector3 initialPosition;
        Vector3 targetPosition;
        float duration;
        float timeElapsed;
        AnimationCurve bounceCurve;

        public BounceEffect(RectTransform transform, Vector3 targetPosition, float duration, AnimationCurve bounceCurve)
        {
            this.transform = transform;
            this.initialPosition = transform.localPosition;
            this.targetPosition = targetPosition;
            this.duration = duration;
            this.bounceCurve = bounceCurve ?? AnimationCurve.EaseInOut(0.1f, 0.1f, 1f, 1f);
        }

        public bool DoTween(float deltaTime)
        {
            if (timeElapsed < duration)
            {
                float progress = timeElapsed / duration;
                float curveValue = bounceCurve.Evaluate(progress);
                Vector3 currentPosition = Vector3.LerpUnclamped(initialPosition, targetPosition, curveValue);

                transform.localPosition = currentPosition;
                timeElapsed += deltaTime;
                return false;
            }
            else
            {
                transform.localPosition = targetPosition;
                return true;
            }
        }
    }
}
