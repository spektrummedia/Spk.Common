using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Service
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }
        public T Data { get; private set; }

        public bool Success => !Errors.Any();

        public void SetData(T data)
        {
            Data = data;
        }

        public void AddError(string error)
        {
            error.GuardIsNotNull(nameof(error));
            Errors.Add(error);
        }

        public string GetFirstError()
        {
            return Errors.FirstOrDefault();
        }
    }
}
