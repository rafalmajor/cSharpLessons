@echo off

for /l %%i in (1, 1, 20) do (
  .\bin\Debug\BackgroudTasks.exe
  echo " "
)

@echo off