using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.IEnumerable
{
    public static class ParallelForEachExtension
    {
        /// <summary>
        ///     Execute a function for every item inside an IEnumerable.
        ///     Functions are executed in parallel for performance purposes.
        ///     The function returns when all tasks are done.
        /// </summary>
        /// <typeparam name="T">Type of the items in the collections</typeparam>
        /// <param name="source">The source elements</param>
        /// <param name="task">Delegate function to execute</param>
        public static void ParallelForEach<T>(
            this IEnumerable<T> source,
            Func<T, Task> task,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            source.GuardIsNotNull(nameof(source));
            task.GuardIsNotNull(nameof(task));
            Task.WaitAll(
                source.Select(x => task(x)).ToArray(),
                cancellationToken
            );
        }
    }
}
