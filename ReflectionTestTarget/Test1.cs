// Copyright and trademark notices at the end of this file.

// ReSharper disable once CheckNamespace

using SharperHacks.CoreLibs.Reflection.UnitTests.TestInterface;

using System.Diagnostics.CodeAnalysis;


// ReSharper disable once CheckNamespace
namespace SharperHacks.CoreLibs.Reflection.UnitTests.TestTarget;

[ExcludeFromCodeCoverage]
public class Test1 : ITest1
{
    public int Value { get; set; } = 41;
    public string StrValue { get; set; } = "41 and 43 are prime.";
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
