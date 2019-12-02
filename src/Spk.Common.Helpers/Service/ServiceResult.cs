using System.Collections.Generic;
using System.Linq;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.Service
{
    public class ServiceResult
    {
        public IEnumerable<string> Errors => _internalErrors;
        private readonly List<string> _internalErrors = new List<string>();

        public IEnumerable<string> Warnings => _internalWarnings;
        private readonly List<string> _internalWarnings = new List<string>();

        public bool Success => !Errors.Any();
        public bool HasWarnings => Warnings.Any();

        public void AddError(string error)
        {
            error.GuardIsNotNullOrWhiteSpace(nameof(error));
            _internalErrors.Add(error);
        }

        public string GetFirstError()
        {
            return Errors.FirstOrDefault();
        }

        public void AddWarning(string warning)
        {
            warning.GuardIsNotNullOrWhiteSpace(nameof(warning));
            _internalWarnings.Add(warning);
        }

        public string GetFirstWarning()
        {
            return Warnings.FirstOrDefault();
        }

        public static ServiceResult Succeed()
        {
            return new ServiceResult();
        }

        public static ServiceResult Failed(params string[] errors)
        {
            var result = new ServiceResult();
            if (errors != null)
            {
                foreach (var error in errors)
                    result.AddError(error);
            }
            return result;
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

        public static ServiceResult<T> Succeed(T data)
        {
            return new ServiceResult<T>(data);
        }
    }
}
