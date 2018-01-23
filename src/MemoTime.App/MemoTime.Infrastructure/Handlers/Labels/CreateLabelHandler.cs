using System.Threading.Tasks;
using AutoMapper;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Commands.Labels;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Infrastructure.Handlers.Labels
{
    public class CreateLabelHandler: ICommandHandler<Create>
    {
        private readonly ILabelService _labelService;
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public CreateLabelHandler
        (
            ILabelService service, 
            IUserRepository userRepository,
            IMemoryCache cache,
            IMapper mapper
        )
        {
            _labelService = service;
            _userRepository = userRepository;
            _cache = cache;
            _mapper = mapper;
        }
        
        public async Task HandleAsync(Create command)
        {
            var user = await _userRepository.GetAsync(command.UserId);
            await _labelService.CreateAsync(command.Id, user, command.Name);

            var label = await _labelService.GetAsync(command.Id, user.Id);


            var l = _mapper.Map<LabelDto>(label);
            _cache.SetLabel(_mapper.Map<LabelDto>(label));
        }
    }
}