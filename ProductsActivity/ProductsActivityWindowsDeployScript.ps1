#Use this script to deploy the MS
#
#To Use this script:
#       ./ProductsActivityWindowsDeployScript.ps1 IpServerDataBase UserDb PasswordDb AuthAuthority AuthAudience FrontEndOrigin
#Use host.docker.internal in appsettings to conect a localhost

cd .\Source\ProductsActivity.Api

	dotnet publish -c Release -o publishFolder

	$tempKeyContent = Get-Content ".\tempkey.rsa" -Raw

	cd .\publishFolder

		Out-File -InputObject $tempKeyContent -Encoding ascii -FilePath ".\tempkey.rsa"

		$appSettingsContent = Get-Content ".\appsettings.json" -Raw

		Out-File -InputObject $appSettingsContent -Encoding ascii -FilePath ".\appsettings.json"

		rm ".\appsettings.Development.json"

		cd ..
	
	#Remove old image and container in docker

    docker stop productsactivity

    docker container rm productsactivity

    docker image rm productsactivity

    #Create image and start container in docker

    docker build -t productsactivity .

	docker run -d -p 64813:80 --name productsactivity productsactivity

	rm -r .\publishFolder
	rm -r .\bin
	rm -r .\obj

	cd ..
	cd ..
