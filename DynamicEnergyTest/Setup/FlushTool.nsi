; 该脚本使用 HM VNISEdit 脚本编辑器向导产生

; 安装程序初始定义常量
!define PRODUCT_NAME "FlushTool"
!define PRODUCT_VERSION "1.0.0"
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
; 组件选择页面
!insertmacro MUI_PAGE_COMPONENTS
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
InstallDir "$PROGRAMFILES\FlushTool"
InstallDirRegKey HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
ShowInstDetails show
ShowUnInstDetails show
BrandingText " "

Section "EXERoot" SEC01
  SetOutPath "$INSTDIR\Config"
  SetOverwrite ifnewer
  File "EXERoot\Config\BinAddressTable.json"
  ;File "EXERoot\Config\FlushBins.json"
  File "EXERoot\Config\FlushConfig.json"
  File "EXERoot\Config\Paramaters.json"
  File "EXERoot\Config\ProcessItems.xml"
  File "EXERoot\Config\SerialPortSetting.json"
  SetOutPath "$INSTDIR"
  File "EXERoot\DynamicEnergyTest.exe"
  CreateDirectory "$SMPROGRAMS\FlushTool"
  CreateShortCut "$SMPROGRAMS\FlushTool\FlushTool.lnk" "$INSTDIR\DynamicEnergyTest.exe"
  CreateShortCut "$DESKTOP\FlushTool.lnk" "$INSTDIR\DynamicEnergyTest.exe"
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
  CreateDirectory "C:\FlushTool\Firmware"
  SetOutPath "C:\FlushTool\Firmware"
  File "EXERoot\Firmware\bootloader.bin"
  File "EXERoot\Firmware\msocket.bin"
  File "EXERoot\Firmware\ota_data_initial.bin"
  File "EXERoot\Firmware\partitions_two_ota.bin"  
  SetOutPath "$INSTDIR\DataBase"
  File "EXERoot\DataBase\DynamicTest.db"
  File "EXERoot\DataBase\readme.txt"
  File "EXERoot\DataBase\sqdb.db"
  SetOutPath "$INSTDIR"
  File "EXERoot\KoboldCom.dll"
  File "EXERoot\KoboldCom.pdb"
  File "EXERoot\ProcessItems.xml"
  File "EXERoot\System.Data.SQLite.dll"
  SetOutPath "$INSTDIR\TestResult"
  File "EXERoot\TestResult\ReadMe.txt"
  SetOutPath "$INSTDIR\tool-esptool"
  File "EXERoot\tool-esptool\cxfreeze.zip"
  File "EXERoot\tool-esptool\ESP32py.ico"
  File "EXERoot\tool-esptool\espefuse.exe"
  File "EXERoot\tool-esptool\espefuse.py"
  File "EXERoot\tool-esptool\espefuse.spec"
  File "EXERoot\tool-esptool\espsecure.exe"
  File "EXERoot\tool-esptool\espsecure.py"
  File "EXERoot\tool-esptool\esptool.exe"
  File "EXERoot\tool-esptool\esptool.py"
  File "EXERoot\tool-esptool\gen_esp32part.exe"
  File "EXERoot\tool-esptool\gen_esp32part.py"
  SetOutPath "$INSTDIR\tool-esptool\lib\collections"
  File "EXERoot\tool-esptool\lib\collections\abc.pyc"
  File "EXERoot\tool-esptool\lib\collections\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\ctypes\macholib"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\dyld.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\dylib.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\fetch_macholib"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\fetch_macholib.bat"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\framework.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\README.ctypes"
  File "EXERoot\tool-esptool\lib\ctypes\macholib\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\ctypes"
  File "EXERoot\tool-esptool\lib\ctypes\util.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\wintypes.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\_aix.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\_endian.pyc"
  File "EXERoot\tool-esptool\lib\ctypes\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\ecdsa"
  File "EXERoot\tool-esptool\lib\ecdsa\curves.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\der.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\ecdsa.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\ellipticcurve.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\keys.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\numbertheory.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\rfc6979.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\six.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\util.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\_version.pyc"
  File "EXERoot\tool-esptool\lib\ecdsa\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\email"
  File "EXERoot\tool-esptool\lib\email\architecture.rst"
  File "EXERoot\tool-esptool\lib\email\base64mime.pyc"
  File "EXERoot\tool-esptool\lib\email\charset.pyc"
  File "EXERoot\tool-esptool\lib\email\contentmanager.pyc"
  File "EXERoot\tool-esptool\lib\email\encoders.pyc"
  File "EXERoot\tool-esptool\lib\email\errors.pyc"
  File "EXERoot\tool-esptool\lib\email\feedparser.pyc"
  File "EXERoot\tool-esptool\lib\email\generator.pyc"
  File "EXERoot\tool-esptool\lib\email\header.pyc"
  File "EXERoot\tool-esptool\lib\email\headerregistry.pyc"
  File "EXERoot\tool-esptool\lib\email\iterators.pyc"
  File "EXERoot\tool-esptool\lib\email\message.pyc"
  File "EXERoot\tool-esptool\lib\email\parser.pyc"
  File "EXERoot\tool-esptool\lib\email\policy.pyc"
  File "EXERoot\tool-esptool\lib\email\quoprimime.pyc"
  File "EXERoot\tool-esptool\lib\email\utils.pyc"
  File "EXERoot\tool-esptool\lib\email\_encoded_words.pyc"
  File "EXERoot\tool-esptool\lib\email\_header_value_parser.pyc"
  File "EXERoot\tool-esptool\lib\email\_parseaddr.pyc"
  File "EXERoot\tool-esptool\lib\email\_policybase.pyc"
  File "EXERoot\tool-esptool\lib\email\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\encodings"
  File "EXERoot\tool-esptool\lib\encodings\aliases.pyc"
  File "EXERoot\tool-esptool\lib\encodings\ascii.pyc"
  File "EXERoot\tool-esptool\lib\encodings\base64_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\big5.pyc"
  File "EXERoot\tool-esptool\lib\encodings\big5hkscs.pyc"
  File "EXERoot\tool-esptool\lib\encodings\bz2_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\charmap.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp037.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1006.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1026.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1125.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1140.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1250.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1251.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1252.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1253.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1254.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1255.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1256.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1257.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp1258.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp273.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp424.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp437.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp500.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp65001.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp720.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp737.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp775.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp850.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp852.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp855.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp856.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp857.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp858.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp860.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp861.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp862.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp863.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp864.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp865.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp866.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp869.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp874.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp875.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp932.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp949.pyc"
  File "EXERoot\tool-esptool\lib\encodings\cp950.pyc"
  File "EXERoot\tool-esptool\lib\encodings\euc_jisx0213.pyc"
  File "EXERoot\tool-esptool\lib\encodings\euc_jis_2004.pyc"
  File "EXERoot\tool-esptool\lib\encodings\euc_jp.pyc"
  File "EXERoot\tool-esptool\lib\encodings\euc_kr.pyc"
  File "EXERoot\tool-esptool\lib\encodings\gb18030.pyc"
  File "EXERoot\tool-esptool\lib\encodings\gb2312.pyc"
  File "EXERoot\tool-esptool\lib\encodings\gbk.pyc"
  File "EXERoot\tool-esptool\lib\encodings\hex_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\hp_roman8.pyc"
  File "EXERoot\tool-esptool\lib\encodings\hz.pyc"
  File "EXERoot\tool-esptool\lib\encodings\idna.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp_1.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp_2.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp_2004.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp_3.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_jp_ext.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso2022_kr.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_1.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_10.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_11.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_13.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_14.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_15.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_16.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_2.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_3.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_4.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_5.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_6.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_7.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_8.pyc"
  File "EXERoot\tool-esptool\lib\encodings\iso8859_9.pyc"
  File "EXERoot\tool-esptool\lib\encodings\johab.pyc"
  File "EXERoot\tool-esptool\lib\encodings\koi8_r.pyc"
  File "EXERoot\tool-esptool\lib\encodings\koi8_t.pyc"
  File "EXERoot\tool-esptool\lib\encodings\koi8_u.pyc"
  File "EXERoot\tool-esptool\lib\encodings\kz1048.pyc"
  File "EXERoot\tool-esptool\lib\encodings\latin_1.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_arabic.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_centeuro.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_croatian.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_cyrillic.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_farsi.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_greek.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_iceland.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_latin2.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_roman.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_romanian.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mac_turkish.pyc"
  File "EXERoot\tool-esptool\lib\encodings\mbcs.pyc"
  File "EXERoot\tool-esptool\lib\encodings\oem.pyc"
  File "EXERoot\tool-esptool\lib\encodings\palmos.pyc"
  File "EXERoot\tool-esptool\lib\encodings\ptcp154.pyc"
  File "EXERoot\tool-esptool\lib\encodings\punycode.pyc"
  File "EXERoot\tool-esptool\lib\encodings\quopri_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\raw_unicode_escape.pyc"
  File "EXERoot\tool-esptool\lib\encodings\rot_13.pyc"
  File "EXERoot\tool-esptool\lib\encodings\shift_jis.pyc"
  File "EXERoot\tool-esptool\lib\encodings\shift_jisx0213.pyc"
  File "EXERoot\tool-esptool\lib\encodings\shift_jis_2004.pyc"
  File "EXERoot\tool-esptool\lib\encodings\tis_620.pyc"
  File "EXERoot\tool-esptool\lib\encodings\undefined.pyc"
  File "EXERoot\tool-esptool\lib\encodings\unicode_escape.pyc"
  File "EXERoot\tool-esptool\lib\encodings\unicode_internal.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_16.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_16_be.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_16_le.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_32.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_32_be.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_32_le.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_7.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_8.pyc"
  File "EXERoot\tool-esptool\lib\encodings\utf_8_sig.pyc"
  File "EXERoot\tool-esptool\lib\encodings\uu_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\zlib_codec.pyc"
  File "EXERoot\tool-esptool\lib\encodings\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\html"
  File "EXERoot\tool-esptool\lib\html\entities.pyc"
  File "EXERoot\tool-esptool\lib\html\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\http"
  File "EXERoot\tool-esptool\lib\http\client.pyc"
  File "EXERoot\tool-esptool\lib\http\server.pyc"
  File "EXERoot\tool-esptool\lib\http\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\idna"
  File "EXERoot\tool-esptool\lib\idna\codec.pyc"
  File "EXERoot\tool-esptool\lib\idna\compat.pyc"
  File "EXERoot\tool-esptool\lib\idna\core.pyc"
  File "EXERoot\tool-esptool\lib\idna\idnadata.pyc"
  File "EXERoot\tool-esptool\lib\idna\intranges.pyc"
  File "EXERoot\tool-esptool\lib\idna\package_data.pyc"
  File "EXERoot\tool-esptool\lib\idna\uts46data.pyc"
  File "EXERoot\tool-esptool\lib\idna\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\importlib"
  File "EXERoot\tool-esptool\lib\importlib\abc.pyc"
  File "EXERoot\tool-esptool\lib\importlib\machinery.pyc"
  File "EXERoot\tool-esptool\lib\importlib\util.pyc"
  File "EXERoot\tool-esptool\lib\importlib\_bootstrap.pyc"
  File "EXERoot\tool-esptool\lib\importlib\_bootstrap_external.pyc"
  File "EXERoot\tool-esptool\lib\importlib\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\json"
  File "EXERoot\tool-esptool\lib\json\decoder.pyc"
  File "EXERoot\tool-esptool\lib\json\encoder.pyc"
  File "EXERoot\tool-esptool\lib\json\scanner.pyc"
  File "EXERoot\tool-esptool\lib\json\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib"
  File "EXERoot\tool-esptool\lib\libcrypto-1_1.dll"
  File "EXERoot\tool-esptool\lib\library.zip"
  File "EXERoot\tool-esptool\lib\libssl-1_1.dll"
  SetOutPath "$INSTDIR\tool-esptool\lib\logging"
  File "EXERoot\tool-esptool\lib\logging\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\pyaes"
  File "EXERoot\tool-esptool\lib\pyaes\aes.pyc"
  File "EXERoot\tool-esptool\lib\pyaes\blockfeeder.pyc"
  File "EXERoot\tool-esptool\lib\pyaes\util.pyc"
  File "EXERoot\tool-esptool\lib\pyaes\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\pydoc_data"
  File "EXERoot\tool-esptool\lib\pydoc_data\topics.pyc"
  File "EXERoot\tool-esptool\lib\pydoc_data\_pydoc.css"
  File "EXERoot\tool-esptool\lib\pydoc_data\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib"
  File "EXERoot\tool-esptool\lib\pyexpat.pyd"
  File "EXERoot\tool-esptool\lib\select.pyd"
  SetOutPath "$INSTDIR\tool-esptool\lib\serial"
  File "EXERoot\tool-esptool\lib\serial\serialcli.pyc"
  File "EXERoot\tool-esptool\lib\serial\serialjava.pyc"
  File "EXERoot\tool-esptool\lib\serial\serialposix.pyc"
  File "EXERoot\tool-esptool\lib\serial\serialutil.pyc"
  File "EXERoot\tool-esptool\lib\serial\serialwin32.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\serial\tools"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports_common.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports_linux.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports_osx.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports_posix.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\list_ports_windows.pyc"
  File "EXERoot\tool-esptool\lib\serial\tools\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\serial"
  File "EXERoot\tool-esptool\lib\serial\win32.pyc"
  File "EXERoot\tool-esptool\lib\serial\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib"
  File "EXERoot\tool-esptool\lib\unicodedata.pyd"
  SetOutPath "$INSTDIR\tool-esptool\lib\unittest"
  File "EXERoot\tool-esptool\lib\unittest\case.pyc"
  File "EXERoot\tool-esptool\lib\unittest\loader.pyc"
  File "EXERoot\tool-esptool\lib\unittest\main.pyc"
  File "EXERoot\tool-esptool\lib\unittest\result.pyc"
  File "EXERoot\tool-esptool\lib\unittest\runner.pyc"
  File "EXERoot\tool-esptool\lib\unittest\signals.pyc"
  File "EXERoot\tool-esptool\lib\unittest\suite.pyc"
  File "EXERoot\tool-esptool\lib\unittest\util.pyc"
  File "EXERoot\tool-esptool\lib\unittest\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\urllib"
  File "EXERoot\tool-esptool\lib\urllib\parse.pyc"
  File "EXERoot\tool-esptool\lib\urllib\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\xml\parsers"
  File "EXERoot\tool-esptool\lib\xml\parsers\expat.pyc"
  File "EXERoot\tool-esptool\lib\xml\parsers\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib\xml"
  File "EXERoot\tool-esptool\lib\xml\__init__.pyc"
  SetOutPath "$INSTDIR\tool-esptool\lib"
  File "EXERoot\tool-esptool\lib\_bz2.pyd"
  File "EXERoot\tool-esptool\lib\_ctypes.pyd"
  File "EXERoot\tool-esptool\lib\_hashlib.pyd"
  File "EXERoot\tool-esptool\lib\_lzma.pyd"
  File "EXERoot\tool-esptool\lib\_socket.pyd"
  File "EXERoot\tool-esptool\lib\_ssl.pyd"
  SetOutPath "$INSTDIR\tool-esptool"
  File "EXERoot\tool-esptool\parttool.exe"
  File "EXERoot\tool-esptool\parttool.py"
  File "EXERoot\tool-esptool\python37.dll"
  File "EXERoot\tool-esptool\setup_esp.py"
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
  CreateShortCut "$SMPROGRAMS\FlushTool\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\FlushTool\Uninstall.lnk" "$INSTDIR\uninst.exe"
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

#-- 根据 NSIS 脚本编辑规则，所有 Function 区段必须放置在 Section 区段之后编写，以避免安装程序出现未可预知的问题。--#

; 区段组件描述
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC01} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

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
  Delete "$INSTDIR\tool-esptool\setup_esp.py"
  Delete "$INSTDIR\tool-esptool\python37.dll"
  Delete "$INSTDIR\tool-esptool\parttool.py"
  Delete "$INSTDIR\tool-esptool\parttool.exe"
  Delete "$INSTDIR\tool-esptool\lib\_ssl.pyd"
  Delete "$INSTDIR\tool-esptool\lib\_socket.pyd"
  Delete "$INSTDIR\tool-esptool\lib\_lzma.pyd"
  Delete "$INSTDIR\tool-esptool\lib\_hashlib.pyd"
  Delete "$INSTDIR\tool-esptool\lib\_ctypes.pyd"
  Delete "$INSTDIR\tool-esptool\lib\_bz2.pyd"
  Delete "$INSTDIR\tool-esptool\lib\xml\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\xml\parsers\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\xml\parsers\expat.pyc"
  Delete "$INSTDIR\tool-esptool\lib\urllib\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\urllib\parse.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\util.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\suite.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\signals.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\runner.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\result.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\main.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\loader.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unittest\case.pyc"
  Delete "$INSTDIR\tool-esptool\lib\unicodedata.pyd"
  Delete "$INSTDIR\tool-esptool\lib\serial\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\win32.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports_windows.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports_posix.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports_osx.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports_linux.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports_common.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\tools\list_ports.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\serialwin32.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\serialutil.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\serialposix.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\serialjava.pyc"
  Delete "$INSTDIR\tool-esptool\lib\serial\serialcli.pyc"
  Delete "$INSTDIR\tool-esptool\lib\select.pyd"
  Delete "$INSTDIR\tool-esptool\lib\pyexpat.pyd"
  Delete "$INSTDIR\tool-esptool\lib\pydoc_data\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\pydoc_data\_pydoc.css"
  Delete "$INSTDIR\tool-esptool\lib\pydoc_data\topics.pyc"
  Delete "$INSTDIR\tool-esptool\lib\pyaes\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\pyaes\util.pyc"
  Delete "$INSTDIR\tool-esptool\lib\pyaes\blockfeeder.pyc"
  Delete "$INSTDIR\tool-esptool\lib\pyaes\aes.pyc"
  Delete "$INSTDIR\tool-esptool\lib\logging\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\libssl-1_1.dll"
  Delete "$INSTDIR\tool-esptool\lib\library.zip"
  Delete "$INSTDIR\tool-esptool\lib\libcrypto-1_1.dll"
  Delete "$INSTDIR\tool-esptool\lib\json\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\json\scanner.pyc"
  Delete "$INSTDIR\tool-esptool\lib\json\encoder.pyc"
  Delete "$INSTDIR\tool-esptool\lib\json\decoder.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\_bootstrap_external.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\_bootstrap.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\util.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\machinery.pyc"
  Delete "$INSTDIR\tool-esptool\lib\importlib\abc.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\uts46data.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\package_data.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\intranges.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\idnadata.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\core.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\compat.pyc"
  Delete "$INSTDIR\tool-esptool\lib\idna\codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\http\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\http\server.pyc"
  Delete "$INSTDIR\tool-esptool\lib\http\client.pyc"
  Delete "$INSTDIR\tool-esptool\lib\html\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\html\entities.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\zlib_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\uu_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_8_sig.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_8.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_7.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_32_le.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_32_be.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_32.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_16_le.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_16_be.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\utf_16.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\unicode_internal.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\unicode_escape.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\undefined.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\tis_620.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\shift_jis_2004.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\shift_jisx0213.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\shift_jis.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\rot_13.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\raw_unicode_escape.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\quopri_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\punycode.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\ptcp154.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\palmos.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\oem.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mbcs.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_turkish.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_romanian.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_roman.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_latin2.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_iceland.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_greek.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_farsi.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_cyrillic.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_croatian.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_centeuro.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\mac_arabic.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\latin_1.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\kz1048.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\koi8_u.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\koi8_t.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\koi8_r.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\johab.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_9.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_8.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_7.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_6.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_5.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_4.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_3.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_2.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_16.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_15.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_14.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_13.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_11.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_10.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso8859_1.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_kr.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp_ext.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp_3.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp_2004.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp_2.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp_1.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\iso2022_jp.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\idna.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\hz.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\hp_roman8.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\hex_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\gbk.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\gb2312.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\gb18030.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\euc_kr.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\euc_jp.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\euc_jis_2004.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\euc_jisx0213.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp950.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp949.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp932.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp875.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp874.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp869.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp866.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp865.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp864.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp863.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp862.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp861.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp860.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp858.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp857.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp856.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp855.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp852.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp850.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp775.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp737.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp720.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp65001.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp500.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp437.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp424.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp273.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1258.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1257.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1256.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1255.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1254.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1253.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1252.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1251.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1250.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1140.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1125.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1026.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp1006.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\cp037.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\charmap.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\bz2_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\big5hkscs.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\big5.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\base64_codec.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\ascii.pyc"
  Delete "$INSTDIR\tool-esptool\lib\encodings\aliases.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\_policybase.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\_parseaddr.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\_header_value_parser.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\_encoded_words.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\utils.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\quoprimime.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\policy.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\parser.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\message.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\iterators.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\headerregistry.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\header.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\generator.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\feedparser.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\errors.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\encoders.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\contentmanager.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\charset.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\base64mime.pyc"
  Delete "$INSTDIR\tool-esptool\lib\email\architecture.rst"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\_version.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\util.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\six.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\rfc6979.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\numbertheory.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\keys.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\ellipticcurve.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\ecdsa.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\der.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ecdsa\curves.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\_endian.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\_aix.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\wintypes.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\util.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\README.ctypes"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\framework.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\fetch_macholib.bat"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\fetch_macholib"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\dylib.pyc"
  Delete "$INSTDIR\tool-esptool\lib\ctypes\macholib\dyld.pyc"
  Delete "$INSTDIR\tool-esptool\lib\collections\__init__.pyc"
  Delete "$INSTDIR\tool-esptool\lib\collections\abc.pyc"
  Delete "$INSTDIR\tool-esptool\gen_esp32part.py"
  Delete "$INSTDIR\tool-esptool\gen_esp32part.exe"
  Delete "$INSTDIR\tool-esptool\esptool.py"
  Delete "$INSTDIR\tool-esptool\esptool.exe"
  Delete "$INSTDIR\tool-esptool\espsecure.py"
  Delete "$INSTDIR\tool-esptool\espsecure.exe"
  Delete "$INSTDIR\tool-esptool\espefuse.spec"
  Delete "$INSTDIR\tool-esptool\espefuse.py"
  Delete "$INSTDIR\tool-esptool\espefuse.exe"
  Delete "$INSTDIR\tool-esptool\ESP32py.ico"
  Delete "$INSTDIR\tool-esptool\cxfreeze.zip"
  Delete "$INSTDIR\TestResult\ReadMe.txt"
  Delete "$INSTDIR\System.Data.SQLite.dll"
  Delete "$INSTDIR\ProcessItems.xml"
  Delete "$INSTDIR\KoboldCom.pdb"
  Delete "$INSTDIR\KoboldCom.dll"
  Delete "$INSTDIR\DataBase\sqdb.db"
  Delete "$INSTDIR\DataBase\readme.txt"
  Delete "C:\FlushTool\Firmware\partitions_two_ota.bin"
  Delete "C:\FlushTool\Firmware\ota_data_initial.bin"
  Delete "C:\FlushTool\Firmware\msocket.bin"
  Delete "$INSTDIR\DataBase\DynamicTest.db"
  Delete "C:\FlushTool\Firmware\bootloader.bin"
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
  Delete "$INSTDIR\Config\SerialPortSetting.json"
  Delete "$INSTDIR\Config\ProcessItems.xml"
  Delete "$INSTDIR\Config\Paramaters.json"
  Delete "$INSTDIR\Config\FlushConfig.json"
  ;Delete "$INSTDIR\Config\FlushBins.json"
  Delete "$INSTDIR\Config\BinAddressTable.json"

  Delete "$SMPROGRAMS\FlushTool\Uninstall.lnk"
  Delete "$SMPROGRAMS\FlushTool\Website.lnk"
  Delete "$DESKTOP\FlushTool.lnk"
  Delete "$SMPROGRAMS\FlushTool\FlushTool.lnk"

  RMDir "$SMPROGRAMS\FlushTool"
  RMDir "$INSTDIR\zh-CN"
  RMDir "$INSTDIR\x86"
  RMDir "$INSTDIR\x64"
  RMDir "$INSTDIR\tool-esptool\lib\xml\parsers"
  RMDir "$INSTDIR\tool-esptool\lib\xml"
  RMDir "$INSTDIR\tool-esptool\lib\urllib"
  RMDir "$INSTDIR\tool-esptool\lib\unittest"
  RMDir "$INSTDIR\tool-esptool\lib\serial\tools"
  RMDir "$INSTDIR\tool-esptool\lib\serial"
  RMDir "$INSTDIR\tool-esptool\lib\pydoc_data"
  RMDir "$INSTDIR\tool-esptool\lib\pyaes"
  RMDir "$INSTDIR\tool-esptool\lib\logging"
  RMDir "$INSTDIR\tool-esptool\lib\json"
  RMDir "$INSTDIR\tool-esptool\lib\importlib"
  RMDir "$INSTDIR\tool-esptool\lib\idna"
  RMDir "$INSTDIR\tool-esptool\lib\http"
  RMDir "$INSTDIR\tool-esptool\lib\html"
  RMDir "$INSTDIR\tool-esptool\lib\encodings"
  RMDir "$INSTDIR\tool-esptool\lib\email"
  RMDir "$INSTDIR\tool-esptool\lib\ecdsa"
  RMDir "$INSTDIR\tool-esptool\lib\ctypes\macholib"
  RMDir "$INSTDIR\tool-esptool\lib\ctypes"
  RMDir "$INSTDIR\tool-esptool\lib\collections"
  RMDir "$INSTDIR\tool-esptool\lib"
  RMDir "$INSTDIR\tool-esptool"
  RMDir "$INSTDIR\TestResult"
  RMDir "$INSTDIR\Firmware"
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
