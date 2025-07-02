using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface INewsesService
{
    Task<Response<PagedList<NewsSimpleDTO>>> GetAll(NewsFilter filter);
    Task<Response<NewsDTO>> GetById(Guid id);
    Task<Response<NewsDTO>> Create(NewsFormDTO form);
    Task Update(NewsUpdateDTO update);
    Task Delete(Guid id);
}

public class NewsesService : BaseService, INewsesService
{
    public NewsesService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<NewsSimpleDTO>>> GetAll(NewsFilter filter)
    {
        var query = _context.Newses
       .WhereBaseFilter(filter)
       .Where(e => filter.Title == null || e.Title.ToLower().Contains(filter.Title.ToLower()))
       .Where(e => filter.Content == null || e.Content.ToLower().Contains(filter.Content.ToLower()))
       .Where(e => filter.Status == null || e.Status == filter.Status)
       .OrderByCreationDate();

        var newses = await query
            .ProjectTo<NewsSimpleDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<NewsSimpleDTO>>(newses, null, 200);
    }

    public async Task<Response<NewsDTO>> GetById(Guid id)
    {
        var dto = await _context.GetByIdOrException<News, NewsDTO>(id);
        return new Response<NewsDTO>(dto, null, 200);
    }

    public async Task<Response<NewsDTO>> Create(NewsFormDTO form)
    {
        var dto = await _context.CreateWithMapper<News, NewsDTO>(form, _mapper);

        return new Response<NewsDTO>(dto, null, 200);
    }

    public async Task Update(NewsUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<News, NewsUpdateDTO>(update, _mapper);
    }

    public async Task Delete(Guid id) =>
        await _context.SoftDeleteOrException<News>(id);
}
