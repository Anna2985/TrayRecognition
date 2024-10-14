using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;

namespace Traylib
{
    public class trayRecognitionLib
    {
        public enum enum_pn
        {
            product_03,
        }
        public class excuteClass
        {
            public string stage { get; set; }
            public string matrix { get; set; }
            public string product { get; set; }
            public string op_time { get; set; }
            static private List<string> ExcuteProduct03()
            {
                string datetime = DateTime.Now.ToDateTimeString().Replace("/", "_").Replace(":", "_");
                int stage_num = 3;
                string matrix1 = "2,2";
                string matrix2 = "2,1";
                List<string> result = new List<string>();
                for (int i = 0; i < stage_num; i++)
                {
                    returnData returnData = new returnData();
                    List<excuteClass> excuteClasses = new List<excuteClass>();
                    excuteClass excuteClass = new excuteClass();
                    excuteClass.matrix = (i != stage_num - 1) ? matrix1 : matrix2;
                    excuteClass.stage = (i + 1).ToString();
                    excuteClass.product = "product_03";
                    excuteClass.op_time = datetime;
                    excuteClasses.Add(excuteClass);

                    returnData.Data = excuteClasses;
                    string url = "http://192.168.15.113:3000/MetalMarkAI";
                    string json_in = returnData.JsonSerializationt();
                    string json_out = Net.WEBApiPostJson(url, json_in);
                    returnData = json_out.JsonDeserializet<returnData>();
                    if (i == 0)
                    {
                        ProcessMatrix(returnData.ValueAry, 0, result);
                    }
                    else if (i == 1)
                    {
                        ProcessMatrix(returnData.ValueAry, 2, result);
                    }
                    else
                    {
                        ProcessMatrix(returnData.ValueAry, 4, result);
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
        }
        
        
    }
}
