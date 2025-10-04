@ECHO OFF
REM The following directory is for .NET 2.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v2.0.50727
set PATH=%PATH%;%DOTNETFX2%
echo Registering SMSMakinesi dll...
echo ---------------------------------------------------
Regsvr32 /s "D:\Aykut\AVPCallCenter\Asistan\bin\Debug\SMSMakinesi.dll"
echo ---------------------------------------------------
echo Installing AvukatproReminder Service...
echo ---------------------------------------------------
InstallUtil /i "D:\Aykut\AVPCallCenter\Asistan\bin\Debug\Avukatpro.Reminder.exe"
echo ---------------------------------------------------
echo Done.
