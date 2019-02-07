using UnityEngine;

namespace HardCodeLab.TutorialMaster
{
    /// <summary>
    /// Helper methods for Vector2 operations
    /// </summary>
    public static class Vector2Helpers
    {
        /// <summary>
        /// Measures the distance between two vectors. More efficient than Vector2.Distance()
        /// </summary>
        /// <param name="a">First Vector2</param>
        /// <param name="b">Second Vector2</param>
        /// <returns>Float representing a distance between two vectors.</returns>
        public static float MeasureDistance(Vector2 a, Vector2 b)
        {
            return (a - b).sqrMagnitude;
        }

        /// <summary>
        /// Checks if two vectors are identical accounting for floating point.
        /// The process is measuring the distance between two vectors and determining if their distance is close enough to be considered identical.
        /// </summary>
        /// <param name="a">First Vector2</param>
        /// <param name="b">Second Vector2</param>
        /// <param name="floatingPoint">The floating point.</param>
        /// <returns>Returns true if both vectors are identical.</returns>
        public static bool AreIdentical(Vector2 a , Vector2 b, float floatingPoint = 0.01f)
        {
            return MeasureDistance(a, b) <= floatingPoint;
        }
    }
}