echo off
pause
cd "C:\Automation\CSAutomation\CSAutomation\CSSelenium"
pause
::nunit3-console "C:\Automation\CSAutomation\CSAutomation\CSSelenium\bin\Debug\CSSelenium.dll" --where "cat == Test01_FindDropped"
::nunit3-console.exe .\bin\Debug\CSSelenium.dll  --where "cat == CSSelenium.Exercises.Exercise_Actions"
nunit3-console.exe .\bin\Debug\CSSelenium.dll --where "cat == Actions"
nunit3-console.exe .\bin\Debug\CSSelenium.dll --where "cat == Test01_FindDropped"
nunit3-console.exe "bin\Debug\CSSelenium.dll" --where "cat == cat == CSSelenium.Exercises.Exercise_Actions"
nunit3-console.exe .\bin\Debug\CSSelenium.dll --where "cat == ActionsNegative"
allure serve allure-results
pause
:: allure open "C:\Automation\CSAutomation\CSAutomation\allure-results"