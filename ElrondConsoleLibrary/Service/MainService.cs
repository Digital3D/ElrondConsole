using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ElrondConsoleLibrary.Model;
using Newtonsoft.Json;
using NLog;

namespace ElrondConsoleLibrary
{

    public class MainService
    {
        private string _apiUrl = "https://api.elrond.com";
        private Logger _log = LogManager.GetCurrentClassLogger();

        private async Task<ApiResponse<T>> GetApiJsonResult<T>(string baseApiUrl, MethodType type = MethodType.GET, string data = null)
        {
            ApiResponse<T> response = new ApiResponse<T>();
            //if data contains already "?"
            if (data != null && data.Trim().StartsWith("?"))
                data = data.Trim().Substring(1);

            string url = baseApiUrl;
            if (type == MethodType.GET)
                url = $"{baseApiUrl}" + (data != null ? $"?{data}" : "");

            response.Url = url;
            response.Data = data;

            try
            {
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                httpWebRequest.Method = type.ToString();
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Accept = "application/json";

                if (type != MethodType.GET && data != null)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    httpWebRequest.ContentLength = bytes.Length;
                    using (var writer = httpWebRequest.GetRequestStream())
                    {
                        writer.Write(bytes, 0, bytes.Length);
                    }
                }

                using (HttpWebResponse webResponse = await httpWebRequest.GetResponseAsync() as HttpWebResponse)
                {
                    if (webResponse?.StatusCode == HttpStatusCode.OK ||
                        webResponse?.StatusCode == HttpStatusCode.Accepted ||
                        webResponse?.StatusCode == HttpStatusCode.NoContent)
                    {
                        using (var stream = webResponse.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                string resp = await new StreamReader(stream).ReadToEndAsync();
                                if (!string.IsNullOrEmpty(resp))
                                {
                                    response.Result = DeserializeObject<T>(resp);
                                    response.ResultJson = JsonConvert.SerializeObject(response.Result, Formatting.Indented);
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                response.IsError = true;
                var resp = await new StreamReader(ex.Response.GetResponseStream()).ReadToEndAsync();

                dynamic obj = JsonConvert.DeserializeObject(resp);
                response.Message = obj?.ToString().Replace("\r\n", "") ?? "";
                _log.Error($"WebException {type} {url} - data {data}: {response.Message}");
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
                if (ex.InnerException != null)
                    response.Message += " - " + ex.InnerException.Message;
                _log.Error($"Error Exception {type} {url} - data {data}: {response.Message}");
            }

            return response;
        }

        public T DeserializeObject<T>(string result)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Culture = new System.Globalization.CultureInfo("fr-FR"),
                DateFormatString = "yyyy/MM/dd hh:mm:ss",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            var obj = JsonConvert.DeserializeObject<T>(result, settings);
            return obj;
        }


        public async Task<ApiResponse<AccountModel>> GetInformationElrondAddress(string erdAddress)
        {
            ApiResponse<AccountModel> response = new ApiResponse<AccountModel>();
            
            if (!string.IsNullOrEmpty(erdAddress))
            {
                string url = CombineUrl($"address/{erdAddress}");

                response = await GetApiJsonResult<AccountModel>(url, MethodType.GET);
            }
            else
            {
                CreateResponseError(ref response, "Account address is empty!");
            }

            return response;
        }
        public async Task<ApiResponse<AccountTransactionModel>> GetTransactions(string erdAddress)
        {
            ApiResponse<AccountTransactionModel> response = new ApiResponse<AccountTransactionModel>();

            if (!string.IsNullOrEmpty(erdAddress))
            {
                string url = CombineUrl($"address/{erdAddress}/transactions");

                response = await GetApiJsonResult<AccountTransactionModel>(url, MethodType.GET);
            }
            else
            {
                CreateResponseError(ref response, "Account address is empty!");
            }

            return response;
        }

        public async Task<ApiResponse<TransactionDetailModel>> GetDetailTransaction(string transactionHash)
        {
            ApiResponse<TransactionDetailModel> response = new ApiResponse<TransactionDetailModel>();

            if (!string.IsNullOrEmpty(transactionHash))
            {
                string url = CombineUrl($"transaction/{transactionHash}");

                response = await GetApiJsonResult<TransactionDetailModel>(url, MethodType.GET);
            }
            else
            {
                CreateResponseError(ref response, "Transaction Hash is empty!");
            }

            return response;
        }

        public async Task<ApiResponse<NetworkConfigModel>> GetNetworkConfig()
        {
            string url = CombineUrl($"network/config");
            var response = await GetApiJsonResult<NetworkConfigModel>(url, MethodType.GET);
            return response;
        }

        public async Task<ApiResponse<ShardStatusModel>> GetShardStatus(string shardId)
        {
            ApiResponse<ShardStatusModel> response = new ApiResponse<ShardStatusModel>();

            if (!string.IsNullOrEmpty(shardId))
            {
                string url = CombineUrl($"network/status/{shardId}");

                response = await GetApiJsonResult<ShardStatusModel>(url, MethodType.GET);
            }
            else
            {
                CreateResponseError(ref response, "Shard Id is empty!");
            }

            return response;
        }

        public async Task<ApiResponse<HeartBeatStatusModel>> GetHeartBeatStatus()
        {
            string url = CombineUrl($"node/heartbeatstatus");
            var response = await GetApiJsonResult<HeartBeatStatusModel>(url, MethodType.GET);
            return response;
        }

        public async Task<ApiResponse<HeartBeatStatusModel>> GetHeartBeatStatus(string name)
        {
            ApiResponse<HeartBeatStatusModel> response = new ApiResponse<HeartBeatStatusModel>();

            if (!string.IsNullOrEmpty(name))
            {
                response = await GetHeartBeatStatus();
                if (!response.IsError)
                {
                    response.Result.Message = response.Result.Message.Where(x => x.NodeDisplayName.ToLower().Contains(name.ToLower())).ToList();
                    response.ResultJson = JsonConvert.SerializeObject(response.Result, Formatting.Indented);
                }

            }
            else
            {
                CreateResponseError(ref response, "Node name is empty!");
            }

            return response;
        }

        public async Task<ApiResponse<BlockModel>> GetBlock(string shardId, string blockNumber)
        {
            ApiResponse<BlockModel> response = new ApiResponse<BlockModel>();

            if (!string.IsNullOrEmpty(shardId) && !string.IsNullOrEmpty(blockNumber))
            {
                string url = CombineUrl($"block/{shardId}/{blockNumber}");

                response = await GetApiJsonResult<BlockModel>(url, MethodType.GET);
            }
            else
            {
                CreateResponseError(ref response, "Shard Id and Block number are empties!");
            }

            return response;
        }

        public ApiResponse<T> CreateResponseError<T>(ref ApiResponse<T> response, string message)
        {
            response.IsError = true;
            response.Message = message;
            return response;
        }

        private string CombineUrl(string endpointName)
        {
            return $"{_apiUrl}/{endpointName}";
        }



    }
}
