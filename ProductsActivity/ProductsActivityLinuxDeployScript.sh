#Use this script to deploy the MS
#
#To Use this script:
#       chmod +x ./ProductsActivityLinuxDeployScript.sh
#       ./ProductsActivityLinuxDeployScript.sh

cd Source/ProductsActivity.Api//

    dotnet publish -c release -o publishFolder

    cd publishFolder

        tempkey=$(cat ../tempkey.rsa)
        echo "$tempkey" > tempkey.rsa

        value=$(cat ../appsettings.json)

        echo "$value" > appsettings.json

        rm appsettings.Development.json

        cd ..

    #Remove old image and container in docker

    sudo docker stop productsactivity

    sudo docker container rm productsactivity

    sudo docker image rm productsactivity

    #Create image and start container in docker

    sudo docker build -t productsactivity .

    sudo docker run -d -p 64813:80 --name productsactivity productsactivity

    rm -r publishFolder/
    rm -r bin/
    rm -r obj/

    cd ..
    cd ..
