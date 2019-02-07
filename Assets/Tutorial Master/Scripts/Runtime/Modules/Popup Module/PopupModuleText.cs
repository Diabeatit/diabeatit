using UnityEngine;
using UnityEngine.UI;

namespace HardCodeLab.TutorialMaster
{
    /// <summary>
    /// Popup Module that uses default UnityEngine.UI Text
    /// </summary>
    /// <seealso cref="PopupModule" />
    [AddComponentMenu("Tutorial Master/UGUI Popup Module (Default)")]
    public class PopupModuleText : PopupModule
    {
        /// <summary>
        /// The Text component which is responsible for Popup's Button Label.
        /// </summary>
        public Text ButtonLabelText;

        /// <summary>
        /// The Text component which is responsible for Popup's message body.
        /// </summary>
        public Text MessageBodyText;

        /// <summary>
        /// The Text component which is responsible for Popup's title.
        /// </summary>
        public Text TitleText;

        /// <inheritdoc />
        /// <summary>
        /// Sets the button label for this Popup Module unless it's missing an appropriate component.
        /// Text won't be changed if it's empty.
        /// </summary>
        /// <param name="text">The text which will be set.</param>
        protected override void SetButtonLabel(string text)
        {
            if (string.IsNullOrEmpty(text))
                text = "";

            if (NullChecker.IsNull(ButtonLabelText, "Unable to set button label text. Missing Text Component for Button label.", this))
                return;

            ButtonLabelText.text = text;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the message for this Popup Module unless it's missing an appropriate component.
        /// Text won't be changed if it's empty.
        /// </summary>
        /// <param name="text">The text which will be set.</param>
        protected override void SetMessage(string text)
        {
            if (string.IsNullOrEmpty(text))
                text = "";

            if (NullChecker.IsNull(ButtonLabelText, "Unable to set Message Body! Missing Text Component for Message body.", this))
                return;

            MessageBodyText.text = text;
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the title for this Popup Module unless it's missing an appropriate component
        /// </summary>
        /// <param name="text">The text which will be set.</param>
        protected override void SetTitle(string text)
        {
            if (string.IsNullOrEmpty(text))
                text = "";

            if (NullChecker.IsNull(ButtonLabelText, "Unable to set Title Text! Missing Text Component for Title text.", this))
                return;

            TitleText.text = text;
        }
    }
}