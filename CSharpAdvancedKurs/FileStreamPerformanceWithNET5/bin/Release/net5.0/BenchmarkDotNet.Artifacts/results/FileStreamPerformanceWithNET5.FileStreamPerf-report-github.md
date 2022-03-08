``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.985 (20H2/October2020Update)
Intel Core i5-1035G4 CPU 1.10GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT


```
|     Method |      Mean |     Error |    StdDev |
|----------- |----------:|----------:|----------:|
|  ReadAsync |  2.961 ms | 0.0588 ms | 0.1119 ms |
| WriteAsync | 22.934 ms | 0.8303 ms | 2.4481 ms |
