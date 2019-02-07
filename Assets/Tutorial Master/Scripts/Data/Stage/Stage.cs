using System;

namespace HardCodeLab.TutorialMaster
{
    /// <summary>
    /// Stage is a portion of a Tutorial. Each Stage carries a simple set of instructions for a player to follow.
    /// </summary>
    [Serializable]
    public class Stage
    {
        /// <summary>
        /// Stores Audio settings
        /// </summary>
        public StageAudio Audio;

        /// <summary>
        /// Stores Events settings
        /// </summary>
        public StageEvents Events;

        /// <summary>
        /// If true, then this tutorial will be played.
        /// </summary>
        public bool IsEnabled = true;

        /// <summary>
        /// Stores Modules settings.
        /// </summary>
        public StageModules Modules;

        /// <summary>
        /// Name of the Stage.
        /// </summary>
        public string Name;

        /// <summary>
        /// Stores Trigger settings.
        /// </summary>
        public StageTrigger Trigger;

        /// <summary>
        /// Gets the unique identifier of this Stage.
        /// </summary>
        /// <value>
        /// The string representing the Id.
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Returns true if this Active Stage is currently playing
        /// </summary>
        public bool IsPlaying { get; private set; }

        /// <summary>
        /// Id of the parent tutorial
        /// </summary>
        public string ParentTutorialId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stage"/> class.
        /// </summary>
        /// <param name="parentTutorialId">Id of a tutorial this Stage will be associated with</param>
        /// <param name="name">The name of this Stage.</param>
        public Stage(string parentTutorialId, string name = "")
        {
            ParentTutorialId = parentTutorialId;
            Name = !string.IsNullOrEmpty(name) ? name : "";
            Id = Guid.NewGuid().ToString();

            Trigger = new StageTrigger();
            Audio = new StageAudio();
            Events = new StageEvents();
            Modules = new StageModules();
        }

        /// <summary>
        /// Plays this stage.
        /// </summary>
        public void Play()
        {
            if (!IsEnabled) return;
            if (IsPlaying) return;

            Trigger.Init();
            Modules.Activate();
            CheckAudio(AudioTiming.OnStageEnter);
            Events.OnStageEnter.Invoke();
            IsPlaying = true;
        }

        /// <summary>
        /// Sets the new parent tutorial for this Stage.
        /// </summary>
        /// <param name="newParentTutorial">The new parent tutorial.</param>
        public void SetParentTutorial(Tutorial newParentTutorial)
        {
            ParentTutorialId = newParentTutorial.Id;
        }

        /// <summary>
        /// Stops this stage.
        /// </summary>
        public void Stop()
        {
            if (!IsPlaying) return;

            Trigger.Disable();
            Modules.Disable();
            CheckAudio(AudioTiming.OnStageExit);
            Events.OnStageExit.Invoke();
            IsPlaying = false;
        }

        /// <summary>
        /// Checks if any audio clip needs to be played
        /// </summary>
        private void CheckAudio(AudioTiming timing)
        {
            if (Audio.Timing != timing) return;
            Audio.PlayClip();
        }
    }
}