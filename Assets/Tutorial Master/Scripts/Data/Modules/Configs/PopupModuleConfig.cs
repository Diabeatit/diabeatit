using System;

namespace HardCodeLab.TutorialMaster
{
    [Serializable]
    public class PopupModuleConfig : ModuleConfig<PopupModule, PopupModuleSettings>
    {
        public PopupModuleConfig(TutorialMasterManager manager) : base(manager)
        {
        }

        protected override void GetModuleFromPool()
        {
            Module = ParentManager.PopupModulePool.AllocateModule();
        }
    }
}