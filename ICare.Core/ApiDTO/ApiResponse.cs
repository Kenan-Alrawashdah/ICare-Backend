using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
    public class ApiResponse
    {
        public bool Success => Errors == null;

        public List<string> Errors { get; private set; }

        public void AddError(string error)
        {
            if (Errors == null)
                Errors = new List<string>();

            Errors.Add(error);
        }

        
    }

 
}
