# Задание 1-5
## Задание 1
    cat > домашние_животные

    собаки
    кошки
    хомяки

    cat > вьючные_животные

    лошади
    верблюды
    ослы

    cat домашние_животные вьючные_животные > друзья_человека

    cat друзья_человека

## Задание 2

    mv друзья_человека final_task

## Задание 3

    sudo apt install mysql-server mysql-client
    sudo apt-get update

## Задание 4
***Установка***

    wget https://dev.mysql.com/get/mysql-apt-config_0.8.24-1_all.deb
    sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
    sudo apt install mysql-server
    sudo mysql_secure_installation
    sudo mysql_secure_installation
    sudo apt-get install mysql-workbench-community

***Удаление***

    sudo dpkg -s mysql-server
    sudo dpkg -r mysql-workbench-community
    sudo dpkg -r mysql-community-server


