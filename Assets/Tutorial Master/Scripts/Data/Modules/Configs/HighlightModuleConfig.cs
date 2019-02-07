using System;

namespace HardCodeLab.TutorialMaster
{
    [Serializable]
    public class HighlightModuleConfig : ModuleConfig<HighlightModule, HighlightModuleSettings>
    {
        public HighlightModuleConfig(TutorialMasterManager manager, string parentStagePath) : base(manager)
        {
        }

        protected override void GetModuleFromPool()
        {
            Module = ParentManager.HighlighterModulePool.AllocateModule();
        }
    }
}