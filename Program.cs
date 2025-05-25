using ModulesForSubtree.BannersModule.Extensions;
using ModulesForSubtree.CampaignsModule.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = "Server=localhost;Initial Catalog=ModulesForSubtreeStorage;Integrated Security=True;TrustServerCertificate=True;";

builder.Services.AddBannersModule(connectionString);
builder.Services.AddCampaignsModule(connectionString);

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
