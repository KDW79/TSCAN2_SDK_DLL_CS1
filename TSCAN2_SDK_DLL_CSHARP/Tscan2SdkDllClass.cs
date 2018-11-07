using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TSCAN2_SDK_DLL_CSHARP
{
    public enum Tscan2_ErrorCode
    {
        SUCCESS = 0x100,
        FAIL = 0X200,
        INVALID_DB = 0x300,
        NOT_SUPPORT = 0x400,
        INVALID_RESPONSE = 0x500,
        NO_RESPONSE = 0x540,
        PORTOPEN_FAIL = 0x600,
        INVALID_PCREQUEST = 0x900,
        ERROR_WORKING = 0x1000,
        ERROR_NOT_COMMOPEN = 0x1100,
        VCI_NOT_CONNECTED_YET = 0x1400,
        INVALID_VCI_OBJECT = 0x1500,
        ERR_INITIALIZED_ALREADY = 0x1600,
        ERR_INITIALIZE = 0x1700,
        ERR_NOT_INITIALIZED = 0x1800,
        VCI_ALREADY_CREATED = 0x1900,
        INVALID_FUNC_DB = 0x2000,
        INVALID_PCOPERATION = 0x2100,
        NO_PARAMETER = 0x2300,
        ERR_ALREADY_ASSIGNED = 0x2700,
        NEGATIVE_RESPONSE = 0x4000,
        INTERNAL_DB_PARSING_ERROR = 0x100000
    }

    public enum Tscan2_AuxResultCodes
    {
        AUX_RESULT_OK = 1000,
        AUX_RESULT_NG = 2000,
        AUX_NOT_CONDITION = 2002,
        AUX_PROGRAM_ERROR = 4000,
        AUX_NOT_SUPPORT = 5000,
        AUX_COMMERROR = 6000,
        AUX_NO_PARAMETER = 8000,
        AUX_FUNC_STOP = 9000
    }

    public enum Tscan2_InternalErrorCodes
    {
        FAIL_DLL_INIT = 1000000,
        RECV_ERROR = 1000001,
        RECV_TIMEOUT = 1000002,
        RECV_ERR_CANCEL = 1000003,
        RECV_ERR_DISCONNECTED = 1000004,
        NOT_SET_CONFIG = 1000005,
        INVALID_RES_CANID = 1000008,
        NOT_ENOUGH_BUFFER = 1000009,
        ERR_TERMINATE_THREAD = 1000010,
        RECV_PENDING = 1000014,
        RECV_REPEAT_BUSY = 1000015,
        RECV_CAN_TIMEOUT = 1000020,
        RECV_KLINE_TIMEOUT = 1000021
    }

    public enum Tscan2_ProtocolError
    {
        RECEIVED_NAK = -200,
        RECEIVED_WRONG_PACKET = -201,
        RECEIVED_UNMATCHED_CMD = -202,
        NEED_SET_RTC = -203,
        RECEIVED_INVALID_PACKET = -204
    }

    public enum Tscan2_TcpIpSetError
    {
        REG_SET_TCP_ALREADY = 0x3000,
        REG_SET_TCP_SUCCESS = 0x3100,
        REG_SET_TCP_FAIL = 0x3200
    }

    public class Tscan2_SdkDll_CSharp
    {

    }

    public class Tscan2_DIO_SdkDll_CSharp
    {
        //DLL Import 시 타입 변경
        //LPCSTR = byte[]
        //HWND = IntPtr
        //LPVOID = IntPtr
        //LPVOID* = ref IntPtr
        //USHORT = ushort
        //LPTSTR = StringBuilder
        //LPBYTE = byte[]

        public struct Tscan2_DIO_SdkDll_Parameter
        {
            public IntPtr pObject;
            public int nElementCount;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public String strTest;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] CheckDI_pBuf;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] ControlDO_pBuf;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] pLogFilePath;

            public int nErrorCode;

        }

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_DeInitInlineSdk();

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_ReleaseDIO(IntPtr pObject);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_IsClientConnected(IntPtr pObject, bool bConnected);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_CheckDI(IntPtr pObject, int nElementCount, byte[] pBuf);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_ControlDO(IntPtr pObject, int nElementCount, byte[] pBuf);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_InitInlineSdkA(byte[] pRootPath, IntPtr hAppWnd, ushort nPort = 16822, bool bInterruptYn = true); // need to add information of socket`s port

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_SetSDKDllLogFilePathA(byte[] pLogFilePath);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_GetDIOInfoA(IntPtr pObject, StringBuilder pID, StringBuilder pDIOVer);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_CreateDIOA(byte[] pDIOName, byte[] pIP, IntPtr hWnd, IntPtr pContext, ref IntPtr pObject);

        [DllImport("DIOSDK.dll", CharSet = CharSet.Auto)]
        public static extern int DIO_GetSDKErrorStringA(int nErrorCode, StringBuilder pErrorString);

    }
}
