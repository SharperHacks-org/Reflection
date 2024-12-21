// Copyright and trademark notices at the end of this file.

using System.Reflection;

namespace SharperHacks.CoreLibs.Reflection;

/// <summary>
/// A collection of refelection helpers.
/// </summary>
public static class ReflectionHelpers
{
    /// <summary>
    /// Determines whether <paramref name="type"/> implements <paramref name="interfaceTypeToMatch"/>..
    /// Correctly handles generic interaces.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="interfaceTypeToMatch"></param>
    /// <returns>True if the interface is supported.</returns>
    public static bool DoesTypeSupportInterface(Type type, Type interfaceTypeToMatch)
    {
        if (interfaceTypeToMatch.IsAssignableFrom(type))
        {
            return true;
        }

        foreach (var i in type.GetInterfaces())
        {
            if (i.IsGenericType && i.GetGenericTypeDefinition() == interfaceTypeToMatch)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Gets all assemblies that reference <paramref name="assembly"/> in the current app domain.
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Assembly> GetReferencingAssemblies(Assembly assembly)
    {
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var assemblyName in asm.GetReferencedAssemblies())
            {
                if (AssemblyName.ReferenceMatchesDefinition(assemblyName, assembly.GetName()))
                {
                    yield return asm;
                }
            }
        }
    }

    /// <summary>
    /// Get all types implementing the specified interace.
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="interfaceTypeToMatch"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypesSupportingInterface(this Assembly assembly, Type interfaceTypeToMatch)
    {
        foreach(var type in assembly.GetTypes())
        {
            if (DoesTypeSupportInterface(type, interfaceTypeToMatch))
            {
                yield return type;
            }
        }
    }

    /// <summary>
    /// Gets all non-abstract types implementing the specified interface.
    /// </summary>
    /// <param name="desiredType"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetNonAbstractTypesImplementingInterface(Type desiredType)
    {
        foreach (var type in GetTypesImplementingInterface(desiredType))
        {
            if (!type.IsAbstract)
            {
                yield return type;
            }
        }
    }

    /// <summary>
    /// Get type implementing the specified interface type.
    /// </summary>
    /// <param name="desiredType"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypesImplementingInterface(Type desiredType)
    {
        yield return desiredType;

        foreach (var assembly in GetReferencingAssemblies(desiredType.Assembly))
        {
            foreach (var matchedType in assembly.GetTypesSupportingInterface(desiredType))
            {
                yield return matchedType;
            }
        }
    }

    /// <summary>
    /// Get whether the type is a simple value type (numeric struct).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsSimpleValueType<T>(Type type)
    {
        if (!type.IsValueType) return false;

        var properties = type.GetProperties();

        return properties is not null
          && properties.Length == 0
          && type.GetFields().Length == 0;
    }
}

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
