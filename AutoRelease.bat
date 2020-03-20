IF NOT EXIST natsuconv\. GOTO END
CLS
rem リリースして qrum します。
PAUSE

CALL ff
cx **

CD /D %~dp0.

IF NOT EXIST natsuconv\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\natsuconv.zip S:\リリース物\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END
