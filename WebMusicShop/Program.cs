using WebMusicShop.Models.Context;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.ICliente;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Interfaces.IUsuario;
using WebMusicShop.Models.Repositories;
using WebMusicShop.Models.Services;

var builder = WebApplication.CreateBuilder(args);
//Clientes
builder.Services.AddScoped<IClienteContext, ClienteContext>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IConnectionManager,ConnectionManager>();
//Produtos
builder.Services.AddScoped<IProdutoContext, ProdutoContext>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
//Usuario
builder.Services.AddScoped<IUsuarioContext, UsuarioContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
