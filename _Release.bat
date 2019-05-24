C:\Factory\Tools\RDMD.exe /RC out

COPY /B natsuconv\natsuconv\bin\Release\natsuconv.exe out
COPY /B C:\Factory\Program\WavMaster\Master.exe out

C:\Factory\Tools\xcp.exe doc out
ren out\Readme.txt ƒ}ƒjƒ…ƒAƒ‹.txt

C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Master.exe

C:\Factory\SubTools\zip.exe /O out natsuconv

PAUSE
