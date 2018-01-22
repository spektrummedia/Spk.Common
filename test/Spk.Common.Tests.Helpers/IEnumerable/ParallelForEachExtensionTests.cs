using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Spk.Common.Helpers.IEnumerable;
using Xunit;

namespace Spk.Common.Tests.Helpers.IEnumerable
{
    public class ParallelForEachExtensionTests
    {
        [Theory]
        [InlineData(1000, 50)]
        public void ParallelForEach_ShouldExecuteTasks_AtOnce(int ms, int numberOfTask)
        {
            // Arrange
            var stopWatch = new Stopwatch();

            // Act
            stopWatch.Start();
            new object[numberOfTask].ParallelForEach(async x => await Task.Delay(ms));
            stopWatch.Stop();

            // Assert
            ((int)stopWatch.ElapsedMilliseconds).ShouldBeLessThan(numberOfTask * ms);
        }

        [Fact]
        public void ParallelForEach_ShouldThrows_WhenCancellationTokenCancelTriggered()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();

            // Act & assert
            Task.Run(() =>
                Assert.Throws<OperationCanceledException>(() =>
                    new object[50].ParallelForEach(async x => await Task.Delay(5000),
                        cancellationTokenSource.Token))
            );
            cancellationTokenSource.Cancel();
        }

        [Fact]
        public void ParallelForEach_ShouldThrows_WhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { ((List<string>)null).ParallelForEach(s => null); });
        }

        [Fact]
        public void ParallelForEach_ShouldThrows_WhenTaskIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { new List<string>().ParallelForEach(null); });
        }
    }
}
