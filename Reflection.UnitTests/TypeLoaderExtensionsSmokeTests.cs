// Copyright and trademark notices at the end of this file.

using SharperHacks.CoreLibs.Reflection.UnitTests.TestInterface;

using System.Reflection;

// ReSharper disable once CheckNamespace
namespace SharperHacks.CoreLibs.Reflection.UnitTests;

[ExcludeFromCodeCoverage]
[TestClass]
public class TypeLoaderExtensionsSmokeTests
{
    [TestMethod]
    public void TestGetLoadableTypes()
    {
        var assemblyName = "SharperHacks.CoreLibs.ReflectionTestTarget";
        var fileName = Path.Join(Directory.GetCurrentDirectory(), assemblyName + ".dll");
        var expectedCount = 5;

        Console.WriteLine($"Current directory {Directory.GetCurrentDirectory()}");

        Assert.IsTrue(File.Exists(fileName));

        var assembly = Assembly.LoadFrom(fileName);

        var allTypes = new List<Type>(assembly.GetLoadableTypes());
        Assert.IsNotNull(allTypes);

        foreach (var type in allTypes)
        {
            Assert.IsNotNull(type);
            Console.WriteLine(type.FullName);
        }

#if NET7_0
    // ToDo: Why the special case here?
    //   I get two exta types in the Net7.0 target test run:
    //     Microsoft.CodeAnalysis.EmbeddedAttribute
    //     System.Runtime.ComplerServices.RefSafetyRulesAttribute.
    //
        Assert.AreEqual(expectedCount + 2, allTypes.Count);
#else
        Assert.AreEqual(expectedCount, allTypes.Count);
#endif

        var interface1Types = new List<Type>(assembly.GetLoadableTypesWithInterface(typeof(ITest3)));
        Assert.IsNotNull(interface1Types);
        Assert.AreEqual(2, interface1Types.Count);
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
