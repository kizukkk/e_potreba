namespace e_potreba.Infrastructure.Policy;

using Microsoft.Data.SqlClient;
using Polly.Timeout;
using Polly.Retry;
using Polly;
public static class ResiliencePolicyOptions
{

    public static readonly TimeoutStrategyOptions TimeoutStrategy = 
        new TimeoutStrategyOptions
        {
            Timeout = TimeSpan.FromSeconds(5),
            OnTimeout = static args =>
            {
                Console.WriteLine($"{args.Context.OperationKey}: Execution timed out after {args.Timeout.TotalSeconds} seconds.");
                return default;
            }
        };

    public static readonly RetryStrategyOptions RetryStrategy =
        new RetryStrategyOptions
        {
            ShouldHandle = args => args.Outcome switch
            {
                { Exception: SqlException } => PredicateResult.True(),
                { Exception: TaskCanceledException } => PredicateResult.True(),
                _ => PredicateResult.True(),
            },
            MaxRetryAttempts = 2,
            OnRetry = retryArgumets =>
            {
                Console.WriteLine($"Current attemp: {retryArgumets.AttemptNumber}, " +
                    $"{retryArgumets.Outcome.Exception}");
                
                return ValueTask.CompletedTask;
            }
        };
}
