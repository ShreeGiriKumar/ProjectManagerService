# ProjectManager.PerfTest.UserManagerPerfTester+AddUser_Throughput_IterationMode
_07-09-2018 04:51:12_
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
|    Elapsed Time |              ms |        2,958.00 |        2,261.20 |        1,671.00 |          489.13 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.22 |          999.94 |          999.64 |            0.25 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,671.00 |          999.72 |    10,00,277.74 |
|               2 |        1,975.00 |          999.64 |    10,00,361.27 |
|               3 |        2,239.00 |        1,000.22 |     9,99,777.27 |
|               4 |        2,463.00 |        1,000.11 |     9,99,889.32 |
|               5 |        2,958.00 |        1,000.01 |     9,99,993.95 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 2,261.20 ms.

