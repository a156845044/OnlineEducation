using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace XiaoWeiOnlineEducation.Filter
{
    public class FilterBase : Page
    {
        static private DirectoryInfo _Dir;

        /// <summary>
        /// ViewSate在服务器上的存放路径
        /// </summary>
        private DirectoryInfo Dir
        {
            get
            {
                if (_Dir == null)
                {
                    _Dir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"));//默认放在App_Data文件夹中
                    if (!_Dir.Exists)
                        _Dir.Create();
                    _Dir = new DirectoryInfo(Path.Combine(_Dir.FullName, "ViewState"));
                    if (!_Dir.Exists)
                        _Dir.Create();
                }
                return _Dir;
            }
        }

        /// <summary>
        /// 取出ViewState对象
        /// </summary>
        /// <returns></returns>
        protected override object LoadPageStateFromPersistenceMedium()
        {
            PageStatePersister ps = this.PageStatePersister;
            ps.Load();
            if (ps.ControlState != null)
                ps.ControlState = DeserializeObj((string)ps.ControlState);
            if (ps.ViewState != null)
                ps.ViewState = DeserializeObj((string)ps.ViewState);
            return new Pair(ps.ControlState, ps.ViewState);
        }

        /// <summary>
        /// 存入ViewState对象
        /// </summary>
        /// <param name="state"></param>
        protected override void SavePageStateToPersistenceMedium(object state)
        {
            PageStatePersister ps = this.PageStatePersister;
            if (state is Pair)
            {
                Pair pair = (Pair)state;
                ps.ControlState = pair.First;
                ps.ViewState = pair.Second;
            }
            else
            {
                ps.ViewState = state;
            }
            if (ps.ControlState != null)
                ps.ControlState = SerializeObj(ps.ControlState);
            if (ps.ViewState != null)
                ps.ViewState = SerializeObj(ps.ViewState);
            ps.Save();
        }

        /// <summary>
        /// 反序列化viewstate对象
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        private object DeserializeObj(string stateID)
        {
            string stateStr = (string)Cache[stateID];
            string file = Path.Combine(Dir.FullName, stateID);
            if (stateStr == null)
                stateStr = File.ReadAllText(file);
            else
                Cache.Remove(stateID);
            return new ObjectStateFormatter().Deserialize(stateStr);
        }

        /// <summary>
        /// 序列化viewstate对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string SerializeObj(object obj)
        {
            string value = new ObjectStateFormatter().Serialize(obj);
            string stateID = (DateTime.Now.Ticks + (long)value.GetHashCode()).ToString(); //产生离散的id号码   
            File.WriteAllText(Path.Combine(Dir.FullName, stateID), value);
            Cache.Insert(stateID, value);
            return stateID;
        }

        /// <summary>
        /// 在页面卸载的时候删除无效的viewsate
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            DateTime dt = DateTime.Now.AddMinutes(-20);
            foreach (FileInfo fl in Dir.GetFiles())
                if (fl.LastAccessTime < dt)
                {
                    try
                    {
                        fl.Delete();
                    }
                    catch
                    {
                    }
                }
        }
    }
}