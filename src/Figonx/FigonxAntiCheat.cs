using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectN;
using Dapplo.Windows.Common;
using System.Threading;

namespace Figonx
{
    public partial class FigonxAntiCheat : Form
    {
        public uint GetCurrentAdapterDirectX()
        {
            uint current_adapter = 0; //DirectX Current Adapter :D
            return current_adapter;
        }
        public HRESULT Direct3D9TakeScreenshots(uint adapter, int count)
        {
            using (var d3d = new ComObject<IDirect3D9>(Functions.Direct3DCreate9(Constants.D3D_SDK_VERSION)))
            {
                var mode = new _D3DDISPLAYMODE();
                d3d.Object.GetAdapterDisplayMode(adapter, ref mode).ThrowOnError();

                var parameters = new _D3DPRESENT_PARAMETERS_();
                parameters.Windowed = true;
                parameters.BackBufferCount = 1;
                parameters.BackBufferHeight = mode.Height;
                parameters.BackBufferWidth = mode.Width;
                parameters.SwapEffect = _D3DSWAPEFFECT.D3DSWAPEFFECT_DISCARD;
                //If you Have, DirectX12, Please Change to DirectX 9 :D
                d3d.Object.CreateDevice(adapter, _D3DDEVTYPE.D3DDEVTYPE_HAL, IntPtr.Zero, Constants.D3DCREATE_SOFTWARE_VERTEXPROCESSING, ref parameters, out var dev).ThrowOnError();
                using (var device = new ComObject<IDirect3DDevice9>(dev))
                {
                    dev.CreateOffscreenPlainSurface(mode.Width, mode.Height, _D3DFORMAT.D3DFMT_A8R8G8B8, _D3DPOOL.D3DPOOL_SYSTEMMEM, out var surf, IntPtr.Zero).ThrowOnError();
                    using (var surface = new ComObject<IDirect3DSurface9>(surf))
                    {
                        var rc = new _D3DLOCKED_RECT();
                        IntPtr rect = IntPtr.Zero;
                        surf.LockRect(ref rc, rect, 0).ThrowOnError();
                        var pitch = rc.Pitch;
                        surf.UnlockRect();

                        var shots = new byte[count][];
                        for (var i = 0; i < count; i++)
                        {
                            shots[i] = new byte[pitch * mode.Height];
                        }

                        var sw = new Stopwatch();
                        sw.Start();
                        for (var i = 0; i < count; i++)
                        {
                            dev.GetFrontBufferData(0, surf).ThrowOnError();
                            surf.LockRect(ref rc, rect, 0).ThrowOnError();
                            Marshal.Copy(rc.pBits, shots[i], 0, shots[i].Length);
                            surf.UnlockRect().ThrowOnError();
                        }
                        System.Windows.Forms.MessageBox.Show("Elapsed: " + sw.Elapsed);

                        for (var i = 0; i < count; i++)
                        {
                            SavePixelsToFile32bppPBGRA(mode.Width, mode.Height, (uint)pitch, shots[i], "temp" + i + ".jpg", WICConstants.GUID_ContainerFormatPng).ThrowOnError();
                        }
                    }
                }
            }
            return 0;
        }

        public HRESULT SavePixelsToFile32bppPBGRA(uint width, uint height, uint stride, byte[] pixels, string filePath, Guid format)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            using (var fac = new ComObject<IWICImagingFactory>((IWICImagingFactory)new WicImagingFactory()))
            {
                fac.Object.CreateStream(out var stream).ThrowOnError();
                using (new ComObject<IWICStream>(stream))
                {
                    const int GENERIC_WRITE = 0x40000000;
                    stream.InitializeFromFilename(filePath, GENERIC_WRITE).ThrowOnError();
                    fac.Object.CreateEncoder(format, IntPtr.Zero, out var encoder).ThrowOnError();
                    using (new ComObject<IWICBitmapEncoder>(encoder))
                    {
                        encoder.Initialize(stream, WICBitmapEncoderCacheOption.WICBitmapEncoderNoCache).ThrowOnError();
                        encoder.CreateNewFrame(out var frame, out var bag).ThrowOnError();
                        using (new ComObject<IWICBitmapFrameEncode>(frame))
                        {
                            frame.Initialize(null).ThrowOnError();
                            frame.SetSize(width, height).ThrowOnError();
                            frame.SetPixelFormat(ref format).ThrowOnError();
                            frame.WritePixels(height, stride, (int)(stride * height), pixels).ThrowOnError();
                            frame.Commit().ThrowOnError();
                            encoder.Commit().ThrowOnError();
                        }
                    }
                }
            }
            return 0;
        }
        public void SendAllDLLFiles(string dll_filepath)
        {

        }
        public bool CheckIfWin10IsExist()
        {
            if (WindowsVersion.IsWindows10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int GetCurrentID(string process)
        {
            int process_id = 0;
            Process[] proc = Process.GetProcessesByName(process);
            foreach(Process x in proc)
            {
                process_id = x.Id;
            }
            return process_id;
        }
        public bool CheckFolderCheatEngine()
        {
            if(Directory.Exists(@"C:\Program Files (x86)"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public FigonxAntiCheat()
        {
            uint current_adapter = 0; // Zero is Current Adapter of DirectX :D
            Directory.CreateDirectory(@"C:\Temp"); //Creating Temp Folder for Logging :D
            InitializeComponent();
            if (CheckIfWin10IsExist()) //This AntiCheat Required Windows 10 :D
            {
                System.Windows.Forms.MessageBox.Show("Windows 10 is Founded Succesfull");
            }
            else
            {
                System.Windows.MessageBox.Show("Windows 10 is Not Founded!!!");
                Environment.Exit(455);
            }
            ProcessStartInfo st = new ProcessStartInfo();
            st.FileName = @"C:\Games\Rust\RustStart.bat";
            st.Arguments = String.Empty;
            st.WindowStyle = ProcessWindowStyle.Normal;
            st.UseShellExecute = true;
            Process.Start(st);
        }

        private void FigonxAntiCheat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(3312);
        }

        private void takescreenshot_jpg_Tick(object sender, EventArgs e)
        {
            takescreenshot_jpg.Stop(); // Mission Successfully Completed :D
            Direct3D9TakeScreenshots(GetCurrentAdapterDirectX(), 1); //Taking Screenshot for Check Anyone Form of Anyone Cheat for RustClient :D
            jpg_delete.Start();
        }

        private void jpg_delete_Tick(object sender, EventArgs e)
        {
            jpg_delete.Stop();
            DirectoryInfo inf = new DirectoryInfo(@"C:\Games\Rust"); //RustClient :D
            FileInfo[] info = inf.GetFiles("*.jpg", SearchOption.AllDirectories); //Searching All Patterns of JPG Files And Deleting Them :D
            foreach(FileInfo fileinfo in info)
            {
                fileinfo.Delete(); //Deleting All JPG Files :D
            }
            takescreenshot_jpg.Start();
        }
    }
}
