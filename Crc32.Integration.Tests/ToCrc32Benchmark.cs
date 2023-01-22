using BenchmarkDotNet.Attributes;

namespace Crc32.Integration.Tests;

[MemoryDiagnoser]
public class ToCrc32Benchmark
{
    [Params("Hello World", "The quick brown fox jumps over the lazy dog", "")]
    public string Input { get; set; }

    [Benchmark]
    public string ToCrc32() => Input.ToCrc32();
}