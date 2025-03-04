﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoFrameDll;
using CommonTool;
using ToolEx;
using Communicate;
using System.Reflection;
using System.IO;

namespace AutoFrame
{
    class StationTest : StationEx
    {
        enum POINT
        {
            安全点,
        }
        /// <summary>
        /// 构造函数，需要设置站位当前的IO输入，IO输出，轴方向及轴名称，以显示在手动页面方便操作
        /// </summary>
        /// <param name="strName"></param>
        public StationTest(string strName, string strEnName) : base(strName, strEnName)
        {

            //配置站位界面显示输入
            io_in = new string[] { "启动", "复位" };
            //配置站位界面显示输出
            io_out = new string[] { "红灯", "绿灯" };
            //配置站位界面显示气缸
            m_cylinders = new string[] { "压料顶升气缸" };

            //配置手动调试时的伺服的运动方向，如果发现界面上的方向和实际的方向相反，则把对应的轴的方向改为false
            InverseAxisPositiveByIndex(2);

            //给轴重命名
            RenameAxisName(4, "X1");
            RenameAxisName(5, "Y1");
            RenameAxisName(6, "Z1");
            RenameAxisName(7, "U1");
        }
        /// <summary>
        /// 站位初始化，用来添加伺服上电，打开网口，站位回原点等动作
        /// </summary>
        public override void StationInit()
        {
            base.StationInit();//请在此语句下方增加代码

            //设置位寄存器状态

            DialogResult a = Alarm("M99IPDE-01-02", LightState.蜂鸣开 | LightState.黄灯开);





            ShowLog("初始化完成", LogLevel.Info, "Initialization is complete");
        }
        /// <summary>
        /// 站位退出退程时调用，用来关闭伺服，关闭网口等动作
        /// </summary>
        public override void StationDeinit()
        {
            //增加代码



            base.StationDeinit();
        }

        //当所有站位均为全自动运行模式时，不需要重载该函数
        //当所有站位为半自动运行模式时，也不需要重载该函数， 只需要在站位流程开始时插入WaitBegin()即可保证所有站位同步开始。
        //当所有站位中，有的为半自动，有的为全自动时，半自动的站位不重载该函数，使用WaitBegin()控制同步，全自动的站位重载该函数返回true即可。
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public override bool IsReady()
        //{
        //    return true;
        //}


        /// <summary>
        /// 初始化时设置站位安全状态，用来设备初始化时各站位之间相互卡站，
        /// 控制各站位先后动作顺序用，比如流水线组装，肯定需要组装的Z轴升
        /// 起后，流水线才能动作这种情况
        /// </summary>
        public override void InitSecurityState()
        {
            //
            base.InitSecurityState();//请在此语句上方增加代码
        }
        public override void EmgStop()
        {
            //
            base.EmgStop();
        }
        public override void OnPause()
        {
            //
            base.OnPause();
        }
        public override void OnResume()
        {
            //
            base.OnResume();
        }
        /// <summary>
        /// 正常运行
        /// </summary>
        protected override void NormalRun()
        {
            ShowLog("Info", LogLevel.Info, "Info");
            WaitTimeDelay(500);
            ShowLog("Warning", LogLevel.Warn, "Warning");
            //WaitTimeDelay(500);
            ShowLog("Error", LogLevel.Error, "Error");
            //WaitTimeDelay(500);

            //StationMgrEx.Notify("等待信号", new WaitSignal(Signal.RegBit, (int)SysBitReg.最终结果, true));

            //WaitRegBit((int)SysBitReg.最终结果, true);
            //Thread.Sleep(1000);
            //SetBit(SysBitReg.最终结果, false);

            ShowLog("本站完成", LogLevel.Info, "This station completed");
        }

        /// <summary>
        /// 空跑
        /// </summary>
        protected override void DryRun()
        {

        }

        /// <summary>
        /// 自动标定
        /// </summary>
        protected override void AutoCalib()
        {
            string strCalib = SystemMgrEx.GetInstance().CurrentCalib;

            ShowMessage(string.Format("开始自动标定 - {0},按启动键开始", strCalib), true);

            WaitIo("启动", true, -1);

            RunModeInfo info;
            if (SystemMgrEx.GetInstance().m_dictCalibs.TryGetValue(strCalib, out info))
            {
                MethodInfo method = GetType().GetMethod(info.m_strMethod);

                if (method != null)
                {
                    method.Invoke(this, null);
                }
                else
                {
                    ShowMessage("标定方法错误，请确认", true);
                }
            }

            ShowLog("标定完成");
            ShowMessage("标定完成", true);
        }

        /// <summary>
        /// GRR验证
        /// </summary>
        protected override void GrrRun()
        {
            string strGRR = SystemMgrEx.GetInstance().CurrentGrr;

            RunModeInfo info;
            if (SystemMgrEx.GetInstance().m_dictGrrs.TryGetValue(strGRR, out info))
            {
                MethodInfo method = GetType().GetMethod(info.m_strMethod);

                if (method != null)
                {
                    method.Invoke(this, null);
                }
                else
                {
                    ShowMessage("GRR方法错误，请确认", true);
                }
            }
        }
    }
}
