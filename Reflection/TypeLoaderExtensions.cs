// Copyright and trademark notices at the end of this file.

using SharperHacks.CoreLibs.Constraints;

using System.Reflection;

namespace SharperHacks.CoreLibs.Reflection;

/// <summary>
/// Assembly.GetTypes wrappers.
/// </summary>
public static class TypeLoaderExtensions
{
    /// <summary>
    /// Get all loadable types
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly) 
    {
        Verify.IsNotNull(assembly, nameof(assembly));

        try 
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            var filtered = new List<Type>();

            foreach(var item in e.Types)
            {
                if (item is not null) filtered.Add(item);
            }

            return filtered;
        }
    }

    /// <summary>
    /// Get all loadable types that have the specified interface.
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"/>
    public static IEnumerable<Type> GetLoadableTypesWithInterface(this Assembly assembly, Type t)
    {
        Verify.IsTrue(t.IsInterface, $"Parameter {nameof(t)} must be an interface type.");

        foreach(var item in assembly.GetLoadableTypes())
        {
            if (item is not null && t.IsAssignableFrom(item)) yield return item;
        }
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
