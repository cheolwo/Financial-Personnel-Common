using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using 재무인사Common.Model;

public class DataSeeder
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DataSeeder(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task SeedDataAsync(string path)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<재무인사DbContext>();

        if (!await dbContext.은행.AnyAsync())
        {
            using var package = new ExcelPackage(new FileInfo(path));
            var worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var code = int.Parse(worksheet.Cells[row, 1].Text);
                var name = worksheet.Cells[row, 2].Text;

                var bank = new 은행 { 코드 = code, 기관명 = name };
                dbContext.은행.Add(bank);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
