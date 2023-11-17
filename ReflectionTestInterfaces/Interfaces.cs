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

// ReSharper disable once CheckNamespace
namespace SharperHacks.CoreLibs.Reflection.UnitTests.TestInterface;

/// <summary>
/// A test interface.
/// </summary>
public interface ITest1
{
    /// <summary>
    /// Get or set the value.
    /// </summary>
    public int Value { get; set; }
}

/// <summary>
/// A test interface.
/// </summary>
public interface ITest2
{
    /// <summary>
    /// An int method.
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once UnusedMember.Global
    public int DoSomething();
}

/// <summary>
/// A test interface.
/// </summary>
public interface ITest3
{
    /// <summary>
    /// A void method taking int.
    /// </summary>
    /// <param name="value"></param>
    // ReSharper disable once UnusedMember.Global
    public void DoSomethingElse(int value);
}