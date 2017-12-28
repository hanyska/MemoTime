using System;
using MemoTime.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetTask(this IMemoryCache cache, TaskDto task)
            => cache.Set($"task-{task.Id}", task, TimeSpan.FromSeconds(5));

        public static TaskDto GetTask(this IMemoryCache cache, Guid id)
            => cache.Get<TaskDto>($"task-{id}");
    }
}