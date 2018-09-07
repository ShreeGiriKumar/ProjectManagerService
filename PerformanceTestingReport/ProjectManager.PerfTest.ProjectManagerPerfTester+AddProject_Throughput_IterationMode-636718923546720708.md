# ProjectManager.PerfTest.ProjectManagerPerfTester+AddProject_Throughput_IterationMode
_07-09-2018 04:45:54_
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
|    Elapsed Time |              ms |        2,108.00 |        1,823.80 |        1,582.00 |          199.04 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |        1,000.38 |        1,000.05 |          999.77 |            0.22 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |        1,703.00 |        1,000.00 |     9,99,999.30 |
|               2 |        1,582.00 |        1,000.10 |     9,99,899.05 |
|               3 |        1,835.00 |        1,000.38 |     9,99,616.02 |
|               4 |        1,891.00 |          999.77 |    10,00,226.18 |
|               5 |        2,108.00 |          999.97 |    10,00,033.63 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be between 1,000.00 and 10,000.00 ms; actual value was 1,823.80 ms.

