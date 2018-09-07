# ProjectManager.PerfTest.TaskManagerPerfTester+AddTask_Throughput_IterationMode
_07-09-2018 05:08:40_
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
|    Elapsed Time |              ms |       14,266.00 |       10,161.20 |        7,135.00 |        2,915.37 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.04 |        1,000.00 |          999.97 |            0.03 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        7,135.00 |        1,000.04 |     9,99,963.17 |
|               2 |        7,837.00 |          999.97 |    10,00,031.57 |
|               3 |        9,832.00 |        1,000.00 |    10,00,003.48 |
|               4 |       11,736.00 |        1,000.00 |     9,99,998.41 |
|               5 |       14,266.00 |          999.97 |    10,00,028.28 |


## Benchmark Assertions

* [FAIL] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 10,161.20 ms.

