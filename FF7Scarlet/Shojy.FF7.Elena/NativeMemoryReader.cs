using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Shojy.FF7.Elena
{
    public class NativeMemoryReader : IDisposable, IMemoryReader
    {
        #region Private Fields

        private const uint ProcessQueryInformation = 1024;

        private const uint ProcessVmRead = 16;

        private bool _disposedValue;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Creates a new instance of the NativeMemoryReader class and attempts to get a handle to the
        /// process that is to be read by calls to the ReadMemory method.
        /// If a handle cannot be obtained then an exception is thrown
        /// </summary>
        /// <param name="processToRead">The process that memory will be read from</param>
        public NativeMemoryReader(Process processToRead)
        {
            TargetProcess = processToRead ?? throw new ArgumentNullException(nameof(processToRead));
            this.Open();
        }

        #endregion Public Constructors

        #region Private Destructors

        ~NativeMemoryReader()
        {
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Properties

        /// <summary>
        /// The process that memory will be read from when ReadMemory is called
        /// </summary>
        public Process TargetProcess { get; } = null;

        /// <summary>
        /// The handle to the process that was retrieved during the constructor or the last
        /// successful call to the Open method
        /// </summary>
        public IntPtr TargetProcessHandle { get; private set; } = IntPtr.Zero;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Closes a handle that was previously obtained by the constructor or a call to the Open method
        /// </summary>
        public void Close()
        {
            if (TargetProcessHandle != IntPtr.Zero)
            {
                var result = CloseHandle(TargetProcessHandle);
                if (!result)
                    throw new ApplicationException("Unable to close process handle. The last error reported was: " + new System.ComponentModel.Win32Exception().Message);
                TargetProcessHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Releases resources and closes any process handles that are still open
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets a handle to the process specified in the TargetProcess property.
        /// A handle is automatically obtained by the constructor of this class but if the Close
        /// method has been called to close a previously obtained handle then another handle can
        /// be obtained by calling this method. If a handle has previously been obtained and Close has
        /// not been called yet then an exception will be thrown.
        /// </summary>
        public void Open()
        {
            if (TargetProcess == null)
                throw new ApplicationException("Process not found");
            if (TargetProcessHandle == IntPtr.Zero)
            {
                TargetProcessHandle = OpenProcess(ProcessVmRead | ProcessQueryInformation, true, System.Convert.ToUInt32(TargetProcess.Id));
                if (TargetProcessHandle == IntPtr.Zero)
                    throw new ApplicationException("Unable to open process for memory reading. The last error reported was: " + new System.ComponentModel.Win32Exception().Message);
            }
            else
                throw new ApplicationException("A handle to the process has already been obtained, " + "close the existing handle by calling the Close method before calling Open again");
        }

        ///// <summary>
        ///// Reads the specified number of bytes from an address in the process's memory.
        ///// All memory in the specified range must be available or the method will fail.
        ///// Returns Nothing if the method fails for any reason
        ///// </summary>
        ///// <param name="memoryLocation">The address in the process's virtual memory to start reading from and the number of bytes to read</param>
        //public byte[] ReadMemory(MemLoc memoryLocation)
        //{
        //    if (TargetProcessHandle == IntPtr.Zero)
        //        this.Open();
        //    var bytes = new byte[memoryLocation.NumBytes + 1];
        //    var result = ReadProcessMemory(TargetProcessHandle, memoryLocation.Address, bytes, System.Convert.ToUInt32(memoryLocation.NumBytes), 0);
        //    return result ? bytes : null;
        //}

        /// <summary>
        /// Reads the specified number of bytes from an address in the process's memory.
        /// All memory in the specified range must be available or the method will fail.
        /// Returns Nothing if the method fails for any reason
        /// </summary>
        /// <param name="memoryAddress">The address in the process's virtual memory to start reading from</param>
        /// <param name="count">The number of bytes to read</param>
        public byte[] ReadMemory(IntPtr memoryAddress, int count)
        {
            if (TargetProcessHandle == IntPtr.Zero)
                this.Open();
            var bytes = new byte[count];
            var result = ReadProcessMemory(TargetProcessHandle, memoryAddress, bytes, System.Convert.ToUInt32(count), 0);
            return result ? bytes : null;
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (TargetProcessHandle != IntPtr.Zero)
                {
                    try
                    {
                        CloseHandle(TargetProcessHandle);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error closing handle - " + ex.Message);
                    }
                }
            }
            this._disposedValue = true;
        }

        #endregion Protected Methods

        #region Private Methods

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadProcessMemory([In] IntPtr hProcess, [In] IntPtr lpBaseAddress, [Out] byte[] lpBuffer, uint nSize, [Out] uint lpNumberOfBytesRead);

        #endregion Private Methods
    }

}