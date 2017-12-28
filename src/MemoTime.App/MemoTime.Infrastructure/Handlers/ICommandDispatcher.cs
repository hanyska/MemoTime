using System.Threading.Tasks;

namespace MemoTime.Infrastructure.Handlers
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}