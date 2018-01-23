using System;
using MemoTime.Core.Domain;
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
        
        public static void SetProject(this IMemoryCache cache, ProjectDto project)
            => cache.Set($"task-{project.Id}", project, TimeSpan.FromSeconds(5));

        public static ProjectDto GetProject(this IMemoryCache cache, Guid id)
            => cache.Get<ProjectDto>($"task-{id}");

        public static void SetToken(this IMemoryCache cache, Guid tokenId, TokenDto token)
            => cache.Set($"token-{tokenId}", token);

        public static TokenDto GetToken(this IMemoryCache cache, Guid tokenId)
            => cache.Get<TokenDto>($"token-{tokenId}");

        public static void SetLabel(this IMemoryCache cache, LabelDto label)
            => cache.Set($"label-{label.Id}", label, TimeSpan.FromSeconds(5));

        public static LabelDto GetLabel(this IMemoryCache cache, Guid id)
            => cache.Get<LabelDto>($"label-{id}");
    }
}