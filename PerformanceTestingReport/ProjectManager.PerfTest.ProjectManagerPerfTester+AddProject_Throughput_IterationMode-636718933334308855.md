# ProjectManager.PerfTest.ProjectManagerPerfTester+AddProject_Throughput_IterationMode
_07-09-2018 05:02:13_
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
|    Elapsed Time |              ms |        3,758.00 |        3,095.40 |        2,471.00 |          485.49 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.05 |          999.89 |          999.73 |            0.12 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        2,471.00 |          999.73 |    10,00,273.21 |
|               2 |        3,056.00 |          999.86 |    10,00,137.07 |
|               3 |        2,859.00 |          999.88 |    10,00,122.21 |
|               4 |        3,333.00 |        1,000.05 |     9,99,954.40 |
|               5 |        3,758.00 |          999.94 |    10,00,055.69 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 3,095.40 ms.

