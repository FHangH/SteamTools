using MetroTrilithon.Serialization;
using SteamTool.Core;
using SteamTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SteamTools.Models.Settings
{
    public static class GeneralSettings
    {
        static GeneralSettings()
        {
            WindowsStartupAutoRun.ValueChanged += WindowsStartupAutoRun_ValueChanged;
            IsEnableLogRecord.ValueChanged += IsEnableLogRecord_ValueChanged;
            //CreateDesktopShortcut.ValueChanged += CreateDesktopShortcut_ValueChanged;
        }

        //private static void CreateDesktopShortcut_ValueChanged(object sender, ValueChangedEventArgs<bool> e)
        //{

        //}

        private static void IsEnableLogRecord_ValueChanged(object sender, ValueChangedEventArgs<bool> e)
        {
            Logger.EnableTextLog = e.NewValue;
        }

        private static void WindowsStartupAutoRun_ValueChanged(object sender, ValueChangedEventArgs<bool> e)
        {
            var steamService = SteamToolCore.Instance.Get<SteamToolService>();
            steamService.SetWindowsStartupAutoRun(e.NewValue, ProductInfo.Title);
        }

        /// <summary>
        /// 多语言设置
        /// </summary>
        public static SerializableProperty<string> Culture { get; }
            = new SerializableProperty<string>(GetKey(), Providers.Roaming) { AutoSave = true };

        /// <summary>
        /// 程序是否开机自启动
        /// </summary>
        public static SerializableProperty<bool> WindowsStartupAutoRun { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };

        ///// <summary>
        ///// 创建桌面快捷方式
        ///// </summary>
        //public static SerializableProperty<bool> CreateDesktopShortcut { get; }
        //    = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };

        /// <summary>
        /// 程序启动时最小化
        /// </summary>
        public static SerializableProperty<bool> IsStartupAppMinimized { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };

        /// <summary>
        /// 是否显示起始页
        /// </summary>
        public static SerializableProperty<bool> IsShowStartPage { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, true) { AutoSave = true };

        /// <summary>
        /// 启用游戏列表本地缓存
        /// </summary>
        public static SerializableProperty<bool> IsSteamAppListLocalCache { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, true) { AutoSave = true };

        /// <summary>
        /// 自动运行Steam
        /// </summary>
        public static SerializableProperty<bool> IsAutoRunSteam { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };

        /// <summary>
        /// Steam启动参数
        /// </summary>
        public static SerializableProperty<string> SteamStratParameter { get; }
            = new SerializableProperty<string>(GetKey(), Providers.Local, string.Empty) { AutoSave = true };

        /// <summary>
        /// 自动检查更新
        /// </summary>
        public static SerializableProperty<bool> IsAutoCheckUpdate { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, true) { AutoSave = true };

        /// <summary>
        /// 启用错误日志记录
        /// </summary>
        public static SerializableProperty<bool> IsEnableLogRecord { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };

        /// <summary>
        /// 检测到Steam启动时弹出消息通知
        /// </summary>
        public static SerializableProperty<bool> IsEnableSteamLaunchNotification { get; }
            = new SerializableProperty<bool>(GetKey(), Providers.Roaming, false) { AutoSave = true };
        private static string GetKey([CallerMemberName] string propertyName = "")
        {
            return nameof(GeneralSettings) + "." + propertyName;
        }
    }
}
