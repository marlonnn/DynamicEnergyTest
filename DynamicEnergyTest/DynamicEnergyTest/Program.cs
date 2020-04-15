﻿using DynamicEnergyTest.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DynamicEnergyTest
{
    static class Program
    {
        private static ProtocolFactory _protocolsFactory;
        public static ProtocolFactory ProtocolsFactory
        {
            get { return _protocolsFactory; }
            set { _protocolsFactory = value; }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary
        [STAThread]
        static void Main()
        {
            ProtocolsFactory = ProtocolFactory.GetFactory();
            //var dataModels = ProtocolsFactory.DataModels;
            //foreach (var key in dataModels.Keys)
            //{
            //    var model = dataModels[key];
            //    var bytes = model.Encode();
            //    var readableString = ByteHelper.Byte2ReadalbeXstring(bytes);
            //    Console.WriteLine(readableString);

            //    byte[] funCode = new byte[4];
            //    Array.Copy(bytes, 8, funCode, 0, 4);
            //    var v1 = BitConverter.ToInt32(funCode, 0);
            //    //var v2 = GetLittleEndianIntegerFromByteArray(funCode, 0);
            //    //var v3 = GetBigEndianIntegerFromByteArray(funCode, 0);

            //    HexProtocol hexProtocol = new HexProtocol();
            //    hexProtocol.SearchBuffer(bytes.ToList());
            //    hexProtocol.Analyze();
            //    model.Decode(hexProtocol.Data.DataRegion);
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new Form1());
        }
    }
}
