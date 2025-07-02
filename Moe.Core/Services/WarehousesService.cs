using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Moe.Core.Null;

namespace Moe.Core.Services;

public interface IWarehousesService
{
    Task<Response<PagedList<WarehouseSimpleDTO>>> GetAll(WarehouseFilter filter);
    Task<Response<WarehouseDTO>> GetById(Guid id);
    Task<Response<WarehouseDTO>> CreateIn(WarehouseFormDTO form);
    Task<Response<WarehouseOutDTO>> CreateOut(WarehouseFormOutDTO form);
    Task Update(WarehouseUpdateDTO update);
    Task Delete(Guid id);
}

public class WarehousesService : BaseService, IWarehousesService
{
    public WarehousesService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<WarehouseSimpleDTO>>> GetAll(WarehouseFilter filter)
    {
        var warehouses = await _context.Warehouses
            .WhereBaseFilter(filter)
            .Where(w => filter.FamilyId == null || w.FamilyId == filter.FamilyId)
            .Where(w => filter.OrphanId == null || w.OrphanId == filter.OrphanId)
            .Where(w => filter.DonationStatus == null || w.DonationStatus == filter.DonationStatus)
            .Where(w => filter.DonationType == null || w.DonationType == filter.DonationType)
            .Where(w => filter.ReceivedName == null || w.ReceivedName == filter.ReceivedName)
            .Where(w => filter.DonorName == null || w.DonorName == filter.DonorName)
             .Where(w => filter.Type == null || w.Type == filter.Type)
            .OrderByCreationDate()
            .ProjectTo<WarehouseSimpleDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<WarehouseSimpleDTO>>(warehouses, null, 200);
    }

    public async Task<Response<WarehouseDTO>> GetById(Guid id)
    {
        var entity = await _context.Warehouses
            .Include(w => w.Family)
            .Include(w => w.Orphan)
            .FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);

        if (entity == null)
            ErrResponseThrower.NotFound("Warehouse Not Found");

        var dto = _mapper.Map<WarehouseDTO>(entity);
        return new Response<WarehouseDTO>(dto, null, 200);
    }

    public async Task<Response<WarehouseDTO>> CreateIn(WarehouseFormDTO form)
    {
        var dto = await _context.CreateWithMapper<Warehouse, WarehouseDTO>(form, _mapper);

        return new Response<WarehouseDTO>(dto, null, 200);
    }

    public async Task<Response<WarehouseOutDTO>> CreateOut(WarehouseFormOutDTO form)
    {

        await _context.EnsureEntityExists<Family>(form.FamilyId);
        await _context.EnsureEntityExists<Orphan>(form.OrphanId);


        foreach (var item in form.Items)
        {
            var original = await _context.GetByIdOrException<Warehouse>(item.ItemId);

            if (original.Type != ItemType.In)
                return new Response<WarehouseOutDTO>(null, "The linked item is not of type 'In'.", 400);

            if (original.Qty < item.Qty)
                return new Response<WarehouseOutDTO>(null, $"Insufficient quantity for item  Available: {original.Qty}.", 400);


            var newEntity = new Warehouse
            {

                Qty = item.Qty,
                FamilyId = form.FamilyId,
                OrphanId = form.OrphanId,
                Type = ItemType.Out,
                ReceivedName = form.ReceivedName,

                DisplayId = original.DisplayId,
                MovId = original.Id,
                DonationType = original.DonationType,
                DonationAmount = original.DonationAmount,
                DonationImage = original.DonationImage,
                DonationStatus = original.DonationStatus,
                Donationlocation = original.Donationlocation,
                DonorName = original.DonorName,
                PhoneNumber = original.PhoneNumber,
                Email = original.Email,


            };

            _context.Add(newEntity);
            original.Qty -= item.Qty;



        }

        await _context.SaveChangesAsync();
        var result = _mapper.Map<WarehouseOutDTO>(form);
        return new Response<WarehouseOutDTO>(result, null, 200);
    }




    public async Task Update(WarehouseUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<Warehouse, WarehouseUpdateDTO>(update, _mapper);
    }

    public async Task Delete(Guid id) =>
        await _context.SoftDeleteOrException<Warehouse>(id);
}
