using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Service
{
    public class ServiceResult<T>
    {
        public ServiceResult(T data)
        {
            SetData(data);
        }

        public IEnumerable<string> Errors => _internalErrors;
        public T Data { get; private set; }

        public bool Success => !Errors.Any();
        private readonly List<string> _internalErrors;

        public ServiceResult()
        {
            _internalErrors = new List<string>();
        }

        public void SetData(T data)
        {
            Data = data;
        }

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
}
