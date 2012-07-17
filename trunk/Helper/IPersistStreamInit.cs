using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Jade
{
    [ComVisible(true), ComImport(), Guid("7FD52380-4E07-101B-AE2D-08002B2EC713"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStreamInit
    {
        void GetClassID([In, Out] ref Guid pClassID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();

        void Load([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream pstm);

        void Save([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream pstm, [In, MarshalAs(UnmanagedType.I4)] int fClearDirty);

        void GetSizeMax([Out, MarshalAs(UnmanagedType.LPArray)] long pcbSize);

        void InitNew();
    }
}
