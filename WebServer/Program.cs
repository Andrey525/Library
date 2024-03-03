using BookService;
using FilmService;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

using GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5291");
BookServ.BookServClient client = new BookServ.BookServClient(channel);

using GrpcChannel channel2 = GrpcChannel.ForAddress("http://localhost:5136");
FilmServ.FilmServClient client2 = new FilmServ.FilmServClient(channel2);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(client);
builder.Services.AddSingleton(client2);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();