var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSmartComponents();

// Need to use package SmartComponents.Inference.OpenAI and configure OpenAI backend to use smart controls (other than combobox)
// https://github.com/dotnet-smartcomponents/smartcomponents/blob/main/docs/configure-openai-backend.md
// Reference Video - Steve Sanderson https://www.youtube.com/watch?v=TSNAvFJoP4M&list=WL&index=4&t=156s

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
