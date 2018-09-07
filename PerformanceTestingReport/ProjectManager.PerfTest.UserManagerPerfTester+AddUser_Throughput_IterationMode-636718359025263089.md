# ProjectManager.PerfTest.UserManagerPerfTester+AddUser_Throughput_IterationMode
_06-09-2018 13:05:02_
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
|    Elapsed Time |              ms |        3,311.00 |        2,528.20 |        2,115.00 |          524.55 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.22 |        1,000.08 |          999.94 |            0.11 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        2,115.00 |        1,000.22 |     9,99,782.46 |
|               2 |        2,136.00 |          999.94 |    10,00,055.66 |
|               3 |        2,254.00 |        1,000.02 |     9,99,975.07 |
|               4 |        2,825.00 |        1,000.15 |     9,99,847.33 |
|               5 |        3,311.00 |        1,000.05 |     9,99,947.15 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 2,528.20 ms.

