::@echo off
set ymd=%date:~,4%%date:~5,2%%date:~8,2%

set ymd_t=%ymd%_%time:~0,2%%time:~3,2%%time:~6,2%
set ymd_t=%ymd_t: =0%
echo ���п�ʼʱ�䣺%ymd_t% >> %ymd%_job1_log.txt
::���������
::::::::::::::::::::::
::���������
set ymd_t=%ymd%_%time:~0,2%%time:~3,2%%time:~6,2%
set ymd_t=%ymd_t: =0%
echo ���н���ʱ�䣺%ymd_t% >> %ymd%_job1_log.txt