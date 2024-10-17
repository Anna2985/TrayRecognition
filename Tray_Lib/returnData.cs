using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic;
using System.Text.Json.Serialization;


namespace Tray_Lib
{
    public class returnData
    {
        private object _data = new object();
        private int _code = 0;
        private string _result = "";
        private string _value = "";
        private string _method = "";
        private string _timeTaken = "";
        private string _server = "";
        private uint _port = 0;
        private string _userName = "";
        private string _password = "";

        private string _dbName = "";
        private string _tableName = "";
        private string _serverName = "";
        private string _serverType = "";
        private string _serverContent = "";
        private string _RequestUrl = "";
        private string _token = "";
        private List<string> valueAry = new List<string>();

        /// <summary>
        /// 資料內容回傳或傳入,內容可為任意資料結構JSON格式,依據API自定義
        /// </summary>
        public object Data
        {
            get => _data;
            set
            {
                _data = value;
            }
        }
        /// <summary>
        /// 回傳結果碼
        /// </summary>
        public int Code { get => _code; set => _code = value; }
        /// <summary>
        /// 執行函式名稱
        /// </summary>
        public string Method { get => _method; set => _method = value; }
        /// <summary>
        /// 回傳結果說明
        /// </summary>
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
            }
        }
        /// <summary>
        /// 傳入參數(string)由API自定義
        /// </summary>
        public string Value { get => _value; set => _value = value; }
        /// <summary>
        /// 傳入參數(stringAry)由API自定義
        /// </summary>
        public List<string> ValueAry
        {
            get
            {
                return this.valueAry;
            }
            set
            {
                this.valueAry = value;
            }
        }
        /// <summary>
        /// 執行花費時長
        /// </summary>
        public string TimeTaken { get => _timeTaken; set => _timeTaken = value; }
        /// <summary>
        /// 傳入API驗證token碼
        /// </summary>
        public string Token { get => _token; set => _token = value; }
        /// <summary>
        /// 傳入Database Server參數
        /// </summary>
        public string Server { get => _server; set => _server = value; }
        /// <summary>
        /// 傳入Database DbName參數
        /// </summary>
        public string DbName { get => _dbName; set => _dbName = value; }
        /// <summary>
        /// 傳入Database TableName參數
        /// </summary>
        public string TableName { get => _tableName; set => _tableName = value; }
        /// <summary>
        /// 傳入Database Port參數
        /// </summary>
        public uint Port { get => _port; set => _port = value; }
        /// <summary>
        /// 傳入Database UserName參數
        /// </summary>
        public string UserName { get => _userName; set => _userName = value; }
        /// <summary>
        /// 傳入Database Password參數
        /// </summary>
        public string Password { get => _password; set => _password = value; }
        /// <summary>
        /// 傳入伺服器 ServerType參數(網頁、調劑台、藥庫....)
        /// </summary>
        public string ServerType { get => _serverType; set => _serverType = value; }
        /// <summary>
        /// 傳入伺服器 ServerName參數(dps01、ds01...)
        /// </summary>
        public string ServerName { get => _serverName; set => _serverName = value; }
        /// <summary>
        /// 傳入伺服器 ServerContent參數(人員資料、藥品資料、一般資料...)
        /// </summary>
        public string ServerContent { get => _serverContent; set => _serverContent = value; }
        /// <summary>
        /// 回傳觸發請求網址
        /// </summary>
        public string RequestUrl { get => _RequestUrl; set => _RequestUrl = value; }




        [JsonIgnore]
        public string Url = "";
        [JsonIgnore]
        public string JsonInput
        {
            get
            {
                return InputData.JsonSerializationt();
            }
        }
        [JsonIgnore]
        public returnData InputData
        {
            get
            {
                return this;
            }
        }
        [JsonIgnore]
        public string JsonResult
        {
            get
            {
                return ResultData.JsonSerializationt();
            }
            set
            {
                this.resultData = value.JsonDeserializet<returnData>();
            }
        }
        private returnData resultData;
        [JsonIgnore]
        public returnData ResultData
        {
            get
            {
                return resultData;
            }
            set
            {
                resultData = value;
            }
        }



        public returnData()
        {
        }
        public returnData(string url)
        {
            this.Url = url;
        }


        public string ApiPostJson()
        {
            string json = Net.WEBApiPostJson(this.Url, this.JsonInput);
            JsonResult = json;
            return json;
        }
        public string ApiGet()
        {
            string json = Net.WEBApiGet(this.Url);
            JsonResult = json;
            return json;
        }

        public override string ToString()
        {
            return $"[{RequestUrl}] Result : {Result} ,{TimeTaken}";
        }
    }
}
