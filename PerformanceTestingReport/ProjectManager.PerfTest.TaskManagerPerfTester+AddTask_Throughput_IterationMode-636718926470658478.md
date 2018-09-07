# ProjectManager.PerfTest.TaskManagerPerfTester+AddTask_Throughput_IterationMode
_07-09-2018 04:50:47_
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
|    Elapsed Time |              ms |        5,763.00 |        4,431.80 |        3,172.00 |        1,039.22 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |          999.98 |          999.92 |          999.79 |            0.08 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        3,172.00 |          999.79 |    10,00,212.70 |
|               2 |        3,627.00 |          999.91 |    10,00,090.68 |
|               3 |        4,650.00 |          999.96 |    10,00,039.31 |
|               4 |        4,947.00 |          999.97 |    10,00,032.75 |
|               5 |        5,763.00 |          999.98 |    10,00,023.79 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 4,431.80 ms.

