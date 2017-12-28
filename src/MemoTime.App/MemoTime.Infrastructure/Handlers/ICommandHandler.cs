using System.Threading.Tasks;

namespace MemoTime.Infrastructure.Handlers
{
    public interface ICommandHandler<in T>
    {
         Task HandleAsync(T command);
    }
}