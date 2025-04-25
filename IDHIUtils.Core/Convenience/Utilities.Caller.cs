//
// Utilities
//
// Ignore Spelling: Utils cha

using UnityEngine;


namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    public partial class Utilities
    {
        /// <summary>
        /// Gets the name of the caller method.
        /// </summary>
        /// <returns></returns>
        public static string GetCallerName()
        {
            var stackTrace = new System.Diagnostics.StackTrace();
            var frame = stackTrace.GetFrame(2);
            var method = frame.GetMethod();
            var className = method.DeclaringType.Name;
            var methodName = method.Name;
            return $"{className}.{methodName}";
        }
    }
}
