using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _StarbucksApi.ViewModels
{
    public class ResponseResource
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public static ResponseResource GenerateResponse(object _data,bool _isSuccess=true,string _message="İşlem Başarılı.") 
        {
            return new ResponseResource() { IsSuccess = _isSuccess, Data = _data, Message = _message };
        }
    }
}
