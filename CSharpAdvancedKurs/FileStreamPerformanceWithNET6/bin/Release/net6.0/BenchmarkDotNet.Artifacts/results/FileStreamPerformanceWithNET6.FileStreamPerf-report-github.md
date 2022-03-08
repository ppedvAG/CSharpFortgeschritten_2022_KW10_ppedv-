``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.985 (20H2/October2020Update)
Intel Core i5-1035G4 CPU 1.10GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT


```
|     Method |     Mean |     Error |    StdDev |
|----------- |---------:|----------:|----------:|
|  ReadAsync | 2.659 ms | 0.0531 ms | 0.1023 ms |
| WriteAsync | 5.979 ms | 0.1184 ms | 0.3097 ms |
