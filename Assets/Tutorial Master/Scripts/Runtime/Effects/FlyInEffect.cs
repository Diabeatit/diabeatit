using System;
using UnityEngine;

namespace HardCodeLab.TutorialMaster
{
    public class FlyInEffect : Effect<FlyInEffectSettings>, IEffectOneShot
    {
        /// <summary>
        /// The final position of this module.
        /// </summary>
        private Vector2 _endPosition;

        /// <summary>
        /// The starting position of this module.
        /// </summary>
        private Vector2 _startPosition;

        /// <summary>
        /// Occurs when effect starts.
        /// </summary>
        public event EffectEvent EffectStart;

        /// <summary>
        /// Occurs when effect ends.
        /// </summary>
        public event EffectEvent EffectEnd;

        /// <summary>
        /// Returns true if the effect has finished.
        /// </summary>
        public bool HasFinished { get; set; }

        /// <summary>
        /// Called when effect starts.
        /// </summary>
        public void OnEffectStart()
        {
            HasFinished = false;
            var ev = EffectStart;
            if (ev == null) return;
            ev.Invoke();
        }

        /// <summary>
        /// Called when effect ends.
        /// </summary>
        public void OnEffectEnd()
        {
            HasFinished = true;
            var ev = EffectEnd;
            if (ev == null) return;
            ev.Invoke();
            Debug.Log("Ended");
        }

        /// <summary>
        /// Applies the effect settings for this effect.
        /// </summary>
        /// <param name="settings">The new effect settings.</param>
        public override void SetEffectSettings(FlyInEffectSettings settings)
        {
            base.SetEffectSettings(settings);
            SetStartPosition(EffectSettings.FlyDirection, EffectSettings.FlyDistance);
            OnEffectStart();
        }

        /// <summary>
        /// Called only once.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            _endPosition = RectTransform.anchoredPosition;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (HasFinished)
                return;

            if (TargetModule.UpdateEveryFrame)
            {
                SetStartPosition(EffectSettings.FlyDirection, EffectSettings.FlyDistance);
                _endPosition = RectTransform.anchoredPosition;
            }

            RectTransform.anchoredPosition = Vector2.LerpUnclamped(_startPosition, _endPosition,
                Time.time * EffectSettings.Speed);

            if (Vector2Helpers.AreIdentical(RectTransform.anchoredPosition, _endPosition))
            {
                OnEffectEnd();
            }
        }

        /// <summary>
        /// Sets a starting distance of a Module to prepare for a FlyIn Effect.
        /// </summary>
        /// <param name="direction">The fly direction.</param>
        /// <param name="distance">The distance from the designated position.</param>
        /// <exception cref="ArgumentOutOfRangeException">direction - null</exception>
        private void SetStartPosition(FlyDirection direction, float distance)
        {
            switch (direction)
            {
                case FlyDirection.Left:

                    _startPosition = new Vector2(
                            _endPosition.x - distance,
                            _endPosition.y
                        );

                    break;

                case FlyDirection.Right:

                    _startPosition = new Vector2(
                        _endPosition.x + distance,
                        _endPosition.y
                    );

                    break;

                case FlyDirection.Top:

                    _startPosition = new Vector2(
                        _endPosition.x,
                        _endPosition.y + distance
                    );

                    break;

                case FlyDirection.Bottom:

                    _startPosition = new Vector2(
                        _endPosition.x,
                        _endPosition.y - distance
                    );

                    break;

                case FlyDirection.TopLeft:

                    _startPosition = new Vector2(
                        _endPosition.x - distance,
                        _endPosition.y + distance
                    );

                    break;

                case FlyDirection.TopRight:

                    _startPosition = new Vector2(
                        _endPosition.x + distance,
                        _endPosition.y + distance
                    );

                    break;

                case FlyDirection.BottomLeft:

                    _startPosition = new Vector2(
                        _endPosition.x - distance,
                        _endPosition.y - distance
                    );

                    break;

                case FlyDirection.BottomRight:

                    _startPosition = new Vector2(
                        _endPosition.x + distance,
                        _endPosition.y - distance
                    );

                    break;

                default:
                    throw new ArgumentOutOfRangeException("direction", direction, null);
            }
        }
    }
}