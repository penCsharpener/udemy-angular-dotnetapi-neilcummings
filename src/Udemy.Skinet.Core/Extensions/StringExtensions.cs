namespace Udemy.Skinet.Core.Extensions {
    public static class StringExtensions {
        public static bool IsNullOrEmpty(this string text) {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsNullOrWhiteSpace(this string text) {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool HasValue(this string text) {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
