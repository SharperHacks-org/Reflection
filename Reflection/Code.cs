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

using System.Runtime.CompilerServices;

namespace SharperHacks.CoreLibs.Reflection;

/// <summary>
/// Static functions for line number, source file path, member name.
/// </summary>
public static class Code
{
    /// <summary>
    /// Returns the current line number
    /// </summary>
    /// <param name="lineNumber">The compiler will fill this in for you.</param>
    /// <returns></returns>
    public static int LineNumber([CallerLineNumber] int lineNumber = -1) => lineNumber;

    /// <summary>
    /// Returns the current source file path and name.
    /// </summary>
    /// <param name="fileName">The compiler will fill this in for you.</param>
    /// <returns></returns>
    public static string SourceFilePathName([CallerFilePath] string fileName = "Not resolvable")
    {
        Verify.IsNotNull(fileName);

        return fileName;
    }

    /// <summary>
    /// Returns the current method/member name.
    /// </summary>
    /// <param name="memberName">The compiler will fill this in for you.</param>
    /// <returns></returns>
    public static string MemberName([CallerMemberName] string memberName = "Not resolvable")
    {
        Verify.IsNotNull(memberName);

        return memberName;
    }
}