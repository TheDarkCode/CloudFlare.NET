@SET config=%1
@IF ["%config%"] == [""] (
   SET config=Release
)

@CALL "%~dp0RestorePackages.cmd"

@CALL "%~dp0setmsbuild.cmd"

@echo %msbuild% /verbosity:m /t:Rebuild /p:Configuration="%config%"
@%msbuild% /verbosity:m /t:Rebuild /p:Configuration="%config%"
