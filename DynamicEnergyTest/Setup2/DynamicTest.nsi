; 该脚本使用 HM VNISEdit 脚本编辑器向导产生

; 安装程序初始定义常量
!define PRODUCT_NAME "DynamicTest"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "MEDATC, Inc."
!define PRODUCT_WEB_SITE "https://medatc.com"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\DynamicEnergyTest.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI 现代界面定义 (1.67 版本以上兼容) ------
!include "MUI.nsh"

; MUI 预定义常量
!define MUI_ABORTWARNING
!define MUI_ICON "NSIS\FlushTool.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; 欢迎页面
!insertmacro MUI_PAGE_WELCOME
; 安装目录选择页面
!insertmacro MUI_PAGE_DIRECTORY
; 安装过程页面
!insertmacro MUI_PAGE_INSTFILES
; 安装完成页面
!define MUI_FINISHPAGE_RUN "$INSTDIR\DynamicEnergyTest.exe"
!insertmacro MUI_PAGE_FINISH

; 安装卸载过程页面
!insertmacro MUI_UNPAGE_INSTFILES

; 安装界面包含的语言设置
!insertmacro MUI_LANGUAGE "SimpChinese"

; 安装预释放文件
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI 现代界面定义结束 ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "Setup.exe"
InstallDir "$PROGRAMFILES\DynamicEnergyTest"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUnInstDetails show

Section "EXERoot" SEC01
  SetOutPath "$INSTDIR\Config"
  SetOverwrite ifnewer
  File "EXERoot\Config\BinAddressTable.json"
  File "EXERoot\Config\FlushConfig.json"
  File "EXERoot\Config\Paramaters.json"
  File "EXERoot\Config\ProcessItems.xml"
  File "EXERoot\Config\SerialPortSetting.json"
  SetOutPath "$INSTDIR\DataBase"
  File "EXERoot\DataBase\DynamicTest.db"
  File "EXERoot\DataBase\readme.txt"
  File "EXERoot\DataBase\sqdb.db"
  SetOutPath "$INSTDIR"
  File "EXERoot\DynamicEnergyTest.exe"
  CreateDirectory "$SMPROGRAMS\Dynamic"
  CreateShortCut "$SMPROGRAMS\Dynamic\DynamicTest.lnk" "$INSTDIR\DynamicEnergyTest.exe"
  CreateShortCut "$DESKTOP\DynamicTest.lnk" "$INSTDIR\DynamicEnergyTest.exe"
  File "EXERoot\DynamicEnergyTest.exe.config"
  File "EXERoot\DynamicEnergyTest.pdb"
  File "EXERoot\ExcelDataReader.DataSet.dll"
  File "EXERoot\ExcelDataReader.DataSet.pdb"
  File "EXERoot\ExcelDataReader.DataSet.xml"
  File "EXERoot\ExcelDataReader.dll"
  File "EXERoot\ExcelDataReader.pdb"
  File "EXERoot\ExcelDataReader.xml"
  File "EXERoot\fastJSON.dll"
  File "EXERoot\FastMember.dll"
  File "EXERoot\KoboldCom.dll"
  File "EXERoot\KoboldCom.pdb"
  File "EXERoot\Paramaters.xml"
  File "EXERoot\ProcessItems.xml"
  File "EXERoot\System.Data.SQLite.dll"
  SetOutPath "$INSTDIR\TestResult"
  File "EXERoot\TestResult\ReadMe.txt"
  SetOutPath "$INSTDIR"
  File "EXERoot\UID列表.xls"
  SetOutPath "$INSTDIR\x64"
  File "EXERoot\x64\SQLite.Interop.dll"
  SetOutPath "$INSTDIR\x86"
  File "EXERoot\x86\SQLite.Interop.dll"
  SetOutPath "$INSTDIR\zh-CN"
  File "EXERoot\zh-CN\KoboldCom.resources.dll"
SectionEnd

Section -AdditionalIcons
  SetOutPath $INSTDIR
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\Dynamic\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\Dynamic\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\DynamicEnergyTest.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\DynamicEnergyTest.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

/******************************
 *  以下是安装程序的卸载部分  *
 ******************************/

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\zh-CN\KoboldCom.resources.dll"
  Delete "$INSTDIR\x86\SQLite.Interop.dll"
  Delete "$INSTDIR\x64\SQLite.Interop.dll"
  Delete "$INSTDIR\UID列表.xls"
  Delete "$INSTDIR\TestResult\ReadMe.txt"
  Delete "$INSTDIR\System.Data.SQLite.dll"
  Delete "$INSTDIR\ProcessItems.xml"
  Delete "$INSTDIR\Paramaters.xml"
  Delete "$INSTDIR\KoboldCom.pdb"
  Delete "$INSTDIR\KoboldCom.dll"
  Delete "$INSTDIR\FastMember.dll"
  Delete "$INSTDIR\fastJSON.dll"
  Delete "$INSTDIR\ExcelDataReader.xml"
  Delete "$INSTDIR\ExcelDataReader.pdb"
  Delete "$INSTDIR\ExcelDataReader.dll"
  Delete "$INSTDIR\ExcelDataReader.DataSet.xml"
  Delete "$INSTDIR\ExcelDataReader.DataSet.pdb"
  Delete "$INSTDIR\ExcelDataReader.DataSet.dll"
  Delete "$INSTDIR\DynamicEnergyTest.pdb"
  Delete "$INSTDIR\DynamicEnergyTest.exe.config"
  Delete "$INSTDIR\DynamicEnergyTest.exe"
  Delete "$INSTDIR\DataBase\sqdb.db"
  Delete "$INSTDIR\DataBase\readme.txt"
  Delete "$INSTDIR\DataBase\DynamicTest.db"
  Delete "$INSTDIR\Config\SerialPortSetting.json"
  Delete "$INSTDIR\Config\ProcessItems.xml"
  Delete "$INSTDIR\Config\Paramaters.json"
  Delete "$INSTDIR\Config\FlushConfig.json"
  Delete "$INSTDIR\Config\BinAddressTable.json"

  Delete "$SMPROGRAMS\Dynamic\Uninstall.lnk"
  Delete "$SMPROGRAMS\Dynamic\Website.lnk"
  Delete "$DESKTOP\DynamicTest.lnk"
  Delete "$SMPROGRAMS\Dynamic\DynamicTest.lnk"

  RMDir "$SMPROGRAMS\Dynamic"
  RMDir "$INSTDIR\zh-CN"
  RMDir "$INSTDIR\x86"
  RMDir "$INSTDIR\x64"
  RMDir "$INSTDIR\TestResult"
  RMDir "$INSTDIR\DataBase"
  RMDir "$INSTDIR\Config"

  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd

#-- 根据 NSIS 脚本编辑规则，所有 Function 区段必须放置在 Section 区段之后编写，以避免安装程序出现未可预知的问题。--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "你确实要完全移除 $(^Name) ，及其所有的组件？" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) 已成功地从你的计算机移除。"
FunctionEnd
