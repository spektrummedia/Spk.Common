using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Service
{
    public class ServiceResult
    {
        private readonly List<string> _internalErrors = new List<string>();
        public IEnumerable<string> Errors => _internalErrors;

        public bool Success => !Errors.Any();

        public void AddError(string error)
        {
            error.GuardIsNotNull(nameof(error));
            _internalErrors.Add(error);
        }

        public string GetFirstError()
        {
            return Errors.FirstOrDefault();
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(T data)
        {
            SetData(data.GuardIsNotNull(nameof(data)));
        }

        public ServiceResult()
        {
        }

        public T Data { get; private set; }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
