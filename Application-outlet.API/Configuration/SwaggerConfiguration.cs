using System.Reflection;

namespace Application_outlet.API.Configuration
{
    public static class SwaggerConfiguration
    {
         public static void AddSwaggerConfiguration(this IServiceCollection service)
        {
            service.AddSwaggerGen( x =>
                {
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                    x.IncludeXmlComments(xmlPath);

                    var currentAssembly = Assembly.GetExecutingAssembly();  
                    var xmlDocs = currentAssembly.GetReferencedAssemblies()  
                    .Union(new AssemblyName[] { currentAssembly.GetName()})  
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))  
                    .Where(f=>File.Exists(f)).ToArray(); 

                    Array.ForEach(xmlDocs, (d) =>  
                    {  
                        x.IncludeXmlComments(d);  
                    });
                });
        }
    }
}