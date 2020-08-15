using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ElrondConsoleLibrary.Model;
using Newtonsoft.Json;
using NLog;
using Rebex.Security.Cryptography;

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
                httpWebRequest.ContentType = "application/json";
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
                                    response.ResultRawJson = resp;
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
                    response.Result.Data.Heartbeats = response.Result.Data?.Heartbeats?.Where(x => x.NodeDisplayName.ToLower().Contains(name.ToLower())).ToList();
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

        public async Task<ApiResponse<TransactionSendModel>> SendTransaction(string nonce, string value, string sender, string receiver, string gasPrice, string gasLimit, string message = null)
        {
            ApiResponse<TransactionSendModel> response = new ApiResponse<TransactionSendModel>();

            if (!string.IsNullOrEmpty(nonce) && 
                !string.IsNullOrEmpty(value) && 
                !string.IsNullOrEmpty(sender) &&
                !string.IsNullOrEmpty(receiver) &&
                !string.IsNullOrEmpty(gasPrice) &&
                !string.IsNullOrEmpty(gasLimit)
            )
            {
                string url = CombineUrl($"transaction/send");
                StringBuilder data = new StringBuilder();

                data.Append($"\"nonce\":{nonce}");
                data.Append($",\"value\":\"{value}\"");
                data.Append($",\"sender\":\"{sender}\"");
                data.Append($",\"receiver\":\"{receiver}\"");
                data.Append($",\"gasPrice\":{gasPrice}");
                data.Append($",\"gasLimit\":{gasLimit}");
                if (!string.IsNullOrEmpty(message))
                    data.Append($",\"data\":\"{Base64Encode(message)}\""); //Zm9yIHRoZSBib29r
                data.Append($",\"chainID\":\"v1.0.141\"");
                data.Append($",\"version\":1");

                StringBuilder data2 = new StringBuilder();
                data2.Append($"{{");
                data2.Append(data);
                //TODO: To Verify, actually I cannot really test
                data2.Append($",\"signature\":\"{CreateSignature(nonce, value, sender, receiver, gasPrice, gasLimit, message)}\"");
                data2.Append("}}");

                response = await GetApiJsonResult<TransactionSendModel>(url, MethodType.POST, data2.ToString());
            }
            else
            {
                CreateResponseError(ref response, "Some values are empties!");
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


        public string CreateSignature(string nonce, string value, string sender, string receiver, string gasPrice, string gasLimit, string message = null)
        {
            StringBuilder data = new StringBuilder("{");
            data.Append($"\"nonce\":{nonce}");
            data.Append($",\"value\":\"{value}\"");
            data.Append($",\"sender\":\"{sender}\"");
            data.Append($",\"receiver\":\"{receiver}\"");
            data.Append($",\"gasPrice\":{gasPrice}");
            data.Append($",\"gasLimit\":{gasLimit}");
            if(!string.IsNullOrEmpty(message))
                data.Append($",\"data\":\"{Base64Encode(message)}\"");
            data.Append($",\"chainID\":\"v1.0.141\"");
            data.Append($",\"version\":1");
            data.Append("}");
            byte[] byteMessage = Encoding.UTF8.GetBytes(data.ToString().Replace(" ",""));

            Ed25519 ed = new Ed25519();
            //TODO: Impossible to know if it's ok like that, transaction always return "Forbidden"
            byte[] privateKeyBytes = GetBytesFromPEM(Path.Combine(Environment.CurrentDirectory, "validatorKey.pem"));
            ed.FromSeed(privateKeyBytes);
            byte[] result = ed.SignMessage(byteMessage);
            
            string s2 = BitConverter.ToString(result);
            String[] tempAry = s2.Split('-');
            string signature = String.Join("", tempAry);

            return signature;
        }

        /// <summary>
        /// Read a PEM file
        /// </summary>
        /// <param name="pemFileName">PEM FileName</param>
        /// <returns>Return 32 first bytes</returns>
        private byte[] GetBytesFromPEM(string pemFileName)
        {
            string pemString = "";
            using (StreamReader f = new StreamReader(pemFileName, Encoding.UTF8))
            {
                pemString = f.ReadToEnd();
            }

            pemString = Regex.Replace(pemString, "^-----BEGIN.*?-----\r*\n*$", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            pemString = Regex.Replace(pemString, "^-----END.*?-----\r*\n*$", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            pemString = Regex.Replace(pemString, "\r*\n*$", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            return Convert.FromBase64String(pemString).ToList().Take(32).ToArray();
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
