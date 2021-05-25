; �ýű�ʹ�� HM VNISEdit �ű��༭���򵼲���

; ��װ�����ʼ���峣��
!define PRODUCT_NAME "DynamicTest"
!define PRODUCT_VERSION "1.0"
!define PRODUCT_PUBLISHER "MEDATC, Inc."
!define PRODUCT_WEB_SITE "https://medatc.com"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\DynamicEnergyTest.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

SetCompressor lzma

; ------ MUI �ִ����涨�� (1.67 �汾���ϼ���) ------
!include "MUI.nsh"

; MUI Ԥ���峣��
!define MUI_ABORTWARNING
!define MUI_ICON "NSIS\FlushTool.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; ��ӭҳ��
!insertmacro MUI_PAGE_WELCOME
; ��װĿ¼ѡ��ҳ��
!insertmacro MUI_PAGE_DIRECTORY
; ��װ����ҳ��
!insertmacro MUI_PAGE_INSTFILES
; ��װ���ҳ��
!define MUI_FINISHPAGE_RUN "$INSTDIR\DynamicEnergyTest.exe"
!insertmacro MUI_PAGE_FINISH

; ��װж�ع���ҳ��
!insertmacro MUI_UNPAGE_INSTFILES

; ��װ�����������������
!insertmacro MUI_LANGUAGE "SimpChinese"

; ��װԤ�ͷ��ļ�
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
; ------ MUI �ִ����涨����� ------

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
  File "EXERoot\UID�б�.xls"
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
 *  �����ǰ�װ�����ж�ز���  *
 ******************************/

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\zh-CN\KoboldCom.resources.dll"
  Delete "$INSTDIR\x86\SQLite.Interop.dll"
  Delete "$INSTDIR\x64\SQLite.Interop.dll"
  Delete "$INSTDIR\UID�б�.xls"
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

#-- ���� NSIS �ű��༭�������� Function ���α�������� Section ����֮���д���Ա��ⰲװ�������δ��Ԥ֪�����⡣--#

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "��ȷʵҪ��ȫ�Ƴ� $(^Name) ���������е������" IDYES +2
  Abort
FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) �ѳɹ��ش���ļ�����Ƴ���"
FunctionEnd
