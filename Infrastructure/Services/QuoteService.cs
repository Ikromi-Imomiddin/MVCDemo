using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QuoteService : IQuoteService
{
    private readonly DataContext _context;

    public QuoteService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetQuotesDto>> GetQuotes()
    {
        var quote = await _context.Quotes
            .Select(d => new GetQuotesDto
            {
                Id = d.Id,
                Author = d.Author,
                QuoteText = d.QuoteText
            })
            .ToListAsync();
        
        return quote;
    }
    
    public async Task<UpdateQuoteDto> GetQuoteById(int id)
    {
        var quote = await _context.Quotes
            .Select(d => new UpdateQuoteDto
            {
                Id = d.Id,
                Author = d.Author,
                QuoteText = d.QuoteText
            })
            .FirstOrDefaultAsync(d => d.Id == id);
        
        return quote;
    }
    
    public async Task<AddQuoteDto> AddQuote(AddQuoteDto createQuoteDto)
    {
        var quote = new Quote
        {
            Author = createQuoteDto.Author,
            QuoteText = createQuoteDto.QuoteText
        };
        
        await _context.Quotes.AddAsync(quote);
        await _context.SaveChangesAsync();
        
        createQuoteDto.Id = quote.Id;
        return createQuoteDto;
    }
    
   public async Task<UpdateQuoteDto> UpdateQuote(UpdateQuoteDto updateQuoteDto)
    {
        var quote = await _context.Quotes.FirstOrDefaultAsync(d => d.Id == updateQuoteDto.Id);
        
        if (quote == null)
        {
            return null;
        }
        
        quote.Author = updateQuoteDto.Author;
        quote.QuoteText = updateQuoteDto.QuoteText;
        
        await _context.SaveChangesAsync();
        
        return updateQuoteDto;
    }
    
    public async Task<bool> DeleteDepartment(int id)
    {
        var quote = await _context.Quotes.FirstOrDefaultAsync(d => d.Id == id);
        
        if (quote == null)
        {
            return false;
        }
        
        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
        
        return true;
    }
}