using Domain.Dtos;

namespace Infrastructure.Services;

public interface IQuoteService
{
    Task<List<GetQuotesDto>> GetQuotes();
    Task<UpdateQuoteDto> GetQuoteById(int id);
    Task<AddQuoteDto> AddQuote(AddQuoteDto createQuoteDto);
    Task<UpdateQuoteDto> UpdateQuote(UpdateQuoteDto updateQuoteDto);
    Task<bool> DeleteDepartment(int id);
}