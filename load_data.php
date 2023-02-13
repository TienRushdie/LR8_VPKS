<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'mining_farm_db';
$NickName="";
$Balance="";$Capacity="";
if( !isset( $_GET['user_id'] ) ) {
    die( "Нужно передать ID пользователя" );
 }
$userID = $_GET['user_id'];

header("Content-Type: text/html; charset=utf-8");

$link = mysqli_connect("127.0.0.1", $username, $password, "mining_farm_db");

if (!$link) {
    echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
    echo "Код ошибки errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Текст ошибки error: " . mysqli_connect_error() . PHP_EOL;
    exit;
}

 
   
     
    $query=$link->prepare( "SELECT NickName, Balance, Capacity FROM users WHERE ID = ? or NickName=? or Balance=? or Capacity=?" );
    $query->bind_Param('isss',$userID,$NickName,$Balance,$Capacity);
    $query->execute();
    
     
    /*if( !$query->execute() ) {
        die( "Не удалось получить данные!" );
    }
     
    if( $query->row_Count() == 0 ) {
        die( "Нет такого пользователя!" );
    }*/
     
    $query = "SELECT  NickName, Balance, Capacity FROM users where ID='".$userID."'";
    $result = mysqli_query($link, $query);
    while ($row = mysqli_fetch_row($result)) {
        printf("%s %s %s\n", $row[0], $row[1], $row[2]);
    }
 
