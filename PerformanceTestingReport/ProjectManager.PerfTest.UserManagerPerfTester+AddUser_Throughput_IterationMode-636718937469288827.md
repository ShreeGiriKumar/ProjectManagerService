# ProjectManager.PerfTest.UserManagerPerfTester+AddUser_Throughput_IterationMode
_07-09-2018 05:09:06_
### System Info
```ini
NBench=NBench, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=3
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Test
SkipWarmups=True
NumberOfIterations=5, MaximumRunTime=00:00:01
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        4,327.00 |        2,943.40 |        1,765.00 |          944.39 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.01 |          999.84 |          999.61 |            0.17 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,765.00 |          999.61 |    10,00,385.38 |
|               2 |        2,471.00 |          999.85 |    10,00,146.58 |
|               3 |        3,024.00 |          999.99 |    10,00,007.37 |
|               4 |        4,327.00 |        1,000.01 |     9,99,987.29 |
|               5 |        3,130.00 |          999.74 |    10,00,262.75 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 2,943.40 ms.

