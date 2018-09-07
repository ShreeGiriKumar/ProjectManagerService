# ProjectManager.PerfTest.TaskManagerPerfTester+AddTask_Throughput_IterationMode
_06-09-2018 13:04:35_
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
|    Elapsed Time |              ms |        5,293.00 |        3,967.00 |        2,789.00 |          948.11 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.08 |          999.94 |          999.69 |            0.16 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        2,789.00 |          999.69 |    10,00,314.09 |
|               2 |        3,382.00 |          999.88 |    10,00,120.55 |
|               3 |        4,263.00 |        1,000.07 |     9,99,928.88 |
|               4 |        4,108.00 |        1,000.08 |     9,99,920.47 |
|               5 |        5,293.00 |          999.99 |    10,00,011.13 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 3,967.00 ms.

