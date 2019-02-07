using System;
using UnityEngine.Events;

namespace HardCodeLab.TutorialMaster
{
    [Serializable]
    public class StageEvents
    {
        /// <summary>
        /// Used to specify actions to invoke when ActiveStage just started playing.
        /// </summary>
        public UnityEvent OnStageEnter;

        /// <summary>
        /// Used to specify actions to invoke when ActiveStage just finished playing.
        /// </summary>
        public UnityEvent OnStageExit;
    }
}