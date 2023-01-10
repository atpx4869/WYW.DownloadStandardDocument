using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYW.DownloadStandardDocument
{
    internal class Response
    {
        public Result[] result { get; set; }
        public bool success { get; set; }

        /// <summary>
        /// 每页条数，默认50
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPageCount { get; set; }
        /// <summary>
        /// 当前页数，从1开始
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int totalCount { get; set; }

    }
    internal class Result
    {
        /// <summary>
        /// 标准状态，现行还是废除
        /// </summary>
        [JsonProperty(PropertyName = "STAN_STATUS")]
        public string Status { get; set; } = "";

        /// <summary>
        /// 标准的年号
        /// </summary>
        [JsonProperty(PropertyName = "STAN_PART_YEAR_STRING")]
        public string Year { get; set; } = "";

        /// <summary>
        /// 标准编号，例如YY 0664-2020
        /// </summary>
        [JsonProperty(PropertyName = "STAN_NUM")]
        public string Code { get; set; } = "";

        /// <summary>
        /// 标准中文名称
        /// </summary>
        [JsonProperty(PropertyName = "STAN_CNNAME")]
        public string Name { get; set; } = "";
        private string pdfPath;

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// PDF路径，如果是8080端口，需要替换成8087端口
        /// </summary>
        [JsonProperty(PropertyName = "PDF_DOUBLE_PATH")]
        public string PdfPath
        {
            get { return pdfPath; }
            set
            {

                pdfPath = value;
                if (!string.IsNullOrEmpty(value))
                {
                    IsCanDownload = "支持";
                }
            }
        }

        public string IsCanDownload { get; set; }
        public string GetPdfNewPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "";
            }
            return path.Replace(":8080", ":8087");
        }

    }
}
