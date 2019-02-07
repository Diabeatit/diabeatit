using System;

namespace HardCodeLab.TutorialMaster
{
    [Serializable]
    public class ImageModuleConfig : ModuleConfig<ImageModule, ImageModuleSettings>
    {
        public ImageModuleConfig(TutorialMasterManager manager, string parentStagePath) : base(manager)
        {
        }

        protected override void GetModuleFromPool()
        {
            Module = ParentManager.ImageModulePool.AllocateModule();
        }
    }
}