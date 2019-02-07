using UnityEditor;

namespace HardCodeLab.TutorialMaster.EditorUI
{
    /// <inheritdoc />
    /// <summary>
    /// Responsible for rendering the GUI for all module pools.
    /// </summary>
    /// <seealso cref="T:HardCodeLab.TutorialMaster.EditorUI.Section" />
    public sealed class PoolingEditor : Section
    {
        private readonly ModulePoolSettingsEditor<ArrowModule> _arrowModulePoolEditor;

        private readonly ModulePoolSettingsEditor<HighlightModule> _highlighterModulePoolEditor;

        private readonly ModulePoolSettingsEditor<ImageModule> _imageModulePoolEditor;

        private readonly ModulePoolSettingsEditor<PopupModule> _popupModulePoolEditor;

        public PoolingEditor(ref TutorialMasterEditor editor)
            : base(
                ref editor,
                "Pooling Settings",
                "This is where you assign prefabs which will be instantiated at runtime.")
        {
            _arrowModulePoolEditor =
                new ModulePoolSettingsEditor<ArrowModule>(ref editor, "Arrow Module", "ArrowModulePool");
            _imageModulePoolEditor =
                new ModulePoolSettingsEditor<ImageModule>(ref editor, "Image Module", "ImageModulePool");
            _highlighterModulePoolEditor = new ModulePoolSettingsEditor<HighlightModule>(
                ref editor,
                "Highlighter Module",
                "HighlighterModulePool");
            _popupModulePoolEditor =
                new ModulePoolSettingsEditor<PopupModule>(ref editor, "Popup Module", "PopupModulePool");
        }

        protected override void OnSectionGUI()
        {
            RenderModulePool(_arrowModulePoolEditor);
            RenderModulePool(_imageModulePoolEditor);
            RenderModulePool(_highlighterModulePoolEditor);
            RenderModulePool(_popupModulePoolEditor);
        }

        /// <summary>
        /// Renders the module pool editor
        /// </summary>
        /// <typeparam name="TModule">The type of the module.</typeparam>
        /// <param name="editor">The editor that will be rendered.</param>
        private void RenderModulePool<TModule>(ModulePoolSettingsEditor<TModule> editor)
            where TModule : Module
        {
            if (editor == null) return;
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            editor.RenderGUI();
            EditorGUILayout.EndVertical();
        }
    }
}