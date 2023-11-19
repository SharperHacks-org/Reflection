// Copyright Joseph W Donahue and Sharper Hacks LLC (US-WA)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SharperHacks is a trademark of Sharper Hacks LLC (US-Wa), and may not be
// applied to distributions of derivative works, without the express written
// permission of a registered officer of Sharper Hacks LLC (US-WA).

using SharperHacks.CoreLibs.Constraints;

using System.Globalization;

namespace SharperHacks.CoreLibs.Reflection;

/// <summary>
/// Collection of static methods to aid in converting from string representation
/// to other types.
/// </summary>
public static class TypeConverter
{
    /// <summary>
    /// Converts a string array to array of T values.
    /// </summary>
    /// <typeparam name="T">Expects an array type.</typeparam>
    /// <param name="valueStrings"></param>
    /// <returns></returns>
    public static T ConvertFromArrayOfString<T>(IEnumerable<string> valueStrings)
    {
        // ToDo: Cover arrays of arrays?
        var elementType = typeof(T).GetElementType();
        Verify.IsNotNull(elementType, nameof(elementType));

        var numElements = valueStrings.Count();
        var array = Array.CreateInstance(elementType, numElements);
        int idx = 0;

        foreach(var valueString in valueStrings)
        {
            var converted = elementType.IsEnum
                ? Enum.Parse(elementType, valueString)
                : Convert.ChangeType(valueString, elementType, CultureInfo.InvariantCulture);
            array.SetValue(converted, idx++);
        }

        return (T)Convert.ChangeType(array, typeof(T), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Convert a string to value of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valueString"></param>
    /// <returns>Value of type T</returns>
    public static T ConvertFromString<T>(string valueString)
    {
        return typeof(T).IsEnum
            ? (T)Enum.Parse(typeof(T), valueString)
            : typeof(T).IsArray 
            ? ConvertFromArrayOfString<T>(valueString.Split(',')) 
            : ChangeTypeOrThrow<T>(valueString);
    }

    /// <summary>
    /// Wraps Convert.ChangeType to convert valueString to typeof T
    /// or throw a VerifyException.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="valueString"></param>
    /// <returns></returns>
    public static T ChangeTypeOrThrow<T>(string valueString)
    {
        var converted = (T)Convert.ChangeType(valueString, typeof(T), CultureInfo.InvariantCulture);
        Verify.IsNotNull(converted, $"Failed to convert {valueString} to type {typeof(T).Name}");

        return converted;
    }
}
