using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UITween.Internal
{
    public class SpringEffect : ITweenEffect
    {
        RectTransform transform;
        Vector3 initialPosition;
        Vector3 targetPosition;
        float duration;
        float timeElapsed;
        AnimationCurve springCurve;

        public SpringEffect(RectTransform transform, Vector3 targetPosition, float duration, AnimationCurve springCurve)
        {
            this.transform = transform;
            this.initialPosition = transform.localPosition;
            this.targetPosition = targetPosition;
            this.duration = duration;
            this.springCurve = springCurve ?? AnimationCurve.EaseInOut(0, 0, 1, 1);
        }

        public bool DoTween(float deltaTime)
        {
            if (timeElapsed < duration)
            {
                float progress = timeElapsed / duration;
                float curveValue = springCurve.Evaluate(progress);
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
