// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Reflection.UnitTests;

[ExcludeFromCodeCoverage()]
[TestClass]
public class CodeSmokeTests
{
    [TestMethod]
    public void LineNumber()
    {
        Assert.AreEqual(12, Code.LineNumber(), Code.AtLineNumber());
    }

    [TestMethod]
    public void MemberName()
    {
        Assert.AreEqual(
            nameof(MemberName),
            Code.MemberName(), 
            Code.AtLineNumber());
    }

    [TestMethod]
    public void SourceFilePathName()
    {
        // We define the PathMap element in Directory.Build.Props to strip away path
        // elements in front of the solution root directory. This avoids machine or
        // user information that might otherwise be embedded in the source path.
        Assert.AreEqual(
            "{SHLLC/CoreLibs/Reflection}/Reflection.UnitTests/CodeSmokeTests.cs",
            Code.SourceFilePathName(),
            Code.AtLineNumber());
    }

    [TestMethod]
    public void AtLineNumber()
    {
        Assert.AreEqual("@ Line 39", Code.AtLineNumber(), Code.AtLineNumber());
    }

    [TestMethod]
    public void MemberAtFqpnWithLineNumber()
    {
        Assert.AreEqual(
            $"{nameof(MemberAtFqpnWithLineNumber)} @ " +
            $"{{SHLLC/CoreLibs/Reflection}}/Reflection.UnitTests/CodeSmokeTests.cs(48)",
            Code.MemberAtFqpnWithLineNumber(),
            Code.AtLineNumber());
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
