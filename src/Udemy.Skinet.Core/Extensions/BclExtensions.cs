namespace Udemy.Skinet.Core.Extensions {
    public static class BclExtensions {
        public static bool DbEquals(this int? parameterValue, int valueToCompare) {
            return !parameterValue.HasValue || valueToCompare.Equals(parameterValue.Value);
        }
    }
}
