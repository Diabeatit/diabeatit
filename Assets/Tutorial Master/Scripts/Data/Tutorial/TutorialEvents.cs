using System;
using UnityEngine.Events;

namespace HardCodeLab.TutorialMaster
{
    /// <summary>
    /// Stores all UnityEvents for Tutorial.
    /// </summary>
    [Serializable]
    public class TutorialEvents
    {
        /// <summary>
        /// Used to specify actions to invoke when this Tutorial just started playing.
        /// </summary>
        public UnityEvent OnTutorialStart;

        /// <summary>
        /// Used to specify actions to invoke when this Tutorial just stopped playing.
        /// </summary>
        public UnityEvent OnTutorialEnd;
    }
}