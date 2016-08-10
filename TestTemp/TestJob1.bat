::@echo off
set ymd=%date:~,4%%date:~5,2%%date:~8,2%

set ymd_t=%ymd%_%time:~0,2%%time:~3,2%%time:~6,2%
set ymd_t=%ymd_t: =0%
echo 运行开始时间：%ymd_t% >> %ymd%_job1_log.txt
::批处理代码
::::::::::::::::::::::
::批处理代码
set ymd_t=%ymd%_%time:~0,2%%time:~3,2%%time:~6,2%
set ymd_t=%ymd_t: =0%
echo 运行结束时间：%ymd_t% >> %ymd%_job1_log.txt