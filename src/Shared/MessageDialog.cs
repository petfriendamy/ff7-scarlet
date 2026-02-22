#pragma warning disable CA1416
namespace FF7Scarlet.Shared
{
    public static class MessageDialog
    {
        public static void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowInfo(IWin32Window? owner, string message, string title = "Information")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowWarning(IWin32Window? owner, string message, string title = "Warning")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(IWin32Window? owner, string message, string title = "Error")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool AskYesNo(string question, string title = "Confirm")
        {
            return MessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static DialogResult AskYesNo(IWin32Window? owner, string question, string title = "Confirm")
        {
            return MessageBox.Show(owner, question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult AskYesNoCancel(string question, string title = "Confirm")
        {
            return MessageBox.Show(question, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult AskYesNoCancel(IWin32Window? owner, string question, string title = "Confirm")
        {
            return MessageBox.Show(owner, question, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static void ShowException(Exception ex, string? context = null)
        {
            ExceptionHandler.Handle(ex, context);
        }

        public static void ShowException(Exception ex, IWin32Window? owner, string? context = null)
        {
            ExceptionHandler.Handle(ex, owner, context);
        }
    }
}