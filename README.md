<h1>
<img src="/icon.png" alt="fast-enum-string" width="64"/>
FastEnumString
</h1>
<p align="left">
    <a href="https://github.com/petarpetrovt/fast-enum-string/actions?query=workflow%3ABuild" alt="Build and test">
        <img alt="Build and test" src="https://github.com/petarpetrovt/fast-enum-string/workflows/Build%20and%20test/badge.svg?branch=master" />
    </a>
    <a href="https://github.com/petarpetrovt/fast-enum-string/actions?query=workflow%3ACodeQL" alt="CodeQL">
        <img alt="CodeQL" src="https://github.com/petarpetrovt/fast-enum-string/workflows/CodeQL/badge.svg?branch=master" />
    </a>
    <a href="https://codecov.io/gh/petarpetrovt/fast-enum-string" alt="codecov">
        <img alt="codecov" src="https://codecov.io/gh/petarpetrovt/fast-enum-string/branch/master/graph/badge.svg?token=nzdk7N3iVY" />
    </a>
    <a href="https://www.nuget.org/packages/FastEnumString" alt="NuGet">
        <img alt="NuGet" src="https://img.shields.io/nuget/v/FastEnumString.svg" />
    </a>
    <a href="https://app.fossa.com/projects/git%2Bgithub.com%2Fpetarpetrovt%2Ffast-enum-string?ref=badge_shield" alt="License">
        <img alt="License" src="https://app.fossa.com/api/projects/git%2Bgithub.com%2Fpetarpetrovt%2Ffast-enum-string.svg?type=shield" />
    </a>
    <a href="https://github.com/petarpetrovt/fast-enum-string/graphs/contributors" alt="Contributors">
        <img alt="Contributors" src="https://img.shields.io/github/contributors/petarpetrovt/fast-enum-string?color=brightgreen" />
    </a>
    <a href="https://github.com/petarpetrovt/fast-enum-string/stargazers" alt="stargazers">
       <img alt="stargazers" src="https://img.shields.io/github/stars/petarpetrovt/fast-enum-string?color=brightgreen" />
    </a>
</p>

A source generator for generating `ToStringFast` extension method.

### Enum declaration:

```csharp
public enum TestEnum
{
    Test1,
    Test2,
}
```

### Generated code:

```csharp
public static class TestEnum_FastEnumString
{
    public static string ToStringFast(this TestEnum value)
    {
        switch(value)
        {
            case TestEnum.Test1: return nameof(TestEnum.Test1);
            case TestEnum.Test2: return nameof(TestEnum.Test2);
            default:
                throw new System.ArgumentException($"TestEnum value `{value}` is not supported in this context.", nameof(value));
        }
    }
}
```

## Benchmarks

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


```
|           Method | Value |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------- |------ |-----------:|----------:|----------:|-------:|----------:|
| ToStringOriginal | Test1 | 26.8338 ns | 0.3286 ns | 0.3073 ns | 0.0029 |      24 B |
|     ToStringFast | Test1 |  0.7085 ns | 0.0095 ns | 0.0089 ns |      - |         - |

## License
<a href="https://app.fossa.com/projects/git%2Bgithub.com%2Fpetarpetrovt%2Ffast-enum-string?ref=badge_large">
  <img alt="License" src="https://app.fossa.com/api/projects/git%2Bgithub.com%2Fpetarpetrovt%2Ffast-enum-string.svg?type=large" />
</a>

## Contributors
<a href="https://github.com/petarpetrovt/fast-enum-string/graphs/contributors">
  <img alt="Contributors" src="https://contributors-img.web.app/image?repo=petarpetrovt/fast-enum-string" />
</a>

Made with [contributors-img](https://contributors-img.web.app).
