// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Reflection.UnitTests;

[ExcludeFromCodeCoverage]
[TestClass]
public class TypeConverterSmokeTests
{
    [TestMethod]
    public void TestConvertFromArrayOfStringT()
    {
        var numericStrings = new TestDataItem<int>(
            new[] { int.MinValue.ToString(), "0", int.MaxValue.ToString() },
            new[]
            {
                int.MinValue, 0, int.MaxValue,
            });
        var strings = new[]
        {
            "first",
            "The string after first",
            "another string",
        };
        var stringStrings = new TestDataItem<string>(strings, strings);

        var boolStrings = new TestDataItem<bool>(
            new[] { "true", "false", "False", "True" },
            new[]
            {
                true, false, false, true,
            });

        var intResultArrray = TypeConverter.ConvertFromArrayOfString<int[]>(numericStrings.Source);
        Assert.IsNotNull(intResultArrray);
        Assert.HasCount(numericStrings.Source.Length, intResultArrray);

        for (int idx = 0; idx < intResultArrray.Length; idx++)
        {
            Assert.AreEqual(numericStrings.ExpectedResult[idx], intResultArrray[idx]);
        }

        var stringResultArray = TypeConverter.ConvertFromArrayOfString<string[]>(stringStrings.Source);
        Assert.IsNotNull(stringResultArray);
        Assert.HasCount(stringStrings.Source.Length, stringResultArray);

        for(int idx = 0; idx < stringResultArray.Length; idx++)
        {
            Assert.AreEqual(stringStrings.ExpectedResult[idx], stringResultArray[idx]);
        }

        var boolResultArray = TypeConverter.ConvertFromArrayOfString<bool[]>(boolStrings.Source);
        Assert.IsNotNull(boolResultArray);
        Assert.HasCount(boolStrings.Source.Length, boolResultArray);

        for(int idx = 0; idx < boolResultArray.Length; idx++)
        {
            Assert.AreEqual(boolStrings.ExpectedResult[idx], boolResultArray[idx]);
        }
    }

    [TestMethod]
    public void TestConvertFromStringT()
    {
        var intData = new KeyValuePair<string, int>[]
        {
            new(int.MinValue.ToString(), int.MinValue),
            new("0", 0),
            new(int.MaxValue.ToString(), int.MaxValue),
        };

        var stringData = new KeyValuePair<string, string>[]
        {
            new("blah", "blah"),
            new("blip blap", "blip blap"),
            new("wump", "wump"),
        };

        var enumData = new KeyValuePair<string, TestEnum>[]
        {
            new("Whatever", TestEnum.Whatever),
            new("Somethingelse", TestEnum.Somethingelse),
            new("OrNot", TestEnum.OrNot),
        };

        var arrayData = new KeyValuePair<string, int[]>[]
        {
            new("1, 2, 3", new[] { 1, 2, 3 }),
            new("6,5,4", new[] { 6, 5, 4 }),
            new("   7,8,   9", new[] { 7, 8, 9 }),
        };

        foreach(var item in intData)
        {
            var result = TypeConverter.ConvertFromString<int>(item.Key);
            Assert.AreEqual(item.Value, result);
        }

        foreach(var item in stringData)
        {
            var result = TypeConverter.ConvertFromString<string>(item.Key);
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Value, result);
        }

        foreach (var item in enumData)
        {
            var result = TypeConverter.ConvertFromString<TestEnum>(item.Key);
            Assert.AreEqual(item.Value, result);
        }

        foreach(var item in arrayData)
        {
            var result = TypeConverter.ConvertFromString<int[]>(item.Key);
            Assert.IsNotNull(result);
            Assert.HasCount(item.Value.Length, result);

            for(int idx = 0; idx < result.Length; idx++)
            {
                Assert.AreEqual(item.Value[idx], result[idx]);
            }
        }
    }
}

public enum TestEnum
{
    Whatever,
    Somethingelse,
    OrNot
}

[ExcludeFromCodeCoverage]
internal record TestDataItem<T>
{
    internal string[] Source { get; init; }
    internal T[] ExpectedResult { get; init; }

    internal TestDataItem(string[] source, T[] result)
    {
        Source = source;
        ExpectedResult = result;
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
