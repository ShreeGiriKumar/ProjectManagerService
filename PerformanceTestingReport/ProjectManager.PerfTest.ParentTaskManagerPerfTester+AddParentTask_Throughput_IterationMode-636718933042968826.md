# ProjectManager.PerfTest.ParentTaskManagerPerfTester+AddParentTask_Throughput_IterationMode
_07-09-2018 05:01:44_
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
|    Elapsed Time |              ms |        3,133.00 |        2,356.60 |        1,731.00 |          541.26 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.29 |          999.96 |          999.70 |            0.24 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,731.00 |          999.70 |    10,00,301.73 |
|               2 |        2,201.00 |          999.75 |    10,00,252.43 |
|               3 |        2,082.00 |        1,000.29 |     9,99,713.74 |
|               4 |        2,636.00 |        1,000.09 |     9,99,912.67 |
|               5 |        3,133.00 |          999.98 |    10,00,016.73 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 2,356.60 ms.

