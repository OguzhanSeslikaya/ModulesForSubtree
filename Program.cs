using Microsoft.EntityFrameworkCore;
using ModulesForSubtree.BannersModule.Extensions;
using ModulesForSubtree.BannersModule.Services;
using ModulesForSubtree.CampaignsModule.Contexts;
using ModulesForSubtree.CampaignsModule.Extensions;
using ModulesForSubtree.CampaignsModule.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBannersService, BannersService>();
builder.Services.AddTransient<ICampaignsService, CampaignsService>();

var connectionString = "Server=localhost;Initial Catalog=ModulesForSubtreeStorage;Integrated Security=True;TrustServerCertificate=True;";

builder.Services.AddBannersModule(connectionString);
builder.Services.AddCampaignsModule(connectionString);

builder.Services.AddDbContext<CampaignsModuleDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
