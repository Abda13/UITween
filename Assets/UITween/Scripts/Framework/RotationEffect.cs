using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UITween.Internal
{
    public class RotationEffect : ITweenEffect
    {
        RectTransform transform;
        float duration;
        float timeElapsed;
        Quaternion initialRotation;
        Quaternion targetRotation;

        Space space;
        bool isSlerp;

        public RotationEffect(RectTransform transform, Quaternion targetRotation, float duration,Space space , bool isSlerp)
        {
            this.transform = transform;
            this.duration = duration;
            this.targetRotation = targetRotation;
            initialRotation = transform.localRotation;

            this.space = space;
            initialRotation = space == Space.Self ? transform.localRotation : transform.rotation;

            this.isSlerp = isSlerp;
        }

        public bool DoTween(float deltaTime)
        {
            if (timeElapsed < duration)
            {
                Quaternion rot;

                rot = isSlerp ? Quaternion.Slerp(initialRotation, targetRotation, timeElapsed / duration): Quaternion.Lerp(initialRotation, targetRotation, timeElapsed / duration);

                if (space == Space.Self)
                {
                    transform.localRotation = rot;
                }
                else
                {
                    transform.rotation = rot;
                }

                timeElapsed += deltaTime;
                return false;
            }
            else
            {
                if (space == Space.Self)
                {
                    transform.localRotation = targetRotation;
                }
                else
                {
                    transform.rotation = targetRotation;
                }
                return true;
            }
        }
    }
}
