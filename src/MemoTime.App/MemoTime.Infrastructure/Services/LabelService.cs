using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Exceptions;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using ErrorCodes = MemoTime.Infrastructure.Exceptions.ErrorCodes;

namespace MemoTime.Infrastructure.Services
{
    public class LabelService: ILabelService
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public LabelService
        (
            ILabelRepository labelRepository, 
            IMapper mapper
         )
        {
            _labelRepository = labelRepository;
            _mapper = mapper;

        }
        
        public async Task CreateAsync(Guid id, User user, string name)
        {
            var label = await _labelRepository.GetAsync(id, user.Id);
            if (label != null)
            {
                throw new ServiceException(ErrorCodes.LabelAlreadyExist);
            }
            
            label = new Label(id, user, name);

            await _labelRepository.AddAsync(label);
            
        }

        public async Task<LabelDto> GetAsync(Guid id, Guid userId)
        {
            var label = await _labelRepository.GetAsync(id, userId);

            if (label == null)
            {
                throw new ServiceException(ErrorCodes.LabelNotExist);
            }

            return _mapper.Map<LabelDto>(label);
        }

        public async Task<IEnumerable<LabelDto>> BrowseAsync(Guid userId)
        {
            var labels = await _labelRepository.BrowseAsync(userId);

            return _mapper.Map<IEnumerable<LabelDto>>(labels);
        }
    }
}
