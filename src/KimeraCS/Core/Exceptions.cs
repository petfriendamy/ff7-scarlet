namespace KimeraCS.Core
{
    /// <summary>
    /// General exception for Kimera-specific errors.
    /// </summary>
    public class KimeraException : Exception
    {
        public KimeraException(string? message, Exception? innerException = null)
        : base (message, innerException) { }
    }

    /// <summary>
    /// Thrown when a file is formatted incorrectly.
    /// </summary>
    public class FileFormatException : FormatException
    {
        public string? FileName { get; }

        public FileFormatException(string? message, string? fileName, Exception? innerException = null)
            : base(message, innerException)
        {
            FileName = fileName;
        }
    }

    /// <summary>
    /// Thrown when a P file is missing.
    /// </summary>
    public class PFileNotFoundException : FileNotFoundException
    {
        public PFileNotFoundException(string? message, string? fileName, Exception? innerException = null)
            : base(message, fileName, innerException) { }
    }

    /// <summary>
    /// Thrown when animation data exceeds format limits.
    /// </summary>
    public class AnimationSizeException : KimeraException
    {
        public int MaxSize { get; }

        public AnimationSizeException(string? message, int maxSize = 65535, Exception? innerException = null)
            : base(message, innerException)
        {
            MaxSize = maxSize;
        }
    }

    /// <summary>
    /// Thrown when there are too many vertices.
    /// </summary>
    public class TooManyVerticesException : KimeraException
    {
        public int MaxSize { get; }

        public TooManyVerticesException(string? message, int maxSize = 65535, Exception? innerException = null)
            : base(message, innerException)
        {
            MaxSize = maxSize;
        }
    }

    /// <summary>
    /// Thrown when there are too many faces.
    /// </summary>
    public class TooManyFacesException : KimeraException
    {
        public int MaxSize { get; }

        public TooManyFacesException(string? message, int maxSize = 65535, Exception? innerException = null)
            : base(message, innerException)
        {
            MaxSize = maxSize;
        }
    }
}