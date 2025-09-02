using WebApiTemplate.Core.Services;
using WebApiTemplate.Infrastructure.Persistence;
using WebApiTemplate.Infrastructure.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddControllers();

	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}
{
	builder.AddPersistence();
	builder.AddExternalServices();
	builder.AddServices();
}

var app = builder.Build();

{
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();
	app.UseRouting();

	app.MapControllers();

}

app.Run();
