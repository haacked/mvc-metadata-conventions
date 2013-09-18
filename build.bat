@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
if "%nuget%" == "" (
   set nuget=.nuget\NuGet.exe
)


%nuget% pack ModelMetadataExtensions/ModelMetadataExtensions.csproj -Build -Symbols -Prop Configuration=%config%