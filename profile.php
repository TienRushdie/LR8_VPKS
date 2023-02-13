<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'mining_farm_db';
$NickName="";
$Balance="";
if( !isset( $_GET['user_Nick'] ) ) {
    die( "Нужно передать ID пользователя" );
 }
$userNick = $_GET['user_Nick'];

header("Content-Type: text/html; charset=utf-8");

$link = mysqli_connect("127.0.0.1", $username, $password, "mining_farm_db");

if (!$link) {
    echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
    echo "Код ошибки errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Текст ошибки error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}
    $query = "SELECT Login, NickName, Balance,Capacity,type_1_cards,type_2_cards,type_3_cards FROM users where NickName='".$userNick."'";
    $result = mysqli_query($link, $query);
    while($row = mysqli_fetch_array($result))
    {
        echo $row["Login"]." ".$row["NickName"]." ".$row["Balance"]." ".$row["Capacity"]." ".$row["type_1_cards"]." ".$row["type_2_cards"]." ".$row["type_3_cards"]."";
    }