# ProjectManager.PerfTest.ProjectManagerPerfTester+GetProjectById_Throughput_IterationMode
_07-09-2018 05:07:38_
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
NumberOfIterations=1, MaximumRunTime=00:00:01
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,098.00 |        1,098.00 |        1,098.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.32 |        1,000.32 |        1,000.32 |            0.00 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,098.00 |        1,000.32 |     9,99,679.51 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 1,098.00 ms.

