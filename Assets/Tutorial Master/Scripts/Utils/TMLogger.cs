using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HardCodeLab.TutorialMaster
{
    /// <summary>
    /// Logs Tutorial Master related errors
    /// </summary>
    public static class TMLogger
    {
        /// <summary>
        /// Gets or sets the logging level of the Tutorial Master
        /// </summary>
        /// <value>
        /// The logging level.
        /// </value>
        public static LoggingLevel LoggingLevel
        {
            get
            {
                if (!PlayerPrefs.HasKey("tm_loggingLevel"))
                {
                    PlayerPrefs.SetInt("tm_loggingLevel", (int)LoggingLevel.WarningsAndErrors);
                }

                return (LoggingLevel)PlayerPrefs.GetInt("tm_loggingLevel");
            }
            set
            {
                PlayerPrefs.SetInt("tm_loggingLevel", (int)value);
            }
        }

        /// <summary>
        /// Prepended to the beginning for every log message. Contains the caller name and type.
        /// </summary>
        private const string LogHeaderWithCaller = "<b>[Tutorial Master]</b> [Caller \"{0}\" of type \"{1}\"] {2}";

        /// <summary>
        /// Prepended to the beginning for every log message.
        /// </summary>
        private const string LogHeader = "<b>[Tutorial Master]</b> {0}";

        /// <summary>
        /// Logs the specified Message to Unity console unless user has disabled them
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="caller">MonoBehaviour from which message has been logged</param>
        public static void LogInfo(string message, Object caller = null)
        {
            if (LoggingLevel != LoggingLevel.Full) return;

            if (caller != null)
            {
                Debug.Log(string.Format(LogHeaderWithCaller, caller.name, caller.GetType().Name, message), caller);
            }
            else
            {
                Debug.Log(string.Format(LogHeader, message));
            }
        }

        /// <summary>
        /// Logs the exception then returns it
        /// </summary>
        /// <param name="exception">The exception that will be logged.</param>
        /// <returns>Exception. Usually used to throw it by the caller function.</returns>
        public static Exception LogException(Exception exception)
        {
            Debug.LogError(exception.Message);
            return exception;
        }

        /// <summary>
        /// Logs the specified Error Message to Unity console unless user has disabled them
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="caller">MonoBehaviour from which message has been logged</param>
        public static void LogError(string message, Object caller = null)
        {
            if (LoggingLevel != LoggingLevel.WarningsAndErrors
                && LoggingLevel != LoggingLevel.ErrorsOnly
                && LoggingLevel != LoggingLevel.Full) return;

            if (caller != null)
            {
                Debug.LogError(string.Format(LogHeaderWithCaller, caller.name, caller.GetType().Name, message), caller);
            }
            else
            {
                Debug.LogError(string.Format(LogHeader, message));
            }
        }

        /// <summary>
        /// Logs the specified Warning Message to Unity console unless user has disabled them
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="caller">MonoBehaviour from which message has been logged</param>
        public static void LogWarning(string message, Object caller = null)
        {
            if (LoggingLevel != LoggingLevel.WarningsAndErrors
                && LoggingLevel != LoggingLevel.WarningsOnly
                && LoggingLevel != LoggingLevel.Full) return;

            if (caller != null)
            {
                Debug.LogWarning(string.Format(LogHeaderWithCaller, caller.name, caller.GetType().Name, message), caller);
            }
            else
            {
                Debug.LogWarning(string.Format(LogHeader, message));
            }
        }
    }
}