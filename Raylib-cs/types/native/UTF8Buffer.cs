using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Raylib_cs
{
    /// <summary>
    /// Converts text to a UTF8 buffer for passing to native code
    /// </summary>
    public ref struct UTF8Buffer
    {
        private IntPtr _data;

        public UTF8Buffer(string text)
        {
            _data = Marshal.StringToHGlobalAnsi(text);
        }

        public unsafe sbyte* AsPointer()
        {
            return (sbyte*)_data.ToPointer();
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(_data);
        }
    }

    public static class Utf8StringUtils
    {
        public static UTF8Buffer ToUTF8Buffer(this string text)
        {
            return new UTF8Buffer(text);
        }

        public static byte[] ToUtf8String(this string text)
        {
            if (text == null)
            {
                return null;
            }

            var length = Encoding.UTF8.GetByteCount(text);

            var byteArray = new byte[length + 1];
            var wrote = Encoding.UTF8.GetBytes(text, 0, text.Length, byteArray, 0);
            byteArray[wrote] = 0;

            return byteArray;
        }

        public static unsafe string GetUTF8String(sbyte* bytes)
        {
            return Marshal.PtrToStringUTF8((IntPtr)bytes);
        }

        public static byte[] GetUTF8Bytes(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
