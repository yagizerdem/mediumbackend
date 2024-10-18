﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data };
        }
    }
}
