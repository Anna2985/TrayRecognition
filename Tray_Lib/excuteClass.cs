using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using HIS_DB_Lib;
using System.Windows.Forms;


namespace Tray_Lib
{
    public enum enum_pn
    {
        product_03
    }
    public class excuteClass
    {
        public string stage { get; set; }
        public string matrix { get; set; }
        public string product { get; set; }
        public string op_time { get; set; }
        public static event Action OnStageCompleted;
        public static bool ContinueExcute { get; set; } = false;
        static public List<string> ExcuteProduct03()
        {
            string datetime = DateTime.Now.ToDateTimeString().Replace("/", "_").Replace(":", "_");
            int stage_num = 3;
            string matrix1 = "2,2";
            string matrix2 = "2,1";
            List<string> result = new List<string>();
            for (int i = 1; i <= stage_num; i++)
            {
                returnData returnData = new returnData();
                List<excuteClass> excuteClasses = new List<excuteClass>();
                excuteClass excuteClass = new excuteClass();
                excuteClass.matrix = (i != stage_num ) ? matrix1 : matrix2;
                excuteClass.stage = i.ToString();
                excuteClass.product = "product_03";
                excuteClass.op_time = datetime;
                excuteClasses.Add(excuteClass);

                returnData.Data = excuteClasses;
                string url = "http://220.135.128.247:3000/MetalMarkAI";
                string json_in = returnData.JsonSerializationt();
                string json_out = Net.WEBApiPostJson(url, json_in);
                returnData = json_out.JsonDeserializet<returnData>();
                if (i == 1)
                {
                    ProcessMatrix(returnData.ValueAry, 0, result);
                    Console.WriteLine($"Stage {i} 完成，等待下一個條件...");
                    OnStageCompleted?.Invoke();
                    Wait();
                }
                else if (i == 2)
                {
                    ProcessMatrix(returnData.ValueAry, 2, result);
                    Console.WriteLine($"Stage {i} 完成，等待下一個條件...");
                    ContinueExcute = false;
                    OnStageCompleted?.Invoke();
                    Wait();
                }
                else if (i == 3)
                {
                    ProcessMatrix(returnData.ValueAry, 4, result);
                    Console.WriteLine($"Stage {i} 完成");
                }
            }
            return result;
        }
        static void ProcessMatrix(List<string> valueAry, int increment, List<string> result)
        {
            if (valueAry != null)
            {
                for (int j = 0; j < valueAry.Count; j++)
                {
                    string matrix = valueAry[j];
                    string[] parts = matrix.Split(',');
                    int number = parts[1].StringToInt32() + increment;
                    matrix = $"{parts[0]},{number}";
                    result.Add(matrix);
                }
            }
        }
        private static void Wait()
        {
            while (!ContinueExcute)
            {
                System.Threading.Thread.Sleep(100);  // 避免佔用 CPU
            }
            //ContinueExcute = false;  // 重置為 false 以便下一階段的檢查
        }
    }
    public class AnotherExcuteClass
    {
        public static void Execute()
        {
            Console.WriteLine("另一個 Excute 正在執行...");
            excuteClass.ContinueExcute = true;
            Console.WriteLine("另一個 Excute 完成！");
        }
    }
}
