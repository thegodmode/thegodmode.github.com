using System;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder strbuild, int startIndex)
        {
            /// <summary>Retrieves a substring from this instance. The substring starts at a specified character position.</summary>
            /// <returns>A string that is equivalent to the substring that begins at <paramref name="startIndex" /> in this instance </returns>
            /// <param name="startIndex">The zero-based starting character position of a substring in this instance. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
            /// <filterpriority>1</filterpriority>
            /// 
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex  can not be less then Zero");
            }

            if (startIndex >= strbuild.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex is greater then the length of this instance");
            }

            return new StringBuilder(strbuild.ToString().Substring(startIndex));
        }

        public static StringBuilder Substring(this StringBuilder strbuild, int startIndex, int length)
        {
            /// <summary>Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.</summary>
            /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> that begins at <paramref name="startIndex" /> in this instance, or <see cref="F:System.String.Empty" /> if <paramref name="startIndex" /> is equal to the length of this instance and <paramref name="length" /> is zero.</returns>
            /// <param name="startIndex">The zero-based starting character position of a substring in this instance. </param>
            /// <param name="length">The number of characters in the substring. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="startIndex" /> plus <paramref name="length" /> indicates a position not within this instance.-or- <paramref name="startIndex" /> or <paramref name="length" /> is less than zero. </exception>
            /// <filterpriority>1</filterpriority>
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex  can not be less then Zero");
            }

            if (length > strbuild.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException("From startIndex, length is greater then the length of this instance");
            }

            if (startIndex >= strbuild.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex is greater then the length of this instance");
            }

            return new StringBuilder(strbuild.ToString().Substring(startIndex,length));
        }
    }
}