using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FF7Scarlet.Shared
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex, string? context = null)
        {
            string logMessage = string.IsNullOrEmpty(context)
                ? $"Unexpected error: {ex}"
                : $"Unexpected error in {context}: {ex}";

            Debug.WriteLine(logMessage);

            if (ex.InnerException != null)
            {
                Debug.WriteLine($"  Inner exception: {ex.InnerException}");
            }

            string message;
            if (ex is FileNotFoundException)
                message = "The specified file could not be found.";
            else if (ex is IOException)
                message = "An I/O error occurred while accessing file.";
            else if (ex is FormatException)
                message = "The data format is invalid.";
            else if (ex is InvalidOperationException)
                message = "An invalid operation was attempted.";
            else if (ex is ArgumentException)
                message = "An invalid argument was provided.";
            else if (ex is ArgumentNullException)
                message = "A required argument was null.";
            else if (ex is AggregateException)
                message = "Multiple errors occurred during the operation.";
            else if (ex is EndOfStreamException)
                message = "Unexpected end of data stream reached.";
            else if (ex is UnauthorizedAccessException)
                message = "Access to the file was denied.";
            else if (ex is ArgumentOutOfRangeException)
                message = "A value was outside the valid range.";
            else
                message = $"An unexpected error occurred: {ex.Message}";

            if (ex.InnerException != null)
            {
                message += $" ({ex.InnerException.Message})";
            }

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Handle(Exception ex, IWin32Window? owner, string? context = null)
        {
            string logMessage = string.IsNullOrEmpty(context)
                ? $"Unexpected error: {ex}"
                : $"Unexpected error in {context}: {ex}";

            Debug.WriteLine(logMessage);

            if (ex.InnerException != null)
            {
                Debug.WriteLine($"  Inner exception: {ex.InnerException}");
            }

            string message;
            if (ex is FileNotFoundException)
                message = "The specified file could not be found.";
            else if (ex is IOException)
                message = "An I/O error occurred while accessing file.";
            else if (ex is FormatException)
                message = "The data format is invalid.";
            else if (ex is InvalidOperationException)
                message = "An invalid operation was attempted.";
            else if (ex is ArgumentException)
                message = "An invalid argument was provided.";
            else if (ex is ArgumentNullException)
                message = "A required argument was null.";
            else if (ex is AggregateException)
                message = "Multiple errors occurred during the operation.";
            else if (ex is EndOfStreamException)
                message = "Unexpected end of data stream reached.";
            else if (ex is UnauthorizedAccessException)
                message = "Access to the file was denied.";
            else if (ex is ArgumentOutOfRangeException)
                message = "A value was outside the valid range.";
            else
                message = $"An unexpected error occurred: {ex.Message}";

            if (ex.InnerException != null)
            {
                message += $" ({ex.InnerException.Message})";
            }

            MessageBox.Show(owner, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
