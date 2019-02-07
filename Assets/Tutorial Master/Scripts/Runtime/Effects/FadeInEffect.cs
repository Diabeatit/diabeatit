using UnityEngine;

namespace HardCodeLab.TutorialMaster
{
    [HelpURL("https://support.hardcodelab.com/tutorial-master/2.0/fade-in-effect")]
    public class FadeInEffect : Effect<FadeInEffectSettings>, IEffectOneShot
    {
        public event EffectEvent EffectEnd;

        public event EffectEvent EffectStart;

        public bool HasFinished { get; set; }

        public override void SetEffectSettings(FadeInEffectSettings settings)
        {
            base.SetEffectSettings(settings);
            ModuleCanvasGroup.alpha = 0;
            ModuleCanvasGroup.interactable = EffectSettings.CanInteract;

            OnEffectStart();
        }

        protected virtual void OnEffectEnd()
        {
            HasFinished = true;
            var handler = EffectEnd;
            if (handler != null) handler();
        }

        protected virtual void OnEffectStart()
        {
            HasFinished = false;
            var handler = EffectStart;
            if (handler != null) handler();
        }

        protected override void OnUpdate()
        {
            if (ModuleCanvasGroup.alpha < 1)
            {
                ModuleCanvasGroup.alpha += Time.deltaTime * EffectSettings.Speed;
            }
            else
            {
                if (!EffectSettings.CanInteract)
                {
                    ModuleCanvasGroup.interactable = true;
                    OnEffectEnd();
                }
            }
        }
    }
}