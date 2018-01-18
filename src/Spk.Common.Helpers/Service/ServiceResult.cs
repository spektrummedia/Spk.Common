using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Service
{
    public class ServiceResult
    {
        public IEnumerable<string> Errors => _internalErrors;
        public IEnumerable<string> Warnings => _internalWarnings;
        public bool Success => !Errors.Any();
        private readonly List<string> _internalErrors = new List<string>();
        private readonly List<string> _internalWarnings = new List<string>();

        public void AddError(string error)
        {
            error.GuardIsNotNull(nameof(error));
            _internalErrors.Add(error);
        }

        public string GetFirstError()
        {
            return Errors.FirstOrDefault();
        }

        public void AddWarning(string warning)
        {
            warning.GuardIsNotNull(nameof(warning));
            _internalWarnings.Add(warning);
        }

        public string GetFirstWarning()
        {
            return Warnings.FirstOrDefault();
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; private set; }

        public ServiceResult(T data)
        {
            SetData(data.GuardIsNotNull(nameof(data)));
        }

        public ServiceResult()
        {
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
