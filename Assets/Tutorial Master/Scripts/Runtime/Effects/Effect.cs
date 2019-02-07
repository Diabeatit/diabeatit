using System;
using UnityEngine;

namespace HardCodeLab.TutorialMaster
{
    /// <inheritdoc />
    /// <summary>
    /// Module Effect Component. Used to execute an effect for a module.
    /// </summary>
    /// <seealso cref="T:UnityEngine.MonoBehaviour" />
    [Serializable]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Module))]
    public abstract class Effect<TEffectSettings> : MonoBehaviour where TEffectSettings : EffectSettings
    {
        /// <summary>
        /// Current settings for this Effect.
        /// </summary>
        protected TEffectSettings EffectSettings;

        /// <summary>
        /// The Canvas Group component for target Module
        /// </summary>
        protected CanvasGroup ModuleCanvasGroup;

        /// <summary>
        /// The Rect Transform of this GameObject
        /// </summary>
        protected RectTransform RectTransform;

        /// <summary>
        /// The target module
        /// </summary>
        protected Module TargetModule;

        /// <summary>
        /// Applies the effect settings for this effect
        /// </summary>
        /// <param name="settings">The settings.</param>
        public virtual void SetEffectSettings(TEffectSettings settings)
        {
            EffectSettings = settings;
        }

        /// <summary>
        /// Called only once.
        /// </summary>
        protected virtual void Awake()
        {
            TargetModule = GetComponent<Module>();
            RectTransform = GetComponent<RectTransform>();
            ModuleCanvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Called every frame unless effect settings are empty.
        /// </summary>
        private void LateUpdate()
        {
            if (EffectSettings == null) 
                return;

            OnUpdate();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        protected virtual void OnUpdate()
        {
        }
    }
}