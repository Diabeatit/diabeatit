using UnityEngine;

namespace HardCodeLab.TutorialMaster
{
    [HelpURL("https://support.hardcodelab.com/tutorial-master/2.0/floating-effect")]
    public class FloatEffect : Effect<FloatEffectSettings>
    {
        /// <summary>
        /// The default position of this Module before this effect occured.
        /// </summary>
        private Vector2 _defaultPosition;

        protected override void Awake()
        {
            base.Awake();
            _defaultPosition = RectTransform.anchoredPosition;
        }

        protected override void OnUpdate()
        {
            if (TargetModule.UpdateEveryFrame)
                _defaultPosition = RectTransform.anchoredPosition;

            float diff = CalculateDiff();
            Vector2 newPos = new Vector2();

            switch (EffectSettings.Direction)
            {
                case Orientation.Horizontal:

                    newPos = new Vector2(
                        _defaultPosition.x - diff,
                        _defaultPosition.y
                    );

                    break;

                case Orientation.Vertical:

                    newPos = new Vector2(
                        _defaultPosition.x,
                        _defaultPosition.y - diff
                    );

                    break;

                case Orientation.DiagonalLeft:

                    newPos = new Vector2(
                        _defaultPosition.x - diff,
                        _defaultPosition.y + diff
                    );

                    break;

                case Orientation.DiagonalRight:

                    newPos = new Vector2(
                        _defaultPosition.x - diff,
                        _defaultPosition.y - diff
                    );

                    break;
            }

            RectTransform.anchoredPosition = newPos;
        }

        /// <summary>
        /// Calculates the current position of the module.
        /// </summary>
        /// <returns></returns>
        private float CalculateDiff()
        {
            if (EffectSettings == null) return 0;

            float diff = 0;

            switch (EffectSettings.FloatPattern)
            {
                case WaveType.Sine:

                    diff = (Mathf.Sin(Time.time * EffectSettings.Speed) * EffectSettings.FloatRange - EffectSettings.FloatRange) / 2;

                    break;

                case WaveType.Square:

                    diff = (Mathf.Sign(Mathf.Sin(Time.time * EffectSettings.Speed)) * EffectSettings.FloatRange - EffectSettings.FloatRange) / 2;

                    break;

                case WaveType.Triangle:

                    diff = (Mathf.Abs((Time.time * EffectSettings.Speed % 6) - 3) * EffectSettings.FloatRange - EffectSettings.FloatRange) / 2;

                    break;

                case WaveType.Custom:

                    diff = (EffectSettings.CustomPattern.Evaluate(Time.time * EffectSettings.Speed) * EffectSettings.FloatRange - EffectSettings.FloatRange) / 2;

                    break;
            }

            return diff;
        }
    }
}