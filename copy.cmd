@echo off
echo *******************************
echo      ��ʼ�����ļ�
echo *******************************
pause
xcopy .\exe ..\..\..\ʵ��\CSharp���\AutoFrame\exe\ /e /f /y
xcopy .\AutoFrame ..\..\..\ʵ��\CSharp���\AutoFrame\AutoFrame\ /e /f /y
xcopy .\AutoFrameVision ..\..\..\ʵ��\CSharp���\AutoFrame\AutoFrameVision\ /e /f /y
xcopy .\Communicate ..\..\..\ʵ��\CSharp���\AutoFrame\Communicate\ /e /f /y
xcopy .\MotionIO ..\..\..\ʵ��\CSharp���\AutoFrame\MotionIO\ /e /f /y
xcopy .\Plc ..\..\..\ʵ��\CSharp���\AutoFrame\Plc\ /e /f /y
xcopy .\ToolEx ..\..\..\ʵ��\CSharp���\AutoFrame\ToolEx\ /e /f /y
xcopy .\packages ..\..\..\ʵ��\CSharp���\AutoFrame\packages\ /e /f /y
copy .\����˵��.txt ..\..\..\ʵ��\CSharp���\ /y
pause
