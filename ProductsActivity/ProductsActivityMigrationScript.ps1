#Migrations ProductsActivity Project

cd .\Source\ProductsActivity.Dal

dotnet ef migrations add InitialMigration --context ProductsActivityContext --output-dir Migrations/ProductsActivityMigrations -v -s ..\ProductsActivity.Api\ProductsActivity.Api.csproj

cd ..\..
