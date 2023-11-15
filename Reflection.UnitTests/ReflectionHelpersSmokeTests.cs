// Copyright Joseph W Donahue and SharperHacks LLC (US-WA)
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
// SharperHacks is a trademark of SharperHacks LLC (US-Wa), and may not be
// applied to distributions of derivative works, without the express written
// permission of a registered officer of SharperHacks LLC (US-WA).

using SharperHacks.CoreLibs.Reflection.UnitTests.TestInterface;
using SharperHacks.CoreLibs.Reflection.UnitTests.TestTarget;

using System.Reflection;

namespace SharperHacks.Reflection.UnitTests;

[ExcludeFromCodeCoverage]
[TestClass]
public class ReflectionHelpersSmokeTests
{
    [TestMethod]
    public void TestDoesTypeSupportInterface()
    {
        Assert.IsTrue(ReflectionHelpers.DoesTypeSupportInterface(typeof(Test1), typeof(ITest1)));
        Assert.IsFalse(ReflectionHelpers.DoesTypeSupportInterface(typeof(Test2), typeof(ITest3)));
    }

    [TestMethod]
    public void TestGetReferencingAssemblies()
    {
        var referencedAssembly = typeof(ITest1).Assembly;
        var results = ReflectionHelpers.GetReferencingAssemblies(referencedAssembly);

        Assert.IsNotNull(results);

        var expectedPrefixes = new[]
        {
            "SharperHacks.CoreLibs.Reflection.UnitTests",
            "SharperHacks.CoreLibs.ReflectionTestTarget",
        };

        Console.WriteLine($"\n{nameof(expectedPrefixes)}:");
        foreach(var element in expectedPrefixes)
        {
            Console.WriteLine($"  {element}");
        }

        var names = new List<string>();

        Console.WriteLine("\nResults:");
        foreach(var result in results)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.FullName);

            var shortName = result.FullName.Split(',')[0];

            Console.WriteLine($"  {shortName}");
            names.Add(shortName);
        }
        Assert.AreEqual(expectedPrefixes.Length, names.Count);

        foreach(var name in names)
        {
            Assert.IsTrue(expectedPrefixes.Contains(name));
        }
    }

    [TestMethod]
    public void TestGetTypesSupportingInterface()
    {
        var interfaceType = typeof(ITest3);
        var assembly = Assembly.Load("SharperHacks.CoreLibs.ReflectionTestTarget");

        var types = new List<Type>(assembly.GetTypesSupportingInterface(interfaceType));

        foreach(var type in types)
        {
            Console.WriteLine(type.FullName);
        }
    }

    [TestMethod]
    public void TestGetNonAbstractTypesImplementingInterface()
    {
        var desiredType = typeof(ITest3);
        var expectedTypeNames = new[]
        {
            "Test123",
            "Test3",
        };

        Console.WriteLine($"\n{nameof(expectedTypeNames)}");
        foreach(var name in expectedTypeNames)
        {
            Console.WriteLine($"  {name}");
        }

        var results = ReflectionHelpers.GetNonAbstractTypesImplementingInterface(desiredType);
        var names = new List<string>();

        Console.WriteLine("\nResults:");
        foreach(var type in results)
        {
            var name = type.Name;
            Console.WriteLine($"  {name}");
            names.Add(name);
        }

        foreach(var name in names)
        {
            Assert.IsTrue(expectedTypeNames.Contains(name));
        }

        Assert.AreEqual(expectedTypeNames.Length, names.Count);
    }

    [TestMethod]
    public void TestGetTypesImplementingInterface()
    {
        var desiredType = typeof(ITest3);
        var expectedTypeNames = new[]
        {
            "ITest3",
            "Test123",
            "Test3",
        };

        Console.WriteLine($"\n{nameof(expectedTypeNames)}");
        foreach (var name in expectedTypeNames)
        {
            Console.WriteLine($"  {name}");
        }

        var results = ReflectionHelpers.GetTypesImplementingInterface(desiredType);
        var names = new List<string>();

        Console.WriteLine("\nResults:");
        foreach (var type in results)
        {
            var name = type.Name;
            Console.WriteLine($"  {name}");
            names.Add(name);
        }

        foreach (var name in names)
        {
            Assert.IsTrue(expectedTypeNames.Contains(name));
        }

        Assert.AreEqual(expectedTypeNames.Length, names.Count);
    }
}
