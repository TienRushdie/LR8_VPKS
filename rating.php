<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'mining_farm_db';
$NickName="";
$Balance="";
header("Content-Type: text/html; charset=utf-8");
$link = mysqli_connect("127.0.0.1", $username, $password, "mining_farm_db");
if (!$link) {
    echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
    echo "Код ошибки errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Текст ошибки error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}  
    $query = "SELECT ID, NickName, Balance FROM users order by Balance desc";
    $result = mysqli_query($link, $query);
    while($row = mysqli_fetch_array($result))
    {
        echo $row["ID"]." ".$row["NickName"]." ".$row["Balance"].",";
    }